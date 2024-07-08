using API.Context;
using API.Models;
using API.Models.Auth;
using API.Models.DTOs.AdministradorDTO;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
	public class SAdministradores
	{
		private readonly IMapper mapper;
		private readonly UserManager<Users> userManager;
		private readonly AppDbContext context;
		private readonly SToken sToken;

        public SAdministradores(IMapper mapper, UserManager<Users> userManager, SToken sToken, AppDbContext context)
        {
			this.sToken = sToken;
			this.mapper = mapper;	
			this.userManager = userManager;
			this.context = context;
            
        }

		public async Task<RtaAuth> CreateAdministradorAsync (AdministradorCreacionDTO administradorCreacionDTO)
		{
			try
			{
			var newAdmin = mapper.Map<Users>(administradorCreacionDTO);
			newAdmin.UserName = administradorCreacionDTO.Email;
			newAdmin.FechaCreacion = DateTime.UtcNow;
			newAdmin.EsAdmin = true;

			var result = await userManager.CreateAsync(newAdmin, administradorCreacionDTO.Password);
			if (!result.Succeeded)
				throw new Exception();

			var resultrole = await userManager.AddToRoleAsync(newAdmin, "admin");
			var rtaAuth = await sToken.GenerateToken(newAdmin.Email, 1);

			return rtaAuth;

			}
			catch (Exception ex)
			{
				Console.WriteLine( "Error" + ex.Message);
				return null;
			}
		}
		public async Task<AdministradorDTO> GetAdministradoresAsyncId (string id)
		{
			try
			{
				var admin = context.Users.Where(x => x.EsAdmin == true && x.Activo == true).FirstOrDefault(x => x.Id == id);
				if(admin == null)
					throw new Exception();
				return mapper.Map<AdministradorDTO>(admin);				
			}
			catch (Exception)
			{
				throw;
			}
		}
		public async Task<List<AdministradorDTO>> GetAllAdmins()
		{
			try
			{
				var admin = await context.Users.Where(x => x.EsAdmin == true && x.Activo == true).ToListAsync();
				return mapper.Map<List<AdministradorDTO>>(admin);

			}
			catch (Exception)
			{

				throw;
			}
		}
		public async Task DeleteAdmin(string id)
		{
			try{
				var admin = await context.Users.FirstOrDefaultAsync(x=>x.Id == id && x.EsAdmin == true && x.Activo == true) ;
				if(admin == null) 
					throw new Exception("No existe el administrador con el id especificado");
				var cantidadAdministradores = await context.Users.Where(a=>a.EsAdmin == true && a.Activo ==true).ToListAsync();
				if(cantidadAdministradores.Count < 1)
				{
					throw new Exception("No se puede eliminar el último administrador");
				}
				context.Users.Remove(admin);
				await context.SaveChangesAsync();
			}
			catch (Exception)
			{
				throw;
			}
		}
		public async Task<AdministradorDTO> UpdateAdmin(string id, AdministradorCreacionDTO administradorCreacionDTO)
		{			
			try{
				var admin = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
				if (admin == null)
					throw new Exception("No existe un administrador con el id especificado");
				var adminNameExist = await context.Users.AnyAsync(x=>x.Nombre == administradorCreacionDTO.Nombre && x.Id == id);
				if(adminNameExist)
				{
					throw new Exception("Ya existe un administrador con ese nombre");
				}
				var adminEmailExist = await context.Users.AnyAsync(x=>x.Email == administradorCreacionDTO.Email && x.Id ==id);
				if(adminEmailExist)
				{
					throw new Exception("Ya existe un administrador con ese email");
				}
				admin.Nombre = administradorCreacionDTO.Nombre;
				admin.Apellido = administradorCreacionDTO.Apellido;
				admin.Email = administradorCreacionDTO.Email;

				await context.SaveChangesAsync();

				return mapper.Map<AdministradorDTO>(admin);	

			}
			catch (Exception)
			{

				throw;
			}
		}

    }
}
