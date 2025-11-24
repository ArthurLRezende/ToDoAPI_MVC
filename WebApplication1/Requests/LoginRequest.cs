using System.Globalization;

namespace WebApplication1.Requests
{
    //Padronização da requisição de login
    public class LoginRequest
    {
        public record LoginRequestAuth(string Email, string Senha);
    }
}
