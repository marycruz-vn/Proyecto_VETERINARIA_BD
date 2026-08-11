using Proyecto_VETERINARIA_BD;
using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;
using Proyecto_VETERINARIA_BD.Models;

namespace Proyecto_VETERINARIA_BD.Services
{
    public class DiagnosticoService : IDiagnosticoService
    {
        private readonly AppDbContext _context;

        public DiagnosticoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DiagnosticoListarDto>> ListarAsync(DiagnosticoListarDto dto)
        {
            return await _context.sp_Diagnostico_Listar();
        }

        public async Task<DiagnosticoObtenerPorIDDto?> ObtenerPorIDAsync(DiagnosticoObtenerPorIDDto dto)
        {
            return await _context.sp_Diagnostico_ObtenerPorID(dto.IdDiagnostico);
        }

        public async Task<DiagnosticoInsertarDto?> InsertarAsync(DiagnosticoInsertarDto dto)
        {
            return await _context.sp_Diagnostico_Insertar(
                dto.IdExpediente,
                dto.IdVeterinario,
                dto.NombreDiagnostico,
                dto.Descripcion,
                dto.Gravedad
            );
        }

        public async Task<DiagnosticoActualizarDto?> ActualizarAsync(DiagnosticoActualizarDto dto)
        {
            return await _context.sp_Diagnostico_Actualizar(
                dto.IdDiagnostico,
                dto.IdExpediente,
                dto.IdVeterinario,
                dto.NombreDiagnostico,
                dto.Descripcion,
                dto.Gravedad
            );
        }

        public async Task<DiagnosticoEliminarDto?> EliminarAsync(DiagnosticoEliminarDto dto)
        {
            return await _context.sp_Diagnostico_Eliminar(dto.IdDiagnostico);
        }
    }
}
