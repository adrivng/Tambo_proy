using System;
using System.Collections.Generic;

namespace MVC_TAMBOv2.Models;

public partial class DetalleOrdenCompra
{
    public int IdProducto { get; set; }

    public int IdProveedor { get; set; }

    public int? IdOrdenCompra { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Importe { get; set; }
}
