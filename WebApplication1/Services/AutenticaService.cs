using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebApplication1.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace WebApplication1.Services
{
    public class AutenticaService
    {
        private readonly IConfiguration _config;

        public AutenticaService(IConfiguration config)
        {
            _config = config;
        }

        public string GerarToken(Usuario user)
        {
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]!);

            var token = new JwtSecurityToken
                (
                claims: new[] {
                    new System.Security.Claims.Claim("id", user.Id.ToString())
                },
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256
                )
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}


