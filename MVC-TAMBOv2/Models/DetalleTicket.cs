using System;
using System.Collections.Generic;

namespace MVC_TAMBOv2.Models;

public partial class DetalleTicket
{
    public int IdDetalle { get; set; }

    public int? IdTicket { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Importe { get; set; }
}
