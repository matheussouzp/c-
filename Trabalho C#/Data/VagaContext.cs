using Microsoft.EntityFrameworkCore;
using Trabalho.Model;


namespace Trabalho.Data
{
    public class VagaContext : DbContext
    {
        public VagaContext(DbContextOptions<VagaContext> options) : base(options)
        {
        }
        public DbSet<Vaga> Vagas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var vaga = modelBuilder.Entity<Vaga>();
            vaga.ToTable("tb_vaga");
            vaga.HasKey(x => x.Id);
            vaga.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            vaga.Property(x => x.Status).HasColumnName("status").IsRequired();

        }
    }
}