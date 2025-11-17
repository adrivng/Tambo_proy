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
        public IActionResult RegistroProveedor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistroProveedor_Post(Proveedor proveedor)
        {
            try
            {
                await _context.Proveedors.AddAsync(proveedor);
                await _context.SaveChangesAsync();

                TempData["mensaje"] = "Registro exitoso";
            }
            catch (Exception ex)
            {
                TempData["error"] = "Fallo al registrar: " + ex.Message;
            }

            return RedirectToAction("RegistroProveedor", new Proveedor());
        }
    }
}