using Trabalho.Model;

namespace Trabalho.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> BuscaUsuarios();
        Task<Usuario> BuscaUsuario(int id);
        void AdicionaUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);
        void DeletarUsuario(Usuario usuario);
        Task<bool> SaveChangeAsync();

    }
}