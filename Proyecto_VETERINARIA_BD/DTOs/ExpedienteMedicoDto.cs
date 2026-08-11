namespace Proyecto_VETERINARIA_BD.DTOs
{
    public class ExpedienteListarDto
    {
        public int? IdMascota { get; set; }
        public DateTime? Fecha { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class ExpedienteObtenerPorIDDto
    {
        public int IdExpediente { get; set; }
    }

    public class ExpedienteInsertarDto
    {
        public int IdMascota { get; set; }
        public DateOnly Fecha { get; set; }
        public string? Observaciones { get; set; }
        public string? TratamientoGeneral { get; set; }
    }

    public class ExpedienteActualizarDto : ExpedienteInsertarDto
    {
        public int IdExpediente { get; set; }
    }

    public class ExpedienteEliminarDto
    {
        public int IdExpediente { get; set; }
    }
}