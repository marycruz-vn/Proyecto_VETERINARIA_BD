using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Models;

namespace Proyecto_VETERINARIA_BD.Interfaces
{
    public interface ICitaService
    {
        Task<List<CitaListarDto>> ListarAsync(CitaListarDto dto);
        Task<CitaObtenerPorIDDto?> ObtenerPorIDAsync(CitaObtenerPorIDDto dto);
        Task<CitaInsertarDto?> InsertarAsync(CitaInsertarDto dto);
        Task<CitaActualizarDto?> ActualizarAsync(CitaActualizarDto dto);
        Task<CitaEliminarDto?> EliminarAsync(CitaEliminarDto dto);
    }
}
