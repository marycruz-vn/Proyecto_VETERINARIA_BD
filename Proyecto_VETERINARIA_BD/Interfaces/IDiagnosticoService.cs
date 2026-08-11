using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Models;

namespace Proyecto_VETERINARIA_BD.Interfaces
{
    public interface IDiagnosticoService
    {
        Task<List<DiagnosticoListarDto>> ListarAsync(DiagnosticoListarDto dto);
        Task<DiagnosticoObtenerPorIDDto?> ObtenerPorIDAsync(DiagnosticoObtenerPorIDDto dto);
        Task<DiagnosticoInsertarDto?> InsertarAsync(DiagnosticoInsertarDto dto);
        Task<DiagnosticoActualizarDto?> ActualizarAsync(DiagnosticoActualizarDto dto);
        Task<DiagnosticoEliminarDto?> EliminarAsync(DiagnosticoEliminarDto dto);
    }
}