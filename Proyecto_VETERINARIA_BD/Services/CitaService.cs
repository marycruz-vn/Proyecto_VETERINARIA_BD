using Proyecto_VETERINARIA_BD;
using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;
using Proyecto_VETERINARIA_BD.Models;

namespace Proyecto_VETERINARIA_BD.Services
{
    public class CitaService : ICitaService
    {
        private readonly AppDbContext _context;

        public CitaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CitaListarDto>> ListarAsync(CitaListarDto dto)
        {
            return await _context.sp_Cita_Listar();
        }

        public async Task<CitaObtenerPorIDDto?> ObtenerPorIDAsync(CitaObtenerPorIDDto dto)
        {
            return await _context.sp_Cita_ObtenerPorID(dto.IdCita);
        }

        public async Task<CitaInsertarDto?> InsertarAsync(CitaInsertarDto dto)
        {
            return await _context.sp_Cita_Insertar(
                dto.IdCliente,
                dto.IdVeterinario,
                dto.Fecha,
                dto.Hora,
                dto.Motivo,
                dto.Estado
            );
        }

        public async Task<CitaActualizarDto?> ActualizarAsync(CitaActualizarDto dto)
        {
            return await _context.sp_Cita_Actualizar(
                dto.IdCita,
                dto.IdCliente,
                dto.IdVeterinario,
                dto.Fecha,
                dto.Hora,
                dto.Motivo,
                dto.Estado
            );
        }

        public async Task<CitaEliminarDto?> EliminarAsync(CitaEliminarDto dto)
        {
            return await _context.sp_Cita_Eliminar(dto.IdCita);
        }
    }
}