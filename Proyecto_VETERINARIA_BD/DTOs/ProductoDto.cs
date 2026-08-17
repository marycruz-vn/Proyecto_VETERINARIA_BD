namespace Proyecto_VETERINARIA_BD.DTOs
{
    public class ProductoDto
    {
        public class ProductoListarDto
        {
            public int IdProducto { get; set; }
            public int? IdProveedor { get; set; }
            public string? NombreProducto { get; set; }
            public string? Categoria { get; set; }
            public string? Descripcion { get; set; }
            public decimal? Precio { get; set; }
            public DateOnly? FechaVencimiento { get; set; }
            public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 10;
        }

        public class ProductoObtenerPorIDDto
        {
            public int IdProducto { get; set; }
            public int? IdProveedor { get; set; }
            public string? NombreProducto { get; set; }
            public string? Categoria { get; set; }
            public string? Descripcion { get; set; }
            public decimal? Precio { get; set; }
            public DateOnly? FechaVencimiento { get; set; }
        }

        public class ProductoInsertarDto
        {
            public int IdProveedor { get; set; }
            public string NombreProducto { get; set; } = null!;
            public string Categoria { get; set; } = null!;
            public string? Descripcion { get; set; }
            public decimal Precio { get; set; }
            public DateOnly? FechaVencimiento { get; set; }
        }

        public class ProductoActualizarDto
        {
            public int IdProducto { get; set; }
            public int IdProveedor { get; set; }
            public string NombreProducto { get; set; } = null!;
            public string Categoria { get; set; } = null!;
            public string? Descripcion { get; set; }
            public decimal Precio { get; set; }
            public DateOnly? FechaVencimiento { get; set; }
        }

        public class ProductoEliminarDto
        {
            public int IdProducto { get; set; }
        }
    }
}