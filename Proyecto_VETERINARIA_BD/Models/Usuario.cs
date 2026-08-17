namespace Proyecto_VETERINARIA_BD.Models;

public class Usuario
{
    public int IdUsuario { get; set; }
    public string NombreUsuario { get; set; } = null!;
    public string Correo { get; set; } = null!;
    public string ContrasenaHash { get; set; } = null!;
    public string Rol { get; set; } = null!;
    public string Estado { get; set; } = null!;
}
