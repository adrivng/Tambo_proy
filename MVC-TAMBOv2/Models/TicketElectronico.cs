using System;
using System.Collections.Generic;

namespace MVC_TAMBOv2.Models;

public partial class TicketElectronico
{
    public int IdTicket { get; set; }

    public string? Tipo { get; set; }

    public string? FormaPago { get; set; }

    public DateTime? FechaEmision { get; set; }

    public double? Subtotal { get; set; }

    public double? Igv { get; set; }
}
