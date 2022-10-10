using Trabalho.Model;

namespace Trabalho.Repository
{
    public interface IAluguelRepository
    {
        Task<IEnumerable<Aluguel>> BuscaAlugueis();
        Task<Aluguel> BuscaAluguel(int id);
        void AdicionaAluguel(Aluguel aluguel);
        void AtualizarAluguel(Aluguel aluguel);
        void DeletarAluguel(Aluguel aluguel);
        Task<bool> SaveChangeAsync();
    }
}