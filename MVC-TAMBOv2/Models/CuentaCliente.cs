using System;
using System.Collections.Generic;

namespace MVC_TAMBOv2.Models;

public partial class CuentaCliente
{
    public int IdCuentaCliente { get; set; }

    public string Correo { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public string? Rol { get; set; }
}
