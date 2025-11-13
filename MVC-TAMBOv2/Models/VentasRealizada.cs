using System;
using System.Collections.Generic;

namespace MVC_TAMBOv2.Models;

public partial class VentasRealizada
{
    public int IdVenta { get; set; }

    public int? IdEmpleado { get; set; }

    public int? IdTicket { get; set; }
}
