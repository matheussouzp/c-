using Trabalho.Data;
using Trabalho.Model;
using Microsoft.EntityFrameworkCore;

namespace Trabalho.Repository
{
    public class AluguelRepository : IAluguelRepository
    {
        private readonly AluguelContext _context;
        public AluguelRepository(AluguelContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Aluguel>> BuscaAlugueis()
        {
            return await _context.Alugueis.ToListAsync();
        }

        public async Task<Aluguel> BuscaAluguel(int id)
        {
            return await _context.Alugueis.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public void AdicionaAluguel(Aluguel aluguel)
        {
            _context.Add(aluguel);
        }

        public void AtualizarAluguel(Aluguel aluguel)
        {
            _context.Update(aluguel);
        }



        public void DeletarAluguel(Aluguel aluguel)
        {
            _context.Remove(aluguel);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}