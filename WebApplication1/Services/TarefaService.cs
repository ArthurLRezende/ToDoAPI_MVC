using Microsoft.EntityFrameworkCore;
using System.Formats.Tar;
using System.Net.NetworkInformation;
using WebApplication1.Dados;
using WebApplication1.Models;
using static WebApplication1.DTOs.TarefaDTO;
using static WebApplication1.Requests.TarefaRequest;

//Classe com metodos voltado para opeções na entidade de tarefas 
namespace WebApplication1.Services
{
    public class TarefaService
    {
        public readonly AppDBContext _context;
        public TarefaService(AppDBContext context) 
        {
            _context = context;
        }

        public async Task<TarefaAPIDTO> AdicionarTarefa(TarefaRequestPost tarefaReq, int idUsuario) 
        {
            var tarefa= new Tarefa 
            { 
                Name = tarefaReq.Nome,
                Description = tarefaReq.Descricao,
                Status = tarefaReq.Status,
                DateValue = tarefaReq.DataEntrega,
                Id_Usuario = idUsuario
            };
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return new TarefaAPIDTO(tarefa.Id, tarefa.Name, tarefa.Description, tarefa.Status, tarefa.DateValue);
        }

        public async Task<Tarefa?> BuscarTarefaID (int id) 
        {
            var tarefa = await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id);  
            if(tarefa == null)
            { return null; }
            return tarefa;
        }

        public async Task<TarefaAPIDTO> AtualizarTarefa(TarefaRequestPut tarefaReq, int idUsuario) 
        {
            var tarefa = await BuscarTarefaID(tarefaReq.Id);

            if (tarefa == null)
                throw new Exception("Tarefa não encontrada.");

            if (tarefa.Id_Usuario != idUsuario)
                throw new UnauthorizedAccessException("Usuário invalido.");

                tarefa.Name = tarefaReq.Nome;
                tarefa.Description = tarefaReq.Descricao;
                tarefa.Status = tarefaReq.Status;
                tarefa.DateValue = tarefaReq.DataEntrega;

                _context.Tarefas.Update(tarefa);
                await _context.SaveChangesAsync();

                return new TarefaAPIDTO(tarefa.Id, tarefa.Name, tarefa.Description, tarefa.Status, tarefa.DateValue);

        }

        public async Task<IEnumerable<TarefaAPIDTO>> BuscarTarefas(int idUsuario)
        {
            var lista = await _context.Tarefas
           .Where(t => t.Id_Usuario == idUsuario)
           .ToListAsync();

            var listaDTO = new List<TarefaAPIDTO>();

            foreach (var tarefa in lista)
            {
                var tarefaDTO = new TarefaAPIDTO
                (
                    tarefa.Id,
                    tarefa.Name,
                    tarefa.Description,
                    tarefa.Status,
                    tarefa.DateValue  // coloque aqui o nome real da propriedade
                );

                listaDTO.Add(tarefaDTO);
            }

            return listaDTO;

        }

        public async Task<TarefaAPIDTO> DeletarTarefa(int idTarefa, int idUsuario)
        {
            var tarefa = await _context.Tarefas.FirstAsync(t => t.Id == idTarefa);

            if (tarefa == null)
                throw new Exception("Tarefa não encontrada.");

            if (tarefa.Id_Usuario != idUsuario)
                throw new UnauthorizedAccessException("Usuario invalido.");

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            
            return new TarefaAPIDTO(tarefa.Id, tarefa.Name, tarefa.Description, tarefa.Status, tarefa.DateValue);
        }
    }
}
