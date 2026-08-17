namespace Proyecto_VETERINARIA_BD.DTOs
{
    public class InventarioDto
    {
    }
    public class InventarioListarDto
    {
        public int IdInventario { get; set; }
        public int? IdProducto { get; set; }
        public int? CantidadStock { get; set; }
        public int? StockMinimo { get; set; }
        public DateOnly? FechaActualizacion { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class InventarioObtenerPorIDDto
    {
        public int IdInventario { get; set; }
        public int? IdProducto { get; set; }
        public int? CantidadStock { get; set; }
        public int? StockMinimo { get; set; }
        public DateOnly? FechaActualizacion { get; set; }
    }

    public class InventarioInsertarDto
    {
        public int IdProducto { get; set; }
        public int CantidadStock { get; set; }
        public int StockMinimo { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }

    public class InventarioActualizarDto : InventarioInsertarDto
    {
        public int IdInventario { get; set; }
    }

    public class InventarioEliminarDto
    {
        public int IdInventario { get; set; }
    }
}