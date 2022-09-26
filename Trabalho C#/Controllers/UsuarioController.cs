
using Microsoft.AspNetCore.Mvc;
using Trabalho.Model;

namespace Trabalho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private static List<Usuario> Usuarios()
        {
            return new List<Usuario>{
                new Usuario{Nome = "Matheus", Id = 1, DataNascimento = new DateTime(2001, 11, 30)}
            };
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Usuarios());
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            var usuarios = Usuarios();
            usuarios.Add(usuario);
            return Ok(usuarios);
        }
    }
}