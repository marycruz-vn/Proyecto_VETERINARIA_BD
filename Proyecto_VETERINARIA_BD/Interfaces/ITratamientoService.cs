using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Models;

namespace Proyecto_VETERINARIA_BD.Interfaces
{
    public interface ITratamientoService
    {
        Task<List<TratamientoListarDto>> ListarAsync(TratamientoListarDto dto);
        Task<TratamientoObtenerPorIDDto?> ObtenerPorIDAsync(TratamientoObtenerPorIDDto dto);
        Task<TratamientoInsertarDto?> InsertarAsync(TratamientoInsertarDto dto);
        Task<TratamientoActualizarDto?> ActualizarAsync(TratamientoActualizarDto dto);
        Task<TratamientoEliminarDto?> EliminarAsync(TratamientoEliminarDto dto);
    }
}