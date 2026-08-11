using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Models;

namespace Proyecto_VETERINARIA_BD.Interfaces
{
    public interface IInventarioService
    {
        Task<List<InventarioListarDto>> ListarAsync(InventarioListarDto dto);
        Task<InventarioObtenerPorIDDto?> ObtenerPorIDAsync(InventarioObtenerPorIDDto dto);
        Task<InventarioInsertarDto?> InsertarAsync(InventarioInsertarDto dto);
        Task<InventarioActualizarDto?> ActualizarAsync(InventarioActualizarDto dto);
        Task<InventarioEliminarDto?> EliminarAsync(InventarioEliminarDto dto);
    }
}