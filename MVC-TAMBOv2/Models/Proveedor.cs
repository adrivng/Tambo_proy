using System;
using System.Collections.Generic;

namespace MVC_TAMBOv2.Models;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Descripcion { get; set; }
}
