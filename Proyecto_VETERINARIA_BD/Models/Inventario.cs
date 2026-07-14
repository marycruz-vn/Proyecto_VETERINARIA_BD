using System;
using System.Collections.Generic;

namespace Proyecto_VETERINARIA_BD.Models;

public partial class Inventario
{
    public int IdInventario { get; set; }

    public int IdProducto { get; set; }

    public int CantidadStock { get; set; }

    public int StockMinimo { get; set; }

    public DateOnly FechaActualizacion { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
