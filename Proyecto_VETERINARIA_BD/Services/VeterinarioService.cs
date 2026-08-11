using Proyecto_VETERINARIA_BD;
using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;
using Proyecto_VETERINARIA_BD.Models;

namespace Proyecto_VETERINARIA_BD.Services
{
    public class VeterinarioService : IVeterinarioService
    {
        private readonly AppDbContext _context;

        public VeterinarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<VeterinarioListarDto>> ListarAsync(VeterinarioListarDto dto)
        {
            return await _context.sp_Veterinario_Listar();
        }

        public async Task<VeterinarioObtenerPorIDDto?> ObtenerPorIDAsync(VeterinarioObtenerPorIDDto dto)
        {
            return await _context.sp_Veterinario_ObtenerPorID(dto.IdVeterinario);
        }

        public async Task<VeterinarioInsertarDto?> InsertarAsync(VeterinarioInsertarDto dto)
        {
            return await _context.sp_Veterinario_Insertar(
                dto.Nombre,
                dto.Especialidad,
                dto.Telefono,
                dto.Correo,
                dto.Estado
            );
        }

        public async Task<VeterinarioActualizarDto?> ActualizarAsync(VeterinarioActualizarDto dto)
        {
            return await _context.sp_Veterinario_Actualizar(
                dto.IdVeterinario,
                dto.Nombre,
                dto.Especialidad,
                dto.Telefono,
                dto.Correo,
                dto.Estado
            );
        }

        public async Task<VeterinarioEliminarDto?> EliminarAsync(VeterinarioEliminarDto dto)
        {
            return await _context.sp_Veterinario_Eliminar(dto.IdVeterinario);
        }
    }
}