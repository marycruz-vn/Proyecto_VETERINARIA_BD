using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Models;
using static Proyecto_VETERINARIA_BD.DTOs.ProductoDto;
namespace Proyecto_VETERINARIA_BD.Interfaces
{
    public interface IProductoService
    {
        Task<List<ProductoListarDto>> ListarAsync(ProductoListarDto dto);
        Task<ProductoObtenerPorIDDto?> ObtenerPorIDAsync(ProductoObtenerPorIDDto dto);
        Task<ProductoInsertarDto?> InsertarAsync(ProductoInsertarDto dto);
        Task<ProductoActualizarDto?> ActualizarAsync(ProductoActualizarDto dto);
        Task<ProductoEliminarDto?> EliminarAsync(ProductoEliminarDto dto);
        
    }
 }
