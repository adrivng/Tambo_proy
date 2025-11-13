using System;
using System.Collections.Generic;

namespace MVC_TAMBOv2.Models;

public partial class DetalleOrdencompra1
{
    public int IdOrdenCompra { get; set; }

    public int IdProducto { get; set; }

    public decimal? Cantidad { get; set; }
}
