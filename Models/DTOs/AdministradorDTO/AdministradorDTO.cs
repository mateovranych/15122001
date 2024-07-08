using System.ComponentModel.DataAnnotations;

namespace API.Models.DTOs.AdministradorDTO
{
	public class AdministradorDTO
	{
		[Required]
		public string Id { get; set; }

		[Required]
		public string Nombre { get; set; }
		[Required]
		public string Apellido { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public DateTime FechaCreacion { get; set; }

		[Required]
		public bool EsAdmin { get; set; }

		[Required]
		public bool Activo { get; set; }


	}
}
