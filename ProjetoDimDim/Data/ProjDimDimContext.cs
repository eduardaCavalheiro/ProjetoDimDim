using Microsoft.EntityFrameworkCore;

namespace ProjDimDim.Data
{
    public class ProjDimDimContext : DbContext
    {
        public ProjDimDimContext(DbContextOptions<ProjDimDimContext> options) : base(options)
        {
        }

        public DbSet<ProjetoDimDim.Models.Projeto> Projetos { get; set; } = default!;

        public DbSet<ProjetoDimDim.Models.Implantacao> Implantacoes { get; set; } = default!;
    }
}
