using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;

namespace Proyecto_VETERINARIA_BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DiagnosticoController : ControllerBase
    {
        private readonly IDiagnosticoService _diagnosticoService;

        public DiagnosticoController(IDiagnosticoService diagnosticoService)
        {
            _diagnosticoService = diagnosticoService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar([FromQuery] DiagnosticoListarDto dto)
        {
            var result = await _diagnosticoService.ListarAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorID(int id)
        {
            var result = await _diagnosticoService.ObtenerPorIDAsync(new DiagnosticoObtenerPorIDDto { IdDiagnostico = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Veterinario")]
        public async Task<IActionResult> Insertar([FromBody] DiagnosticoInsertarDto dto)
        {
            var result = await _diagnosticoService.InsertarAsync(dto);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Veterinario")]
        public async Task<IActionResult> Actualizar([FromBody] DiagnosticoActualizarDto dto)
        {
            var result = await _diagnosticoService.ActualizarAsync(dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Veterinario")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _diagnosticoService.EliminarAsync(new DiagnosticoEliminarDto { IdDiagnostico = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}