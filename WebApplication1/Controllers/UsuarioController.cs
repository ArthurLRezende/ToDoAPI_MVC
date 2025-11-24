using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using WebApplication1.Dados;
using WebApplication1.Models;
using WebApplication1.Requests;
using WebApplication1.Services;
using static WebApplication1.Requests.UsuarioRequest;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly UsuarioService _service;
        public UsuarioController ( UsuarioService userService)
        {
            _service = userService;
        }

        //[HttpGet(Name = "GetUser")]

        //public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        //{
        //    var usuarios = await _dbContext.Usuarios.ToListAsync();
        //    return Ok(usuarios);
        //}

        [HttpPost("AddUsuario")]
        public async Task<IActionResult> CriarUsuario([FromBody] UsuarioRequestPost userReq)
        {
            var resposta = await _service.AdicionarUsuario(userReq);
            
            return Ok(resposta);
        }
    }
}
