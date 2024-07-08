//using API.Context;
//using API.Models.DTOs.ClienteDTO;
//using API.Models.Entities;
//using AutoMapper;
//using Microsoft.EntityFrameworkCore;

//namespace API.Repo
//{
//	public class ClienteRepo : IClienteRepo
//	{
//		private readonly AppDbContext _db; //importo la bd
//		private IMapper _mapper; //importo el mapper

//        public ClienteRepo(AppDbContext db, IMapper mapper)
//        {
//			_mapper = mapper;	
//			_db = db;
//        }
//        public async Task<ClienteDTO> CreateUpdate(ClienteDTO clienteDTO)
//		{
//			Cliente cliente = _mapper.Map<ClienteDTO, Cliente>(clienteDTO);
//			if(cliente.id > 0 ) 
//			{
//				_db.Clientes.Update(cliente);
//			}
//			else
//			{
//				_db.Clientes.AddAsync(cliente);
//			}

//			await _db.SaveChangesAsync(); //Guardo los cambios en la bd
//			return _mapper.Map<Cliente, ClienteDTO>(cliente); //Hago el mapeo de la bd

//		}

//		public async Task<bool> DeleteCliente(int id)
//		{
//			try
//			{
//				Cliente cliente = await _db.Clientes.FindAsync(id); //Busca el cliente por el id
//				if (cliente == null) //Si el cliente es igual a null retorna falso
//				{
//					return false;
//				}
//				_db.Clientes.Remove(cliente); //Remueve el cliente 
//				await _db.SaveChangesAsync(); //Guarda los cambios en la bd

//				return true;

//			}
//			catch (Exception)
//			{

//				return false;
//			}
//		}

//		public async Task<ClienteDTO> GetClienteByID(int id)
//		{
//			Cliente cliente = await _db.Clientes.FindAsync(id); //hacemos una variable de tipo cliente, y después una consulta que lo busque por el id

//			return _mapper.Map<ClienteDTO>(cliente); //devuelvo el cliente
//		}



//		public async Task<List<ClienteDTO>> GetClientes()
//		{
//			List<Cliente> lista = await _db.Clientes.ToListAsync(); //Hago una lista de cliente
			 
//			return _mapper.Map<List<ClienteDTO>>(lista); //Mapeamos, y la lista se convierte en una lista dto
//		}
//	}
//}
