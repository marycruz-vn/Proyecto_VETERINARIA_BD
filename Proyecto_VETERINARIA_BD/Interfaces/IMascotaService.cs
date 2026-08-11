using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Models;

namespace Proyecto_VETERINARIA_BD.Interfaces
{
    public interface IMascotaService
    {
        Task<List<MascotaListarDto>> ListarAsync(MascotaListarDto dto);
        Task<MascotaObtenerPorIDDto?> ObtenerPorIDAsync(MascotaObtenerPorIDDto dto);
        Task<MascotaInsertarDto?> InsertarAsync(MascotaInsertarDto dto);
        Task<MascotaActualizarDto?> ActualizarAsync(MascotaActualizarDto dto);
        Task<MascotaEliminarDto?> EliminarAsync(MascotaEliminarDto dto);
    }
}