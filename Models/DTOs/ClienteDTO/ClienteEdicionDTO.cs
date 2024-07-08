using System.ComponentModel.DataAnnotations;

namespace API.Models.DTOs.ClienteDTO
{
	public class ClienteEdicionDTO
	{
		[Required]
		public string Nombre { get; set; }

		[Required]
		public string Apellido { get; set; }

		[Required]
		public int Dni { get; set; }

		[Required]
		[Phone]
		public string Telefono { get; set; }

		[Required]

		public string Direccion { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		public string? Password { get; set; }
	}
}
