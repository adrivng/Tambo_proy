using System;
using System.Collections.Generic;

namespace MVC_TAMBOv2.Models;

public partial class OrdenCompra
{
    public int IdOrdenCompra { get; set; }

    public string? Estado { get; set; }

    public DateOnly? FechaCompra { get; set; }
}
