using API.Models.DTOs.ClienteDTO;
using System.Collections.Generic;

namespace API.Repo
{
	public interface IClienteRepo
	{
		Task<List<ClienteDTO>> GetClientes();
		Task<ClienteDTO> GetClienteByID(int id);
		Task<ClienteDTO> CreateUpdate(ClienteDTO clienteDTO);
		Task<bool> DeleteCliente(string id);
	}
}
