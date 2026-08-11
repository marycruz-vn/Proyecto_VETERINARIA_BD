using Microsoft.AspNetCore.Mvc;
using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;

namespace Proyecto_VETERINARIA_BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar([FromQuery] ClienteListarDto dto)
        {
            var result = await _clienteService.ListarAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorID(int id)
        {
            var result = await _clienteService.ObtenerPorIDAsync(new ClienteObtenerPorIDDto { IdCliente = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] ClienteInsertarDto dto)
        {
            var result = await _clienteService.InsertarAsync(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] ClienteActualizarDto dto)
        {
            var result = await _clienteService.ActualizarAsync(dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _clienteService.EliminarAsync(new ClienteEliminarDto { IdCliente = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}