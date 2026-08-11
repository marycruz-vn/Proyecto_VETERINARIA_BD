namespace Proyecto_VETERINARIA_BD.DTOs
{
    public class MascotaListarDto
    {
        public string? Nombre { get; set; }
        public string? Especie { get; set; }
        public string? Raza { get; set; }
        public int? IdCliente { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class MascotaObtenerPorIDDto
    {
        public int IdMascota { get; set; }
    }

    public class MascotaInsertarDto
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = null!;
        public string Especie { get; set; } = null!;
        public string Raza { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public DateOnly FechaNacimiento { get; set; }
        public decimal Peso { get; set; }
        public string? Alergias { get; set; }
    }

    public class MascotaActualizarDto
    {
        public int IdMascota { get; set; }
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = null!;
        public string Especie { get; set; } = null!;
        public string Raza { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public DateOnly FechaNacimiento { get; set; }
        public decimal Peso { get; set; }
        public string? Alergias { get; set; }
    }

    public class MascotaEliminarDto
    {
        public int IdMascota { get; set; }
    }
}