using EcoDenuncia.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;


namespace EcoDenuncia.Infrastructure.Contexts
{
    public class EcoDenunciaContext(DbContextOptions<EcoDenunciaContext> options) : DbContext(options)
    {

        public DbSet<Denuncia> Denuncias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<OrgaoPublico> OrgaosPublicos { get; set; }
        public DbSet<Localizacao> Localizacoes { get; set; }
        public DbSet<Bairro> Bairros { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EcoDenunciaContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
