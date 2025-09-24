
using Haui.Application.Dtos.LoginDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Haui.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("Login")]

        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            if (loginDto.UserName != "admin" || loginDto.Password != "12345678")
            {
                return Unauthorized("Invalid User or Password");
            }

            var tokenHandel = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]);

            var tokenDesscriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, loginDto.UserName),
                    new Claim(ClaimTypes.Role, "Admin")
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _config["JwtSettings:Issuer"],
                Audience = _config["JwtSettings:Audience"],
                SigningCredentials = new SigningCredentials( new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)               
            };

            var token = tokenHandel.CreateToken(tokenDesscriptor);
            var tokenString = tokenHandel.WriteToken(token);

            return Ok(new { Token = tokenString });
        }
    }
   
}
