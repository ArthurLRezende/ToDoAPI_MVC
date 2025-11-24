using System.Globalization;

namespace WebApplication1.DTOs
{
    //Define o que será enviado como response no endpoint de Tarefa
    public class TarefaDTO
    {
        public record TarefaAPIDTO(int Id, string Nome, string Descricao, string Status, DateOnly DataPrazo );
    }
}
