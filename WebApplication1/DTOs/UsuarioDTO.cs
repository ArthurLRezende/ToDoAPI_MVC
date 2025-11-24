using System.Globalization;

namespace WebApplication1.DTOs
{
    //Define o que será enviado como response na api
    public class UsuarioDTO
    {
        public record UsuarioAPIDTO(int Id, string Nome, string Email, string Senha);
    }
}
