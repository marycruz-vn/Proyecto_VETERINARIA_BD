using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Models;

namespace Proyecto_VETERINARIA_BD.Interfaces
{
    public interface IExpedienteService
    {
        Task<List<ExpedienteListarDto>> ListarAsync(ExpedienteListarDto dto);
        Task<ExpedienteObtenerPorIDDto?> ObtenerPorIDAsync(ExpedienteObtenerPorIDDto dto);
        Task<ExpedienteInsertarDto?> InsertarAsync(ExpedienteInsertarDto dto);
        Task<ExpedienteActualizarDto?> ActualizarAsync(ExpedienteActualizarDto dto);
        Task<ExpedienteEliminarDto?> EliminarAsync(ExpedienteEliminarDto dto);
    }
}