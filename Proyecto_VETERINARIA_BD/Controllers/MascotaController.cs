using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;

namespace Proyecto_VETERINARIA_BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MascotaController : ControllerBase
    {
        private readonly IMascotaService _mascotaService;

        public MascotaController(IMascotaService mascotaService)
        {
            _mascotaService = mascotaService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar([FromQuery] MascotaListarDto dto)
        {
            var result = await _mascotaService.ListarAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorID(int id)
        {
            var result = await _mascotaService.ObtenerPorIDAsync(new MascotaObtenerPorIDDto { IdMascota = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Recepcionista")]
        public async Task<IActionResult> Insertar([FromBody] MascotaInsertarDto dto)
        {
            var result = await _mascotaService.InsertarAsync(dto);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Recepcionista")]
        public async Task<IActionResult> Actualizar([FromBody] MascotaActualizarDto dto)
        {
            var result = await _mascotaService.ActualizarAsync(dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Recepcionista")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _mascotaService.EliminarAsync(new MascotaEliminarDto { IdMascota = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}