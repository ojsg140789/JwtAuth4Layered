using JwtAuth4Layered.Api.Models;
using JwtAuth4Layered.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuth4Layered.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _authService.AuthenticateAsync(request.Correo, request.Password);

            if (user.Token == null)
            {
                return Unauthorized();
            }

            return Ok(new { Token = user.Token, Id = user.UserId });
        }
    }
}
