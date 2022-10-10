using Microsoft.AspNetCore.Mvc;
using Trabalho.Model;
using Trabalho.Repository;

namespace Trabalho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _repository.BuscaUsuarios();
            return usuarios.Any()
            ? Ok(usuarios)
            : NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _repository.BuscaUsuario(id);
            return usuario != null
            ? Ok(usuario)
            : NotFound("Usuario nao encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            _repository.AdicionaUsuario(usuario);
            return await _repository.SaveChangeAsync() ?
            Ok("usuario add com sucesso")
            : BadRequest("Erro ao salvar usuario");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuario usuario)
        {
            var usuarioBanco = await _repository.BuscaUsuario(id);
            if (usuarioBanco == null) return NotFound("Usuario não encontrado!");

            usuarioBanco.Nome = usuario.Nome ?? usuarioBanco.Nome;
            usuarioBanco.DataNascimento = usuario.DataNascimento != new DateTime()
            ? usuario.DataNascimento : usuarioBanco.DataNascimento;
            _repository.AtualizarUsuario(usuarioBanco);

            return await _repository.SaveChangeAsync()
                ? Ok("usuario add com sucesso")
                : BadRequest("Erro ao salvar usuario");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, Usuario usuario)
        {
            var usuarioBanco = await _repository.BuscaUsuario(id);
            if (usuarioBanco == null) return NotFound("Usuario não encontrado!");
            _repository.DeletarUsuario(usuarioBanco);
            return await _repository.SaveChangeAsync()
                ? Ok("usuario deletado com sucesso")
                : BadRequest("Erro ao salvar usuario");
        }
    }
}