namespace Proyecto_VETERINARIA_BD.DTOs
{
    public class ClienteListarDto
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class ClienteObtenerPorIDDto
    {
        public int IdCliente { get; set; }
    }

    public class ClienteInsertarDto
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public DateOnly FechaRegistro { get; set; }
    }

    public class ClienteActualizarDto
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Direccion { get; set; } = null!;
    }

    public class ClienteEliminarDto
    {
        public int IdCliente { get; set; }
    }
}