using API.Models.DTOs.ProductoDTO;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductosController : ControllerBase
	{
		private readonly SProductos _sproductos;
		public ProductosController(SProductos sProductos)
		{
			_sproductos = sProductos;

		}


		[HttpPost]
		public async Task<IActionResult> CrearProducto([FromForm] ProductoCreacionDTO productoCreacionDTO)
		{
			var producto = await _sproductos.CrearProductosAsync(productoCreacionDTO);
			return Ok(producto);
		}

		[HttpGet]
		public async Task<ActionResult<List<ProductoDTO>>> GetProductos()
		{
			try
			{
				var producto = await _sproductos.GetProductosAsync();
				return Ok(producto);

			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);

			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ProductoDTO>> GetProductosById(int id)
		{
			try{
				var producto = await _sproductos.GetProductosByIdAsync(id);
				if(producto == null)
				{
					throw new Exception("Error al encontrar el producto");
				}

				return Ok(producto);



			}catch (Exception ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> EliminarProducto(int id)
		{
			var result = await _sproductos.BorrarProductoAsync(id);
			if (!result)
			{
				return NotFound();
			}

			return NoContent();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> EditarProductos(int id, [FromForm] ProductoEdicionDTO productoEdicionDTO)
		{
			try{
				var producto = await _sproductos.EditarProductoAsync(id, productoEdicionDTO);
				return Ok(producto);
			}
			catch (Exception ex)
			{
				return BadRequest( new { ex.Message } );
				
			}

		}				

	}
}
