using System.ComponentModel.DataAnnotations;

namespace API.Models.DTOs.ClienteDTO
{
    public class ClienteDTO
    {
		[Required]
		public string Id { get; set; }

		[Required]
		public string Nombre { get; set; }
		[Required]
		public string Apellido { get; set; }

		[Required]
		public int Dni { get; set; }

		[Required]		
		public string Telefono { get; set; }

		[Required]

		public string Direccion { get; set; }


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
