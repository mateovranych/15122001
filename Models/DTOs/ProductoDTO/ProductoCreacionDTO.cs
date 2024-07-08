namespace API.Models.DTOs.ProductoDTO
{
	public class ProductoCreacionDTO
	{


		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		public decimal Precio { get; set; }
		public IFormFile? Imagen { get; set; } 
	}
}
