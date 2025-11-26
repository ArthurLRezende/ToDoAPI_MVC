using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebApplication1.Models;
using System.Security.Claims;

//Classe com metodo relacionado a autenticação e autorização
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

            //Adicionando identificadores para gerar o token 
            var claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role) 
            };

            var token = new JwtSecurityToken(
                claims: claims,
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