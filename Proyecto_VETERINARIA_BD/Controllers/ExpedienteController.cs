using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;

namespace Proyecto_VETERINARIA_BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpedienteController : ControllerBase
    {
        private readonly IExpedienteService _expedienteService;

        public ExpedienteController(IExpedienteService expedienteService)
        {
            _expedienteService = expedienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar([FromQuery] ExpedienteListarDto dto)
        {
            var result = await _expedienteService.ListarAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorID(int id)
        {
            var result = await _expedienteService.ObtenerPorIDAsync(new ExpedienteObtenerPorIDDto { IdExpediente = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Veterinario")]
        public async Task<IActionResult> Insertar([FromBody] ExpedienteInsertarDto dto)
        {
            var result = await _expedienteService.InsertarAsync(dto);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Veterinario")]
        public async Task<IActionResult> Actualizar([FromBody] ExpedienteActualizarDto dto)
        {
            var result = await _expedienteService.ActualizarAsync(dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Veterinario")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _expedienteService.EliminarAsync(new ExpedienteEliminarDto { IdExpediente = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}