using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using static WebApplication1.Requests.LoginRequest;

//Controller voltada para autenticão do usuario
namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticaController : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly AutenticaService _autenticaService;

        public AutenticaController (UsuarioService usuarioService, AutenticaService autenticaService)
        {
            _usuarioService = usuarioService;
            _autenticaService = autenticaService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Logar(LoginRequestAuth req)
        {
            var usuario = await _usuarioService.BuscarPorEmail(req.Email);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(req.Senha, usuario.Password))
            { return Unauthorized("As credenciais não conferem"); }

            var token = _autenticaService.GerarToken(usuario);// gerar token não esta assincrono, por isso deixei sem o await
            
            return Ok(token);

        }

    }
}
