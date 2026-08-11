using Microsoft.AspNetCore.Mvc;
using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;

namespace Proyecto_VETERINARIA_BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<IActionResult> Insertar([FromBody] VeterinarioInsertarDto dto)
        {
            var result = await _veterinarioService.InsertarAsync(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VeterinarioActualizarDto dto)
        {
            var result = await _veterinarioService.ActualizarAsync(dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _veterinarioService.EliminarAsync(new VeterinarioEliminarDto { IdVeterinario = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}