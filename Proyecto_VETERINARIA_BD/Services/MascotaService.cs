using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;
using Proyecto_VETERINARIA_BD.Models;

namespace Proyecto_VETERINARIA_BD.Services
{
    public class MascotaService : IMascotaService
    {
        private readonly AppDbContext _context;

        public MascotaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MascotaListarDto>> ListarAsync(MascotaListarDto dto)
        {
            return await _context.sp_Mascota_Listar();
        }

        public async Task<MascotaObtenerPorIDDto?> ObtenerPorIDAsync(MascotaObtenerPorIDDto dto)
        {
            return await _context.sp_Mascota_ObtenerPorID(dto.IdMascota);
        }

        public async Task<MascotaInsertarDto?> InsertarAsync(MascotaInsertarDto dto)
        {
            return await _context.sp_Mascota_Insertar(
                dto.IdCliente,
                dto.Nombre,
                dto.Especie,
                dto.Raza,
                dto.Sexo,
                dto.FechaNacimiento,
                dto.Peso,
                dto.Alergias
            );
        }

        public async Task<MascotaActualizarDto?> ActualizarAsync(MascotaActualizarDto dto)
        {
            return await _context.sp_Mascota_Actualizar(
                dto.IdMascota,
                dto.IdCliente,
                dto.Nombre,
                dto.Especie,
                dto.Raza,
                dto.Sexo,
                dto.FechaNacimiento,
                dto.Peso,
                dto.Alergias
            );
        }

        public async Task<MascotaEliminarDto?> EliminarAsync(MascotaEliminarDto dto)
        {
            return await _context.sp_Mascota_Eliminar(dto.IdMascota);
        }
    }
}