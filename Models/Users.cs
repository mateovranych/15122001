using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
	public class Users : IdentityUser
	{

		[Required]
		public string Nombre { get; set; }

		[Required]
		public string Apellido { get; set; }

		public int? Dni { get; set; }

		public string? Telefono { get; set; }

		public string? Direccion { get; set; }

		public bool Activo { get; set; } = true;

		[Required]
		public bool EsAdmin { get; set; }

		[Required]
		[Column(TypeName = "date")]
		public DateTime FechaCreacion { get; set; }

		[Column(TypeName = "date")]
		public DateTime? FechaEliminacion { get; set; }

	}
}
