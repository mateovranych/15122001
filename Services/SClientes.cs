using API.Context;
using API.Migrations;
using API.Models;
using API.Models.Auth;
using API.Models.DTOs.ClienteDTO;
using API.Models.DTOs.ProductoDTO;
using API.Models.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
	public class SClientes
	{
        private readonly IMapper mapper;
        private readonly UserManager<Users> _userManager;
        private readonly AppDbContext _context;
        private readonly SToken _sToken;


        public SClientes(IMapper mapper, UserManager<Users> userManager, AppDbContext context, SToken sToken)
        {
            this.mapper = mapper;
            this._userManager = userManager;
            this._context = context;
            this._sToken = sToken;              
        }

        public async Task<RtaAuth> CreateClientes ( ClienteCreacionDTO clienteCreacionDTO)
        {
            try{
                var nuevoCliente = mapper.Map<Users>(clienteCreacionDTO);
                nuevoCliente.UserName = clienteCreacionDTO.Email;
                nuevoCliente.FechaCreacion = DateTime.UtcNow;
                nuevoCliente.EsAdmin = false;

                var resultado = await _userManager.CreateAsync(nuevoCliente, clienteCreacionDTO.Password);

                if(!resultado.Succeeded)
                {
                    throw new Exception("El cliente no se pudo crear");
                }

                var resultadoRol = await _userManager.AddToRoleAsync(nuevoCliente, "cliente");

                var respuestaAutenticacion = await _sToken.GenerateToken(nuevoCliente.Email, 1);

                return respuestaAutenticacion;

            }
            catch (Exception)
            {

                throw;
            }
        }

		public async Task<List<ClienteDTO>> GetClientesActivosAsync()
		{
			try
			{
				var clientes = await _context.Users.Where(user => user.EsAdmin == false && user.Activo == true).ToListAsync();

				return mapper.Map<List<ClienteDTO>>(clientes);
			}
			catch (Exception)
			{
				throw;
			}
		}

        public async Task<ClienteDTO> GetClientesByIdAsync(string id)
        {
           
                var clientes = await _context.Users.FindAsync(id);
                if(clientes == null)
                {
                    throw new Exception("Cliente no encontrado");
                }
            
		

            return mapper.Map<ClienteDTO>(clientes);			
		}
        
        public async Task<ClienteDTO> EditClientesAsync(string id, ClienteEdicionDTO clienteEdicionDTO)
        {
			var clientes = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
			if (clientes == null)
				throw new Exception("No existe un administrador con el id especificado");
			

            clientes.Nombre = clienteEdicionDTO.Nombre;
            clientes.Apellido = clienteEdicionDTO.Apellido;
            clientes.Dni = clienteEdicionDTO.Dni;   
            clientes.Direccion = clienteEdicionDTO.Direccion;
            clientes.Telefono = clienteEdicionDTO.Telefono;
            clientes.Email = clienteEdicionDTO.Email;
            
			
			await _context.SaveChangesAsync();

			return mapper.Map<ClienteDTO>(clientes);
		}

		public async Task DeleteClient(string id)
        {
			try
			{
				var cliente = await _context.Users.FirstOrDefaultAsync(x => x.Id == id && x.EsAdmin == false && x.Activo == true);
				if (cliente == null)
					throw new Exception("No existe el administrador con el id especificado");
			
				_context.Users.Remove(cliente);
				await _context.SaveChangesAsync();
			}
			catch (Exception)
			{
				throw;
			}
			                        
        }
    }
}
