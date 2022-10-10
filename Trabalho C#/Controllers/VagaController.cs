using Microsoft.AspNetCore.Mvc;
using Trabalho.Model;
using Trabalho.Repository;

namespace Trabalho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VagaController : ControllerBase
    {
        private readonly IVagaRepository _repository;
        public VagaController(IVagaRepository repository)
        {
            _repository = repository;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var vagas = await _repository.BuscaVagas();
            return vagas.Any()
            ? Ok(vagas)
            : NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vaga = await _repository.BuscaVaga(id);
            return vaga != null
            ? Ok(vaga)
            : NotFound("Vaga nao encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Vaga vaga)
        {
            _repository.AdicionaVaga(vaga);
            return await _repository.SaveChangeAsync() ?
            Ok("Vaga realizado com sucesso")
            : BadRequest("Erro ao salvar o vaga!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Vaga vaga)
        {
            var vagaBanco = await _repository.BuscaVaga(id);
            if (vagaBanco == null) return NotFound("Vaga não encontrado!");
            //usava ??
            vagaBanco.Status = vaga.Status;

            _repository.AtualizarVaga(vagaBanco);

            return await _repository.SaveChangeAsync()
                ? Ok("Vaga salvo com sucesso")
                : BadRequest("Erro ao salvar usuario");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, Vaga vaga)
        {
            var vagaBanco = await _repository.BuscaVaga(id);
            if (vagaBanco == null) return NotFound("Vaga não encontrado!");
            _repository.DeletarVaga(vagaBanco);
            return await _repository.SaveChangeAsync()
                ? Ok("Vaga deletado com sucesso")
                : BadRequest("Erro ao salvar usuario");
        }
    }
}