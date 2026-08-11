using Proyecto_VETERINARIA_BD;
using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;
using Proyecto_VETERINARIA_BD.Models;
using System.ClientModel;

namespace Proyecto_VETERINARIA_BD.Services
{
    public class ClienteService : IClienteService
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClienteListarDto>> ListarAsync(ClienteListarDto dto)
        {
            return await _context.sp_Cliente_Listar();
        }

        public async Task<ClienteObtenerPorIDDto?> ObtenerPorIDAsync(ClienteObtenerPorIDDto dto)
        {
            return await _context.sp_Cliente_ObtenerPorID(dto.IdCliente);
        }

        public async Task<ClienteInsertarDto?> InsertarAsync(ClienteInsertarDto dto)
        {
            return await _context.sp_Cliente_Insertar(
                dto.Nombre,
                dto.Apellido,
                dto.Telefono,
                dto.Correo,
                dto.Direccion,
                dto.FechaRegistro
            );
        }

        public async Task<ClienteActualizarDto?> ActualizarAsync(ClienteActualizarDto dto)
        {
            return await _context.sp_Cliente_Actualizar(
                dto.IdCliente,
                dto.Nombre,
                dto.Apellido,
                dto.Telefono,
                dto.Correo,
                dto.Direccion
            );
        }

        public async Task<ClienteEliminarDto?> EliminarAsync(ClienteEliminarDto dto)
        {
            return await _context.sp_Cliente_Eliminar(dto.IdCliente);
        }
    }
}