using System;
using System.Collections.Generic;

namespace MVC_TAMBOv2.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public int? IdCuentaEmpleado { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public decimal? Salario { get; set; }

    public DateTime? FechaContratacion { get; set; }

    public int? Telefono { get; set; }
}
