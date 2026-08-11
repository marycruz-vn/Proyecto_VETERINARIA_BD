using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Models;

namespace Proyecto_VETERINARIA_BD.Interfaces
{
    public interface IVeterinarioService
    {
        Task<List<VeterinarioListarDto>> ListarAsync(VeterinarioListarDto dto);
        Task<VeterinarioObtenerPorIDDto?> ObtenerPorIDAsync(VeterinarioObtenerPorIDDto dto);
        Task<VeterinarioInsertarDto?> InsertarAsync(VeterinarioInsertarDto dto);
        Task<VeterinarioActualizarDto?> ActualizarAsync(VeterinarioActualizarDto dto);
        Task<VeterinarioEliminarDto?> EliminarAsync(VeterinarioEliminarDto dto);
    }
}