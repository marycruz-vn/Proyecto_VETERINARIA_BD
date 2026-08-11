using Proyecto_VETERINARIA_BD;
using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;
using Proyecto_VETERINARIA_BD.Models;

namespace Proyecto_VETERINARIA_BD.Services
{
    public class ExpedienteService : IExpedienteService
    {
        private readonly AppDbContext _context;

        public ExpedienteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExpedienteListarDto>> ListarAsync(ExpedienteListarDto dto)
        {
            return await _context.sp_Expediente_Listar();
        }

        public async Task<ExpedienteObtenerPorIDDto?> ObtenerPorIDAsync(ExpedienteObtenerPorIDDto dto)
        {
            return await _context.sp_Expediente_ObtenerPorID(dto.IdExpediente);
        }

        public async Task<ExpedienteInsertarDto?> InsertarAsync(ExpedienteInsertarDto dto)
        {
            return await _context.sp_Expediente_Insertar(
                dto.IdMascota,
                dto.Fecha,
                dto.Observaciones,
                dto.TratamientoGeneral
            );
        }

        public async Task<ExpedienteActualizarDto?> ActualizarAsync(ExpedienteActualizarDto dto)
        {
            return await _context.sp_Expediente_Actualizar(
                dto.IdExpediente,
                dto.IdMascota,
                dto.Fecha,
                dto.Observaciones,
                dto.TratamientoGeneral
            );
        }

        public async Task<ExpedienteEliminarDto?> EliminarAsync(ExpedienteEliminarDto dto)
        {
            return await _context.sp_Expediente_Eliminar(dto.IdExpediente);
        }
    }
}