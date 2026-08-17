using Proyecto_VETERINARIA_BD.DTOs;

namespace Proyecto_VETERINARIA_BD.Interfaces
{
    public interface IAuthService
    {
        Task<TokenResponseDto?> LoginAsync(LoginDto dto);
        Task<UsuarioCreadoDto?> RegistrarAsync(RegistroDto dto);
    }
}