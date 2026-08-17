using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;

namespace Proyecto_VETERINARIA_BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CitaController : ControllerBase
    {
        private readonly ICitaService _citaService;

        public CitaController(ICitaService citaService)
        {
            _citaService = citaService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar([FromQuery] CitaListarDto dto)
        {
            var result = await _citaService.ListarAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorID(int id)
        {
            var result = await _citaService.ObtenerPorIDAsync(new CitaObtenerPorIDDto { IdCita = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Recepcionista")]
        public async Task<IActionResult> Insertar([FromBody] CitaInsertarDto dto)
        {
            var result = await _citaService.InsertarAsync(dto);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Recepcionista")]
        public async Task<IActionResult> Actualizar([FromBody] CitaActualizarDto dto)
        {
            var result = await _citaService.ActualizarAsync(dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Recepcionista")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _citaService.EliminarAsync(new CitaEliminarDto { IdCita = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}