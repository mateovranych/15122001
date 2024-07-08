using API.Models;
using API.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
	public class AppDbContext : IdentityDbContext<Users>
	{
        public AppDbContext(DbContextOptions options):base(options)
        {

            
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }




	}
}
