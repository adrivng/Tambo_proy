using System;
using System.Collections.Generic;

namespace MVC_TAMBOv2.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public int? IdCuentaCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Direccion { get; set; }

    public int? Telefono { get; set; }

    public int? Dni { get; set; }

    public string? TipoCliente { get; set; }

    public string? Ruc { get; set; }
}
