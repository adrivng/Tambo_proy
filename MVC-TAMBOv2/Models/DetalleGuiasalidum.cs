using System;
using System.Collections.Generic;

namespace MVC_TAMBOv2.Models;

public partial class DetalleGuiasalidum
{
    public int IdSalida { get; set; }

    public int IdProducto { get; set; }

    public int? Cantidad { get; set; }
}
