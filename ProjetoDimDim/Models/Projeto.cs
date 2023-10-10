namespace ProjetoDimDim.Models
{
    public class Projeto
    {
        public int ProjetoId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int Dificuldade { get; set; }

      public ICollection<Implantacao> implantacoes { get; set; } = new List<Implantacao>();
    }
}