using System;
using System.Collections.Generic;

namespace MVC_TAMBOv2.Models;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public string? NombreCategoria { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
