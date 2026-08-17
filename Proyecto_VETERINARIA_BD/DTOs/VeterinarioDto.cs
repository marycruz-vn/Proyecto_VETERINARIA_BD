namespace Proyecto_VETERINARIA_BD.DTOs
{
    public class VeterinarioListarDto
    {
        public int IdVeterinario { get; set; }
        public string? Nombre { get; set; }
        public string? Especialidad { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Estado { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class VeterinarioObtenerPorIDDto
    {
        public int IdVeterinario { get; set; }
        public string? Nombre { get; set; }
        public string? Especialidad { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Estado { get; set; }
    }

    public class VeterinarioInsertarDto
    {
        public string Nombre { get; set; } = null!;
        public string Especialidad { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Estado { get; set; } = null!;
    }

    public class VeterinarioActualizarDto
    {
        public int IdVeterinario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Especialidad { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Estado { get; set; } = null!;
    }

    public class VeterinarioEliminarDto
    {
        public int IdVeterinario { get; set; }
    }
}