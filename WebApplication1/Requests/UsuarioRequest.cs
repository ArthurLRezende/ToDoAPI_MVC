using System.Globalization;

namespace WebApplication1.Requests
{
    //Padronização da requisição de Usuarios
    public class UsuarioRequest
    {
        public record UsuarioRequestDeleteSpecificUser(int Id);//Com base na função do Usuario, que será passada pelo header, valido a autorização (Service)
        public record UsuarioRequestGetSpecificUser(int Id);//Com base na função do Usuario, que será passada pelo header, valido a autorização (Service)
        public record UsuarioRequestPutSpecificUser(int Id, string Nome, string Email, string Senha, string Descricao);//Com base na função do Usuario, que será passada pelo header, valido a autorização (Service)
        public record UsuarioRequestPut(string Nome, string Email, string Senha, string Descricao);//Proprio usuario
        public record UsuarioRequestPost(string Nome, string Email, string Senha, string Descricao);
    }
}
