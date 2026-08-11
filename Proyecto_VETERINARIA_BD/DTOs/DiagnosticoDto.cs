namespace Proyecto_VETERINARIA_BD.DTOs
{
    public class DiagnosticoListarDto
    {
        public string? NombreDiagnostico { get; set; }
        public string? Gravedad { get; set; }
        public int? IdVeterinario { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class DiagnosticoObtenerPorIDDto
    {
        public int IdDiagnostico { get; set; }
    }

    public class DiagnosticoInsertarDto
    {
        public int IdExpediente { get; set; }
        public int IdVeterinario { get; set; }
        public string NombreDiagnostico { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string Gravedad { get; set; } = null!;
    }

    public class DiagnosticoActualizarDto : DiagnosticoInsertarDto
    {
        public int IdDiagnostico { get; set; }
    }

    public class DiagnosticoEliminarDto
    {
        public int IdDiagnostico { get; set; }
    }
}