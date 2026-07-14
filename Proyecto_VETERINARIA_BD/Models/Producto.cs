using System;
using System.Collections.Generic;

namespace Proyecto_VETERINARIA_BD.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public int IdProveedor { get; set; }

    public string NombreProducto { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;

    public virtual Inventario? Inventario { get; set; }

    public virtual ICollection<TratamientoProducto> TratamientoProductos { get; set; } = new List<TratamientoProducto>();
}
