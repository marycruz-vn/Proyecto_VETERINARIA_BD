namespace Proyecto_VETERINARIA_BD.DTOs
{
    public class ServicioDto
    {
    }
    public class ServicioListarDto
    {
        public int IdServicio { get; set; }
        public string? NombreServicio { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public decimal? PrecioMinimo { get; set; }
        public decimal? PrecioMaximo { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class ServicioObtenerPorIDDto
    {
        public int IdServicio { get; set; }
        public string? NombreServicio { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
    }

    public class ServicioInsertarDto
    {
        public string NombreServicio { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
    }

    public class ServicioActualizarDto : ServicioInsertarDto
    {
        public int IdServicio { get; set; }
    }

    public class ServicioEliminarDto
    {
        public int IdServicio { get; set; }
    }
}