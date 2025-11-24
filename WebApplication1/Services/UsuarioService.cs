using WebApplication1.Dados;
using WebApplication1.Models;
using static WebApplication1.Requests.UsuarioRequest;
using static WebApplication1.DTOs.UsuarioDTO;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Services
{
    public class UsuarioService
    {
        private readonly AppDBContext _context;
        public UsuarioService(AppDBContext context) 
        {
            _context = context;
        }

        public async Task<UsuarioAPIDTO> AdicionarUsuario(UsuarioRequestPost usuarioreq) 
        {
            var usuario = new Usuario
            {
                Name = usuarioreq.Nome,
                Description = usuarioreq.Descricao,
                Email = usuarioreq.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(usuarioreq.Senha)

            };
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return new UsuarioAPIDTO(usuario.Id, usuario.Name, usuario.Email, usuario.Password);
        }

        public async Task<Usuario?> BuscarPorEmail(string email)
        => await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
    }
}
