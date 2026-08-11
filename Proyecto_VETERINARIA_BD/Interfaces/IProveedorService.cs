using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Models;

namespace Proyecto_VETERINARIA_BD.Interfaces
{
    public interface IProveedorService
    {
        Task<List<ProveedorListarDto>> ListarAsync(ProveedorListarDto dto);
        Task<ProveedorObtenerPorIDDto?> ObtenerPorIDAsync(ProveedorObtenerPorIDDto dto);
        Task<ProveedorInsertarDto?> InsertarAsync(ProveedorInsertarDto dto);
        Task<ProveedorActualizarDto?> ActualizarAsync(ProveedorActualizarDto dto);
        Task<ProveedorEliminarDto?> EliminarAsync(ProveedorEliminarDto dto);
    }
}