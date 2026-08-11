using Proyecto_VETERINARIA_BD;
using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;
using Proyecto_VETERINARIA_BD.Models;

namespace Proyecto_VETERINARIA_BD.Services
{
    public class InventarioService : IInventarioService
    {
        private readonly AppDbContext _context;

        public InventarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<InventarioListarDto>> ListarAsync(InventarioListarDto dto)
        {
            return await _context.sp_Inventario_Listar();
        }

        public async Task<InventarioObtenerPorIDDto?> ObtenerPorIDAsync(InventarioObtenerPorIDDto dto)
        {
            return await _context.sp_Inventario_ObtenerPorID(dto.IdInventario);
        }

        public async Task<InventarioInsertarDto?> InsertarAsync(InventarioInsertarDto dto)
        {
            return await _context.sp_Inventario_Insertar(
                dto.IdProducto,
                dto.CantidadStock,
                dto.StockMinimo,
                dto.FechaActualizacion
            );
        }

        public async Task<InventarioActualizarDto?> ActualizarAsync(InventarioActualizarDto dto)
        {
            return await _context.sp_Inventario_Actualizar(
                dto.IdInventario,
                dto.IdProducto,
                dto.CantidadStock,
                dto.StockMinimo,
                dto.FechaActualizacion
            );
        }

        public async Task<InventarioEliminarDto?> EliminarAsync(InventarioEliminarDto dto)
        {
            return await _context.sp_Inventario_Eliminar(dto.IdInventario);
        }
    }
}