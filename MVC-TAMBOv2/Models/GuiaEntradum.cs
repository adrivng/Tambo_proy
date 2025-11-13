using System;
using System.Collections.Generic;

namespace MVC_TAMBOv2.Models;

public partial class GuiaEntradum
{
    public int IdEntrada { get; set; }

    public DateOnly? FechaEntrada { get; set; }

    public string? Descripcion { get; set; }
}
