namespace Trabalho.Model
{
    public class Aluguel
    {
        public int Id { get; set; }
        public Usuario usuario { get; set; }
        public Vaga vaga { get; set; }
        public DateTime DataAluguel { get; set; }

    }
}