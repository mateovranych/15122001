using API.Context;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Helpers
{
	public class dataSeeder
	{
		private readonly UserManager<Users> userManager;
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly AppDbContext context;
		public dataSeeder(UserManager<Users> userManager, RoleManager<IdentityRole> roleManager, AppDbContext context)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
			this.context = context;
		}
		public async Task CrearAdmin()
		{
			try
			{
				string email = "admin@gmail.com";
				var admin = await context.Users.Where(a => a.EsAdmin && a.Activo ).FirstOrDefaultAsync();
				if (admin != null)
				{
					return;
				}
				var newAdmin = new Users
				{
					UserName = email,
					Email = email,
					Nombre = "Administrador",
					Apellido = "Administrador",
					EsAdmin = true
				};
				var resultado = await userManager.CreateAsync(newAdmin, "Admin123!");
				if (!resultado.Succeeded)
				{
					throw new Exception("No se pudo crear el usuario administrador");
				}
				var resultadoRol = await userManager.AddToRoleAsync(newAdmin, "admin");
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task CrearRoles()
		{
			string[] roles = { "admin", "cliente" };
			foreach (string role in roles)
			{
				try
				{
					var existeRol = await roleManager.RoleExistsAsync(roleName: role);
					if (!existeRol) await roleManager.CreateAsync(new IdentityRole(roleName: role));
				}
				catch (Exception)
				{
					throw;
				}
			}
		}
	}
}
