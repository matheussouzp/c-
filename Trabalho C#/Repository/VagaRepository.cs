using Trabalho.Data;
using Trabalho.Model;
using Microsoft.EntityFrameworkCore;

namespace Trabalho.Repository
{
    public class VagaRepository : IVagaRepository
    {
        private readonly VagaContext _context;
        public VagaRepository(VagaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Vaga>> BuscaVagas()
        {
            return await _context.Vagas.ToListAsync();
        }

        public async Task<Vaga> BuscaVaga(int id)
        {
            return await _context.Vagas.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public void AdicionaVaga(Vaga vaga)
        {
            _context.Add(vaga);
        }

        public void AtualizarVaga(Vaga vaga)
        {
            _context.Update(vaga);
        }



        public void DeletarVaga(Vaga vaga)
        {
            _context.Remove(vaga);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}