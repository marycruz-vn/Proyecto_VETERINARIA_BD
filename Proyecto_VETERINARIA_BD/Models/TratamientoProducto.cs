using System;
using System.Collections.Generic;

namespace Proyecto_VETERINARIA_BD.Models;

public partial class TratamientoProducto
{
    public int IdTratamientoProducto { get; set; }

    public int IdTratamiento { get; set; }

    public int IdProducto { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Tratamiento IdTratamientoNavigation { get; set; } = null!;
}
