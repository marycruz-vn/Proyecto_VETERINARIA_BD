using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Models;
using System.ClientModel;

namespace Proyecto_VETERINARIA_BD.Interfaces
{
    public interface IClienteService
    {
        Task<List<ClienteListarDto>> ListarAsync(ClienteListarDto dto);
        Task<ClienteObtenerPorIDDto?> ObtenerPorIDAsync(ClienteObtenerPorIDDto dto);
        Task<ClienteInsertarDto?> InsertarAsync(ClienteInsertarDto dto);
        Task<ClienteActualizarDto?> ActualizarAsync(ClienteActualizarDto dto);
        Task<ClienteEliminarDto?> EliminarAsync(ClienteEliminarDto dto);
    }
}