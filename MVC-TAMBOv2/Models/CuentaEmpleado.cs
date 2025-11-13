using System;
using System.Collections.Generic;

namespace MVC_TAMBOv2.Models;

public partial class CuentaEmpleado
{
    public int IdCuentaEmpleado { get; set; }

    public string? Correo { get; set; }

    public string? Password { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public string? Rol { get; set; }
}
