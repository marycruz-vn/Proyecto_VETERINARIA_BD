using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;
using static Proyecto_VETERINARIA_BD.DTOs.ProductoDto;

namespace Proyecto_VETERINARIA_BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar([FromQuery] ProductoListarDto dto)
        {
            var result = await _productoService.ListarAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorID(int id)
        {
            var result = await _productoService.ObtenerPorIDAsync(
                new ProductoObtenerPorIDDto
                {
                    IdProducto = id
                });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Insertar([FromBody] ProductoInsertarDto dto)
        {
            var result = await _productoService.InsertarAsync(dto);

            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Actualizar([FromBody] ProductoActualizarDto dto)
        {
            var result = await _productoService.ActualizarAsync(dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _productoService.EliminarAsync(
                new ProductoEliminarDto
                {
                    IdProducto = id
                });

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}