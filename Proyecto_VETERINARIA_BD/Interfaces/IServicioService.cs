using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Models;

namespace Proyecto_VETERINARIA_BD.Interfaces
{
    public interface IServicioService
    {
        Task<List<ServicioListarDto>> ListarAsync(ServicioListarDto dto);
        Task<ServicioObtenerPorIDDto?> ObtenerPorIDAsync(ServicioObtenerPorIDDto dto);
        Task<ServicioInsertarDto?> InsertarAsync(ServicioInsertarDto dto);
        Task<ServicioActualizarDto?> ActualizarAsync(ServicioActualizarDto dto);
        Task<ServicioEliminarDto?> EliminarAsync(ServicioEliminarDto dto);
    }
}