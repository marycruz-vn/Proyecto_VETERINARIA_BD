using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;

namespace Proyecto_VETERINARIA_BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TratamientoController : ControllerBase
    {
        private readonly ITratamientoService _tratamientoService;

        public TratamientoController(ITratamientoService tratamientoService)
        {
            _tratamientoService = tratamientoService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar([FromQuery] TratamientoListarDto dto)
        {
            var result = await _tratamientoService.ListarAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorID(int id)
        {
            var result = await _tratamientoService.ObtenerPorIDAsync(new TratamientoObtenerPorIDDto { IdTratamiento = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Veterinario")]
        public async Task<IActionResult> Insertar([FromBody] TratamientoInsertarDto dto)
        {
            var result = await _tratamientoService.InsertarAsync(dto);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Veterinario")]
        public async Task<IActionResult> Actualizar([FromBody] TratamientoActualizarDto dto)
        {
            var result = await _tratamientoService.ActualizarAsync(dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Veterinario")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _tratamientoService.EliminarAsync(new TratamientoEliminarDto { IdTratamiento = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}