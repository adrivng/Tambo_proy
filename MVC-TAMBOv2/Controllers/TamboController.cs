using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_TAMBOv2.Models;
using MVC_TAMBOv2.ViewModel;

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
                        .Include(p => p.Categoria)
                        .Include(p => p.Marca)
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
    }
}
