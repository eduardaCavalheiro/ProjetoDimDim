using ProjetoDimDim.Models;

namespace ProjetoDimDim.Models
{
    public class Implantacao
    {

        public int ImplantacaoId { get; set; }

        public string StatusImplantacao { get; set; }
        public string VersaoDocker { get; set; }

        public string ServicoNuvem { get; set; }

        public Projeto Projeto { get; set; }

        public int ProjetoId { get; set; }

    }
}