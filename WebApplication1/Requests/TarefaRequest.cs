using System.Globalization;

namespace WebApplication1.Requests
{
    //Padronização da requisição de tarefa 
    public class TarefaRequest
    {
        public record TarefaRequestPost(string Nome, string Descricao, string Status, DateOnly DataEntrega);
        public record TarefaRequestPut(int Id, string Nome, string Descricao, string Status, DateOnly DataEntrega);
        public record TarefaRequestDelete(int Id);
    }
}
