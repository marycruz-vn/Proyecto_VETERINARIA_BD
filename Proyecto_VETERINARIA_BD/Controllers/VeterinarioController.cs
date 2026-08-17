using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;

namespace Proyecto_VETERINARIA_BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VeterinarioController : ControllerBase
    {
        private readonly IVeterinarioService _veterinarioService;

        public VeterinarioController(IVeterinarioService veterinarioService)
        {
            _veterinarioService = veterinarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar([FromQuery] VeterinarioListarDto dto)
        {
            var result = await _veterinarioService.ListarAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorID(int id)
        {
            var result = await _veterinarioService.ObtenerPorIDAsync(new VeterinarioObtenerPorIDDto { IdVeterinario = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Insertar([FromBody] VeterinarioInsertarDto dto)
        {
            var result = await _veterinarioService.InsertarAsync(dto);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Actualizar([FromBody] VeterinarioActualizarDto dto)
        {
            var result = await _veterinarioService.ActualizarAsync(dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _veterinarioService.EliminarAsync(new VeterinarioEliminarDto { IdVeterinario = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}