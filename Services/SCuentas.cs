using API.Context;
using API.Models;
using API.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;

namespace API.Services
{
	public class SCuentas
	{
        private readonly SignInManager<Users> signInManager;
        private readonly AppDbContext context;
        public SCuentas(SignInManager<Users> signInManager, AppDbContext context)
        {
            this.signInManager = signInManager;
            this.context = context;    
        }

        public async Task<bool> LoginAsync(Credentials credentials)
        {
            try
            {
                var cliente = await context.Users.FirstOrDefaultAsync(u => u.Email == credentials.Email && u.Activo == true);
                if(cliente == null)
                return false;

                var result = await signInManager.PasswordSignInAsync(userName: credentials.Email,
                                                                      password: credentials.Password,
                                                                      isPersistent: false,
                                                                      lockoutOnFailure: false);

                return result.Succeeded;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
