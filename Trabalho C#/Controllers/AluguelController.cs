using Microsoft.AspNetCore.Mvc;
using Trabalho.Model;
using Trabalho.Repository;

namespace Trabalho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AluguelController : ControllerBase
    {
        private readonly IAluguelRepository _repository;
        public AluguelController(IAluguelRepository repository)
        {
            _repository = repository;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var alugueis = await _repository.BuscaAlugueis();
            return alugueis.Any()
            ? Ok(alugueis)
            : NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var aluguel = await _repository.BuscaAluguel(id);
            return aluguel != null
            ? Ok(aluguel)
            : NotFound("Aluguel nao encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Aluguel aluguel)
        {
            _repository.AdicionaAluguel(aluguel);
            return await _repository.SaveChangeAsync() ?
            Ok("Aluguel realizado com sucesso")
            : BadRequest("Erro ao salvar o aluguel!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Aluguel aluguel)
        {
            var aluguelBanco = await _repository.BuscaAluguel(id);
            if (aluguelBanco == null) return NotFound("Aluguel não encontrado!");

            aluguelBanco.usuario = aluguel.usuario ?? aluguelBanco.usuario;
            aluguelBanco.vaga = aluguel.vaga ?? aluguelBanco.vaga;
            aluguelBanco.DataAluguel = aluguel.DataAluguel != new DateTime()
            ? aluguel.DataAluguel : aluguelBanco.DataAluguel;

            _repository.AtualizarAluguel(aluguelBanco);

            return await _repository.SaveChangeAsync()
                ? Ok("Aluguel salvo com sucesso")
                : BadRequest("Erro ao salvar usuario");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, Aluguel aluguel)
        {
            var aluguelBanco = await _repository.BuscaAluguel(id);
            if (aluguelBanco == null) return NotFound("Aluguel não encontrado!");
            _repository.DeletarAluguel(aluguelBanco);
            return await _repository.SaveChangeAsync()
                ? Ok("Aluguel deletado com sucesso")
                : BadRequest("Erro ao salvar usuario");
        }
    }
}