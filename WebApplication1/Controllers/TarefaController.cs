using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Requests;
using WebApplication1.Services;
using static WebApplication1.Requests.TarefaRequest;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : Controller
    {
        private readonly TarefaService _service;
        public TarefaController(TarefaService tarefaService) 
        {
            _service = tarefaService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CriaTarefa(TarefaRequestPost tarefaReq)
        {
            var userId = int.Parse(User.Claims.First(c => c.Type == "id").Value);
            var tarefa = await _service.AdicionarTarefa(tarefaReq, userId);
            return Ok(tarefa);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> AtualizarTarefa(TarefaRequestPut tarefaReq) 
        {
            var userId = int.Parse(User.Claims.First(c => c.Type == "id").Value);
            var tarefaDTO = await _service.AtualizarTarefa(tarefaReq, userId);
            if (tarefaDTO == null) { return Unauthorized("Tarefa não encontrada"); }
            return Ok(tarefaDTO);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> BuscarTarefas()
        {
            var userId = int.Parse(User.Claims.First(c => c.Type == "id").Value);
            var lista = await _service.BuscarTarefas(userId);
            if (lista is null)
                return Ok("A lista de tarefas esta vazia");

            return Ok(lista);
        }
    }
}
