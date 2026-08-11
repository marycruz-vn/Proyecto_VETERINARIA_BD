using Proyecto_VETERINARIA_BD;
using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;
using Proyecto_VETERINARIA_BD.Models;
using static Proyecto_VETERINARIA_BD.DTOs.ProductoDto;

namespace Proyecto_VETERINARIA_BD.Services
{
    public class ProductoService : IProductoService
    {
        private readonly AppDbContext _context;

        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductoListarDto>> ListarAsync(ProductoListarDto dto)
        {
            return await _context.sp_Producto_Listar(
                dto.NombreProducto,
                dto.Categoria,
                dto.PageNumber,
                dto.PageSize
            );
        }

        public async Task<ProductoObtenerPorIDDto?> ObtenerPorIDAsync(ProductoObtenerPorIDDto dto)
        {
            return await _context.sp_Producto_ObtenerPorID(dto.IdProducto);
        }

        public async Task<ProductoInsertarDto?> InsertarAsync(ProductoInsertarDto dto)
        {
            return await _context.sp_Producto_Insertar(
                dto.NombreProducto,
                dto.Categoria,
                dto.Descripcion,
                dto.Precio,
                dto.FechaVencimiento,
                dto.IdProveedor
            );
        }

        public async Task<ProductoActualizarDto?> ActualizarAsync(ProductoActualizarDto dto)
        {
            return await _context.sp_Producto_Actualizar(
                dto.IdProducto,
                dto.NombreProducto,
                dto.Categoria,
                dto.Descripcion,
                dto.Precio,
                dto.FechaVencimiento,
                dto.IdProveedor
            );
        }

        public async Task<ProductoEliminarDto?> EliminarAsync(ProductoEliminarDto dto)
        {
            return await _context.sp_Producto_Eliminar(dto.IdProducto);
        }
    }
}