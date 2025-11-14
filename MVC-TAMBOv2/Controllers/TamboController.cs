using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_TAMBOv2.Models;
using MVC_TAMBOv2.ViewModel;
using MVC_TAMBOv2.ViewModel.Almacen;

namespace MVC_TAMBOv2.Controllers
{
    public class TamboController : Controller
    {
        private readonly TamboContext _context;

        public TamboController(TamboContext context)
        {
            _context = context;
        }
        public IActionResult MenuPrincipal() // el menu pricipal
        {
            var productos = new List<dynamic>
               {
                  new { Nombre = "Gaseosa 500ml", Precio = 3.50, Imagen = "~/img/inka.jpg" },
                  new { Nombre = "Papas fritas 150g", Precio = 4.00, Imagen = "~/img/papas.jpg" },
                  new { Nombre = "Galletas de chocolate", Precio = 2.80, Imagen = "~/img/galletas.jpg" }
                  };

            return View(productos);
        }

        [HttpGet]
        public IActionResult RegistroProveedor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistroProveedor_Post(Proveedor proveedor)
        {
            try
            {
                var nombre = Request.Form["nombre"];
                var telefono = Request.Form["telefono"];
                var correo = Request.Form["correo"];
                var descripcion = Request.Form["descripcion"];

                var proveedorNuevo = new Proveedor
                {
                    Nombre = nombre,
                    Telefono = telefono,
                    Correo = correo,
                    Descripcion = descripcion
                };

                _context.Proveedors.Add(proveedorNuevo);
                _context.SaveChanges();

                TempData["Mensaje"] = "Registro exitoso";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Fallo al registrar: " + ex.Message;
            }

            return RedirectToAction("RegistroProveedor");
        }


        public IActionResult Index() //es el index para poder listar los productos registrados
        {
            var productos = _context.Productos
                        .Include(p => p.IdCategoriaNavigation)
                        .Include(p => p.IdMarcaNavigation)
                        .ToList();

            return View(productos);
            
        }
        [HttpGet]
        public IActionResult AgregarProducto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AgregarProducto(ProductoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // 🔹 Obtener o crear la marca
            var marca = await _context.Marcas
                .FirstOrDefaultAsync(m => m.Nombre == model.Marca)
                ?? new Marca { Nombre = model.Marca };

            // Si es nueva, se agrega
            if (marca.IdMarca == 0) _context.Marcas.Add(marca);

            // 🔹 Obtener o crear la categoría
            var categoria = await _context.Categoria
                .FirstOrDefaultAsync(c => c.NombreCategoria == model.Categoria)
                ?? new Categorium { NombreCategoria = model.Categoria };

            if (categoria.IdCategoria == 0) _context.Categoria.Add(categoria);

            await _context.SaveChangesAsync(); // guarda si se creó marca o categoría

            // 🔹 Crear el producto
            var producto = new Producto
            {
                Nombre = model.Nombre,
                PrecioUnitario = model.Precio,
                FechaExpiracion = DateOnly.FromDateTime(model.FechaExpiracion),
                IdMarca = marca.IdMarca,
                IdCategoria = categoria.IdCategoria
            };

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            // 🔹 Redirigir al Index
            return RedirectToAction(nameof(Index));
        }

        // GET: Registrar salida
        public IActionResult RegistrarSalida(int idProducto)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.IdProducto == idProducto);

            if (producto == null)
                return NotFound();

            var vm = new RegistrarSalidaViewModel
            {
                IdProducto = producto.IdProducto,
                NombreProducto = producto.Nombre
            };

            return View(vm);
        }

        // POST: Procesar salida
        [HttpPost]
        public IActionResult RegistrarSalida(RegistrarSalidaViewModel model)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.IdProducto == model.IdProducto);

            if (producto == null)
                return NotFound();

            // Validar stock
            if (model.Cantidad <= 0)
            {
                TempData["Error"] = "La cantidad debe ser mayor a 0.";
                return RedirectToAction("RegistrarSalida", new { idProducto = model.IdProducto });
            }

            if (model.Cantidad > producto.Stock)
            {
                TempData["Error"] = "No hay stock suficiente.";
                return RedirectToAction("RegistrarSalida", new { idProducto = model.IdProducto });
            }

            // Crear guía
            var guia = new GuiaSalidum
            {
                FechaSalida = DateTime.Now
            };

            _context.GuiaSalida.Add(guia);
            _context.SaveChanges();

            // Registrar detalle
            var detalle = new DetalleGuiasalidum
            {
                IdSalida = guia.IdGuiaSalida,
                IdProducto = producto.IdProducto,
                Cantidad = model.Cantidad
            };

            _context.DetalleGuiasalida.Add(detalle);

            // Descontar stock
            producto.Stock -= model.Cantidad;

            _context.SaveChanges();

            TempData["Mensaje"] = "Salida registrada correctamente.";

            return RedirectToAction("SalidaRegistrada", new
            {
                id = guia.IdGuiaSalida,
                producto = producto.Nombre,
                cantidad = model.Cantidad
            });
        }

        public IActionResult SalidaRegistrada(int id, string producto, int cantidad)
        {
            var guia = _context.GuiaSalida.FirstOrDefault(g => g.IdGuiaSalida == id);

            if (guia == null)
                return NotFound();

            var vm = new SalidaRegistradaViewModel
            {
                IdGuiaSalida = guia.IdGuiaSalida,
                NombreProducto = producto,
                Cantidad = cantidad,
                FechaSalida = guia.FechaSalida ?? DateTime.Now,
                NumeroComprobante = guia.IdGuiaSalida.ToString("D6")
            };

            return View(vm);
        }

        public IActionResult RegistrarEntrada(int idProducto)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.IdProducto == idProducto);

            if (producto == null)
                return NotFound();

            var vm = new RegistrarEntradaViewModel
            {
                IdProducto = producto.IdProducto,
                NombreProducto = producto.Nombre
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult RegistrarEntrada(RegistrarEntradaViewModel model)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.IdProducto == model.IdProducto);

            if (producto == null)
                return NotFound();

            if (model.Cantidad <= 0)
            {
                TempData["Error"] = "La cantidad debe ser mayor a 0.";
                return RedirectToAction("RegistrarEntrada", new { idProducto = model.IdProducto });
            }

            // SUMAR stock
            producto.Stock += model.Cantidad;

            _context.SaveChanges();

            TempData["Mensaje"] = "Entrada registrada correctamente.";
            return RedirectToAction("Index");
        }

    }
}
