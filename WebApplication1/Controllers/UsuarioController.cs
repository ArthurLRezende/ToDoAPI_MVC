using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

        [HttpPost("AddUsuario")]
        public async Task<IActionResult> CriarUsuario([FromBody] UsuarioRequestPost userReq)
        {
            var resposta = await _service.AdicionarUsuario(userReq);
            
            return Ok(resposta);
        }

        [HttpGet("GetUsers")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PegarUsuarios()
        {
            var resposta = await _service.BuscarUsuarios();
            return Ok(resposta);
        }
    }
}
