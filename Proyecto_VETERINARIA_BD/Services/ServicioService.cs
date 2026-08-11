using Proyecto_VETERINARIA_BD;
using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;
using Proyecto_VETERINARIA_BD.Models;

namespace Proyecto_VETERINARIA_BD.Services
{
    public class ServicioService : IServicioService
    {
        private readonly AppDbContext _context;

        public ServicioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ServicioListarDto>> ListarAsync(ServicioListarDto dto)
        {
            return await _context.sp_Servicio_Listar();
        }

        public async Task<ServicioObtenerPorIDDto?> ObtenerPorIDAsync(ServicioObtenerPorIDDto dto)
        {
            return await _context.sp_Servicio_ObtenerPorID(dto.IdServicio);
        }

        public async Task<ServicioInsertarDto?> InsertarAsync(ServicioInsertarDto dto)
        {
            return await _context.sp_Servicio_Insertar(
                dto.NombreServicio,
                dto.Descripcion,
                dto.Precio
            );
        }

        public async Task<ServicioActualizarDto?> ActualizarAsync(ServicioActualizarDto dto)
        {
            return await _context.sp_Servicio_Actualizar(
                dto.IdServicio,
                dto.NombreServicio,
                dto.Descripcion,
                dto.Precio
            );
        }

        public async Task<ServicioEliminarDto?> EliminarAsync(ServicioEliminarDto dto)
        {
            return await _context.sp_Servicio_Eliminar(dto.IdServicio);
        }
    }
}