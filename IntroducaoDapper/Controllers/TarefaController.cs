using IntroducaoDapper.Domain;
using IntroducaoDapper.Dto;
using IntroducaoDapper.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IntroducaoDapper.Controllers
{
    [ApiController]
    [Route("tarefas")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _repository;

        public TarefaController(ITarefaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<List<Tarefa>> GetTarefasAsync()
        {
            return await _repository.GetTarefasAsync();
        }

        [HttpGet("{id}")]
        public async Task<Tarefa> GetTarefaByIdAsync([FromRoute] int id)
        {
            return await _repository.GetTarefaByIdAsync(id);
        }

        [HttpGet("contagem")]
        public async Task<TarefaContainer> GetTarefasEContadorAsync()
        {
            return await _repository.GetTarefasEContadorAsync();
        }

        [HttpPost]
        public async Task<int> SaveASync([FromBody] Tarefa novaTarefa)
        {
            return await _repository.SaveAsync(novaTarefa);
        }

        [HttpPut]
        public async Task<int> UpdateTarefaStatusAsync(Tarefa tarefaAtualizada)
        {
            return await _repository.UpdateTarefaStatusAsync(tarefaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<int> DeleteAsync([FromRoute] int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
