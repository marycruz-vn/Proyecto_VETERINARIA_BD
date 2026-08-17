namespace Proyecto_VETERINARIA_BD.DTOs
{
    public class LoginDto
    {
        public string NombreUsuario { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
    }

    public class RegistroDto
    {
        public string NombreUsuario { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public string Rol { get; set; } = null!; // Admin, Veterinario o Recepcionista
    }

    public class UsuarioDto
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string ContrasenaHash { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public string Estado { get; set; } = null!;
    }

    public class UsuarioCreadoDto
    {
        public string NombreUsuario { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Rol { get; set; } = null!;
    }

    public class TokenResponseDto
    {
        public string Token { get; set; } = null!;
        public string NombreUsuario { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public DateTime Expira { get; set; }
    }
}