using System;
using System.Collections.Generic;

namespace MVC_TAMBOv2.Models;

public partial class Almacen
{
    public int IdAlmacen { get; set; }

    public int IdProducto { get; set; }

    public int Stock { get; set; }
}
