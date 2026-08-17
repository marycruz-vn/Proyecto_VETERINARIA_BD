namespace Proyecto_VETERINARIA_BD.DTOs
{
    public class ProveedorListarDto
    {
        public int IdProveedor { get; set; }
        public string? NombreEmpresa { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class ProveedorObtenerPorIDDto
    {
        public int IdProveedor { get; set; }
        public string? NombreEmpresa { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
    }

    public class ProveedorInsertarDto
    {
        public string NombreEmpresa { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Direccion { get; set; } = null!;
    }

    public class ProveedorActualizarDto : ProveedorInsertarDto
    {
        public int IdProveedor { get; set; }
    }

    public class ProveedorEliminarDto
    {
        public int IdProveedor { get; set; }
    }
}