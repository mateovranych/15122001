using API.Models.Auth;
using API.Models.DTOs.ClienteDTO;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CuentasController : ControllerBase
	{
        private readonly SCuentas sCuentas;
        private readonly SToken sToken;
        private readonly SClientes sClientes;

        public CuentasController(SCuentas sCuentas, SToken sToken, SClientes sClientes)
        {      
            this.sCuentas = sCuentas;
            this.sToken = sToken;
            this.sClientes = sClientes; 
        }

        [HttpPost("login")]
        public async Task<ActionResult<RtaAuth>>Login(Credentials credentials)
        {
            var result = await sCuentas.LoginAsync(credentials);
            if(!result)
            return NotFound("Credenciales inválidas");
            var generarTokenLogin = await sToken.GenerateToken(email: credentials.Email, diasExp: 1);
            return Ok(generarTokenLogin);
        }


        [HttpPost("registro")]

        public async Task<ActionResult<RtaAuth>> RegistroCliente([FromBody] ClienteCreacionDTO clienteCreacionDTO)
        {
            try
            {
                var respuestaAutenticacion = await sClientes.CreateClientes(clienteCreacionDTO);

                return respuestaAutenticacion;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
