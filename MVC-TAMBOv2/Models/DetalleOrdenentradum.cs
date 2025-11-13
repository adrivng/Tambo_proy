using System;
using System.Collections.Generic;

namespace MVC_TAMBOv2.Models;

public partial class DetalleOrdenentradum
{
    public int IdOrdenEntrada { get; set; }

    public int IdProducto { get; set; }

    public int? Cantidad { get; set; }
}
