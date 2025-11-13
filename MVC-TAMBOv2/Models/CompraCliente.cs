using System;
using System.Collections.Generic;

namespace MVC_TAMBOv2.Models;

public partial class CompraCliente
{
    public int IdCompra { get; set; }

    public int? IdCliente { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCompra { get; set; }
}
