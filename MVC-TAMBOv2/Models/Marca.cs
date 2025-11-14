using System;
using System.Collections.Generic;

namespace MVC_TAMBOv2.Models;

public partial class Marca
{
    public int IdMarca { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
