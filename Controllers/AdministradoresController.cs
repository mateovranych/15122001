using API.Models;
using API.Models.DTOs.AdministradorDTO;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdministradoresController : ControllerBase
	{
		private readonly UserManager<Users> userManager;
		private readonly SAdministradores sadministradores;
		public AdministradoresController(UserManager<Users> userManager, SAdministradores sAdministradores)
		{
			this.sadministradores = sAdministradores;
			this.userManager = userManager;

		}
		[HttpGet]
		public async Task<ActionResult<List<AdministradorDTO>>> GetAdmins()
		{
			try {
				var admin = await sadministradores.GetAllAdmins();
				return Ok(admin);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<ActionResult<Users>> PostAdministrador([FromBody] AdministradorCreacionDTO administradorCreacionDTO)
		{
			try
			{
				var nuevoAdministrador = await sadministradores.CreateAdministradorAsync(administradorCreacionDTO);

				return Ok(nuevoAdministrador);
			}
			catch
			{
				return StatusCode(500, "Error interno del servidor");
			}
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<AdministradorDTO>> GetAdministradoresById([FromRoute] string id)
		{
			try
			{
				var admin = await sadministradores.GetAdministradoresAsyncId(id);
				return Ok(admin);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteAdminById([FromRoute] string id)
		{
			try 
			{
				await sadministradores.DeleteAdmin(id);
				return NoContent();
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateAdministradores(string id, AdministradorCreacionDTO administradorCreacionDTO)
		{
			try{
				var admin = await sadministradores.UpdateAdmin(id, administradorCreacionDTO);
				return Ok(admin);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
