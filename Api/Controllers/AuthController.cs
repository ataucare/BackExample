using Api.Core.Interfaces;
using Api.Core.Models.Requests;
using Api.Core.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IServiceAuth serviceAuth;

        public AuthController(IServiceAuth serviceAuth)
        {
            this.serviceAuth = serviceAuth;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="request">Credenciales</param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Los parametros son invalidos");
            }

            return Ok(await serviceAuth.Login(request.Username, request.Password));
        }
    }
}
