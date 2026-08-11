using Proyecto_VETERINARIA_BD;
using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;
using Proyecto_VETERINARIA_BD.Models;

namespace Proyecto_VETERINARIA_BD.Services
{
    public class TratamientoService : ITratamientoService
    {
        private readonly AppDbContext _context;

        public TratamientoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TratamientoListarDto>> ListarAsync(TratamientoListarDto dto)
        {
            return await _context.sp_Tratamiento_Listar();
        }

        public async Task<TratamientoObtenerPorIDDto?> ObtenerPorIDAsync(TratamientoObtenerPorIDDto dto)
        {
            return await _context.sp_Tratamiento_ObtenerPorID(dto.IdTratamiento);
        }

        public async Task<TratamientoInsertarDto?> InsertarAsync(TratamientoInsertarDto dto)
        {
            return await _context.sp_Tratamiento_Insertar(
                dto.IdDiagnostico,
                dto.NombreTratamiento,
                dto.Descripcion,
                dto.DuracionDias
            );
        }

        public async Task<TratamientoActualizarDto?> ActualizarAsync(TratamientoActualizarDto dto)
        {
            return await _context.sp_Tratamiento_Actualizar(
                dto.IdTratamiento,
                dto.IdDiagnostico,
                dto.NombreTratamiento,
                dto.Descripcion,
                dto.DuracionDias
            );
        }

        public async Task<TratamientoEliminarDto?> EliminarAsync(TratamientoEliminarDto dto)
        {
            return await _context.sp_Tratamiento_Eliminar(dto.IdTratamiento);
        }
    }
}