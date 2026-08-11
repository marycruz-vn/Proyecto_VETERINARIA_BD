namespace Proyecto_VETERINARIA_BD.DTOs
{
    public class CitaListarDto
    {
        public DateTime? Fecha { get; set; }
        public int? IdCliente { get; set; }
        public int? IdVeterinario { get; set; }
        public string? Estado { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class CitaObtenerPorIDDto
    {
        public int IdCita { get; set; }
    }

    public class CitaInsertarDto
    {
        public int IdCliente { get; set; }
        public int IdVeterinario { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeOnly Hora { get; set; }
        public string Motivo { get; set; } = null!;
        public string Estado { get; set; } = null!;
    }

    public class CitaActualizarDto : CitaInsertarDto
    {
        public int IdCita { get; set; }
    }

    public class CitaEliminarDto
    {
        public int IdCita { get; set; }
    }
}