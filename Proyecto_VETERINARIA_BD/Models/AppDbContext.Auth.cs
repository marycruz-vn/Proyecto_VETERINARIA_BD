using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Proyecto_VETERINARIA_BD.DTOs;

namespace Proyecto_VETERINARIA_BD.Models;

public partial class AppDbContext
{
    public async Task<UsuarioDto?> sp_Usuario_ObtenerPorNombre(string nombreUsuario)
    {
        var result = await Database.SqlQueryRaw<UsuarioDto>(
            "EXEC sp_ObtenerUsuarioPorNombre @nombre_usuario",
            new SqlParameter("@nombre_usuario", nombreUsuario)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    public async Task<UsuarioCreadoDto?> sp_Usuario_Insertar(
        string nombreUsuario, string correo, string contrasenaHash, string rol)
    {
        var result = await Database.SqlQueryRaw<UsuarioCreadoDto>(
            "EXEC sp_InsertarUsuario @nombre_usuario,@correo,@contrasena_hash,@rol",
            new SqlParameter("@nombre_usuario", nombreUsuario),
            new SqlParameter("@correo", correo),
            new SqlParameter("@contrasena_hash", contrasenaHash),
            new SqlParameter("@rol", rol)
        ).ToListAsync();

        return result.FirstOrDefault();
    }
}