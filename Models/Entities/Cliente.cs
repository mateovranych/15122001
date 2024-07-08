using System.ComponentModel.DataAnnotations;

namespace API.Models.Entities
{
    public class Cliente 
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string? nombre { get; set; }
		[Required]
		public string? apellido { get; set; }
		[Required]
		public string? nombreUsuario { get; set; }
		[Required]
		public string? email { get; set; }
		[Required]
		public string? telefono { get; set; }
		[Required]
		public DateTime datoCreacion { get; set; }
		[Required]
		public DateTime datoModificado { get; set; }

    }
}
