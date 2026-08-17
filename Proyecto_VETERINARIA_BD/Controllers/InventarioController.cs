using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;

namespace Proyecto_VETERINARIA_BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InventarioController : ControllerBase
    {
        private readonly IInventarioService _inventarioService;

        public InventarioController(IInventarioService inventarioService)
        {
            _inventarioService = inventarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar([FromQuery] InventarioListarDto dto)
        {
            var result = await _inventarioService.ListarAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorID(int id)
        {
            var result = await _inventarioService.ObtenerPorIDAsync(new InventarioObtenerPorIDDto { IdInventario = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Insertar([FromBody] InventarioInsertarDto dto)
        {
            var result = await _inventarioService.InsertarAsync(dto);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Actualizar([FromBody] InventarioActualizarDto dto)
        {
            var result = await _inventarioService.ActualizarAsync(dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _inventarioService.EliminarAsync(new InventarioEliminarDto { IdInventario = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}