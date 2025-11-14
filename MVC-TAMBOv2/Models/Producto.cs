using System;
using System.Collections.Generic;

namespace MVC_TAMBOv2.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdMarca { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal PrecioUnitario { get; set; }

    public DateOnly? FechaExpiracion { get; set; }

    public int Stock { get; set; }

    public virtual Categorium? IdCategoriaNavigation { get; set; }

    public virtual Marca? IdMarcaNavigation { get; set; }
}
