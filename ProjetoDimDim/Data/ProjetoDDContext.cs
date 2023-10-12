using Microsoft.EntityFrameworkCore;

namespace ProjetoDimDim.Data
{
    public class ProjetoDDContext : DbContext
    {
        public ProjetoDDContext(DbContextOptions<ProjetoDDContext> options) : base(options)
        {

        }

        public DbSet<ProjetoDimDim.Models.Projeto> Projetos { get; set; }

        public DbSet<ProjetoDimDim.Models.Implantacao> Implantacoes { get; set; }
    }
}
