using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_TAMBOv2.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdMarca { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal PrecioUnitario { get; set; }

    public DateOnly? FechaExpiracion { get; set; }
    [ForeignKey("IdCategoria")]
    public Categorium Categoria { get; set; }
    [ForeignKey("IdMarca")]
    public Marca Marca { get; set; }
}
