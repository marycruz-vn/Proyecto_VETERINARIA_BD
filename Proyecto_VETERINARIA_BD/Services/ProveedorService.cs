
using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;
using Proyecto_VETERINARIA_BD.Models;

namespace Proyecto_VETERINARIA_BD.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly AppDbContext _context;

        public ProveedorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProveedorListarDto>> ListarAsync(ProveedorListarDto dto)
        {
            return await _context.sp_Proveedor_Listar();
        }

        public async Task<ProveedorObtenerPorIDDto?> ObtenerPorIDAsync(ProveedorObtenerPorIDDto dto)
        {
            return await _context.sp_Proveedor_ObtenerPorID(dto.IdProveedor);
        }

        public async Task<ProveedorInsertarDto?> InsertarAsync(ProveedorInsertarDto dto)
        {
            return await _context.sp_Proveedor_Insertar(
                dto.NombreEmpresa,
                dto.Telefono,
                dto.Correo,
                dto.Direccion
            );
        }

        public async Task<ProveedorActualizarDto?> ActualizarAsync(ProveedorActualizarDto dto)
        {
            return await _context.sp_Proveedor_Actualizar(
                dto.IdProveedor,
                dto.NombreEmpresa,
                dto.Telefono,
                dto.Correo,
                dto.Direccion
            );
        }

        public async Task<ProveedorEliminarDto?> EliminarAsync(ProveedorEliminarDto dto)
        {
            return await _context.sp_Proveedor_Eliminar(dto.IdProveedor);
        }
    }
}