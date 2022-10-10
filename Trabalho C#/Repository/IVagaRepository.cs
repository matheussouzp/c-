using Trabalho.Model;

namespace Trabalho.Repository
{
    public interface IVagaRepository
    {
        Task<IEnumerable<Vaga>> BuscaVagas();
        Task<Vaga> BuscaVaga(int id);
        void AdicionaVaga(Vaga vaga);
        void AtualizarVaga(Vaga vaga);
        void DeletarVaga(Vaga vaga);
        Task<bool> SaveChangeAsync();

    }
}