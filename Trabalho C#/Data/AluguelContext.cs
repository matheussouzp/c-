using Microsoft.EntityFrameworkCore;
using Trabalho.Model;
namespace Trabalho.Data
{
    public class AluguelContext : DbContext
    {
        public AluguelContext(DbContextOptions<AluguelContext> options) : base(options)
        {
        }

        public DbSet<Aluguel> Alugueis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var aluguel = modelBuilder.Entity<Aluguel>();
            aluguel.ToTable("tb_aluguel");
            aluguel.HasKey(x => x.Id);
            aluguel.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            aluguel.Property(x => x.usuario.Id).HasColumnName("id_usuario").IsRequired();
            aluguel.Property(x => x.vaga.Id).HasColumnName("id_vaga").IsRequired();
            aluguel.Property(x => x.DataAluguel).HasColumnName("data_aluguel").IsRequired();
        }

    }
}