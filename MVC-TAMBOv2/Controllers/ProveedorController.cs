using Microsoft.AspNetCore.Mvc;
using MVC_TAMBOv2.Models;

namespace ProyectoTambo.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly TamboContext _context;
        
        public ProveedorController(TamboContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RegistroProveedor()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistroProveedor_Post()
        {
            try
            {
                var nombre = Request.Form["nombre"];
                var telefono = Request.Form["telefono"];
                var correo = Request.Form["correo"];
                var descripcion = Request.Form["descripcion"];

                var proveedor = new Proveedor
                {
                    Nombre = nombre,
                    Telefono = telefono,
                    Correo = correo,
                    Descripcion = descripcion
                };

                await _context.Proveedors.AddAsync(proveedor);
                await _context.SaveChangesAsync();

                TempData["mensaje"] = "Registro exitoso";
            }
            catch (Exception ex)
            {
                TempData["error"] = "Fallo al registrar: " + ex.Message;
            }

            return RedirectToAction("RegistroProveedor");
        }
    }
}
