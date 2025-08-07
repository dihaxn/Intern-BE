using Microsoft.AspNetCore.Mvc;
using JWT_Test.Services;
using JWT_Test.Models;
using System;

namespace JWT_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            // In a real app, you'd validate the user against a database.
            if (login.Username == "test" && login.Password == "password")
            {
                var token = _jwtService.GenerateToken(login.Username);
                return Ok(new AuthResponse { Token = token, Expiration = DateTime.UtcNow.AddHours(1) });
            }

            return Unauthorized();
        }
    }
}
