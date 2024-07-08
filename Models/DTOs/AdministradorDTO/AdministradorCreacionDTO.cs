using System.ComponentModel.DataAnnotations;

namespace API.Models.DTOs.AdministradorDTO
{
	public class AdministradorCreacionDTO
	{
		[Required]
		public string Nombre { get; set; }

		[Required]
		public string Apellido { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }

	}
}

