using Microsoft.AspNetCore.Mvc;
using MVC_TAMBOv2.Models;

namespace MVC_TAMBOv2.Controllers
{
    public class CuentaController : Controller
    {
        private readonly TamboContext _context;

        public CuentaController(TamboContext context)
        {
            _context = context;
        }

        // LOGIN (GET)
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // LOGIN (POST)
        [HttpPost]
        public IActionResult Login(string correo, string password)
        {
            // EMPLEADO (admin, staff)
            var empleado = _context.CuentaEmpleados
                .FirstOrDefault(x => x.Correo == correo && x.Password == password);

            if (empleado != null)
            {
                HttpContext.Session.SetString("rol", empleado.Rol!);

                if (empleado.Rol == "admin")
                    return RedirectToAction("MenuAdmin", "Home");

                if (empleado.Rol == "staff")
                    return RedirectToAction("MenuStaff", "Home");
            }

            // CLIENTE
            var clienteCuenta = _context.CuentaClientes
                .FirstOrDefault(x => x.Correo == correo && x.Password == password);

            if (clienteCuenta != null)
            {
                HttpContext.Session.SetString("rol", "cliente");
                return RedirectToAction("MenuCliente", "Home");
            }

            // NO EXISTE → REGISTRO
            HttpContext.Session.SetString("correoNuevoCliente", correo);
            return RedirectToAction("RegistroCliente");
        }

        // REGISTRO CLIENTE (GET)
        [HttpGet]
        public IActionResult RegistroCliente()
        {
            var correo = HttpContext.Session.GetString("correoNuevoCliente");

            // si no hay correo, simplemente muestra el input vacío
            if (correo == null)
                correo = "";

            ViewBag.Correo = correo;
            return View();
        }

        // REGISTRO CLIENTE (POST)
        [HttpPost]
        public IActionResult RegistroCliente(CuentaCliente cuenta, Cliente cliente)
        {
            cuenta.FechaRegistro = DateTime.Now;
            cuenta.Rol = "cliente";

            _context.CuentaClientes.Add(cuenta);
            _context.SaveChanges();

            cliente.IdCuentaCliente = cuenta.IdCuentaCliente;

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            HttpContext.Session.SetString("rol", "cliente");

            return RedirectToAction("MenuCliente", "Home");
        }

        // LOGOUT
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("MenuPrincipal", "Tambo");
        }

        public IActionResult IrRegistroCliente(string correo)
        {
            if (string.IsNullOrEmpty(correo))
            {
                // si no escribieron un correo, lo dejamos vacío pero permitimos que entre
                HttpContext.Session.SetString("correoNuevoCliente", "");
            }
            else
            {
                HttpContext.Session.SetString("correoNuevoCliente", correo);
            }

            return RedirectToAction("RegistroCliente");
        }
    }
}
