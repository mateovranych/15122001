using API.Models;
using API.Models.DTOs.ClienteDTO;
using API.Models.DTOs.ProductoDTO;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClientesController : ControllerBase
	{
        private readonly SToken sToken;
        private readonly SClientes sClientes;
        private readonly UserManager<Users> userManager;
        public ClientesController(SClientes sClientes, SToken sToken, UserManager<Users> userManager)
        {
            this.userManager = userManager;
            this.sToken = sToken;
            this.sClientes = sClientes;            
        }


        [HttpGet]
        public async Task<ActionResult<List<ClienteDTO>>> GetClientes()
        {
            try{
                var clientes = await sClientes.GetClientesActivosAsync();
                return Ok(clientes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ClienteDTO>> GetClientesById([FromRoute]string id)
        {
            try
            {
                var clientes = await sClientes.GetClientesByIdAsync(id);
                if(clientes == null)
                {
                    throw new Exception("No se pudo encontrar el cliente");
                }
                return Ok(clientes);
            }
            catch(Exception ex)
            {
				return BadRequest(new { message = ex.Message });
			}
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClients([FromRoute]string id)
        {
            try
            {
                await sClientes.DeleteClient(id);
				return NoContent();

			}
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult>EditarClientes(string id, ClienteEdicionDTO clienteEdicionDTO)
        {
            try
            {
                var cliente = await sClientes.EditClientesAsync(id, clienteEdicionDTO);
                return Ok(cliente);

            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
