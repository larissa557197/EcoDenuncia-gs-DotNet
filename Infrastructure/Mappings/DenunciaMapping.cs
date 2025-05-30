using EcoDenuncia.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoDenuncia.Infrastructure.Mappings
{
    public class DenunciaMapping: IEntityTypeConfiguration<Denuncia>
    {
        public void Configure(EntityTypeBuilder<Denuncia> builder)
        {
            builder
                .ToTable("TBL_DENUNCIAS");

            builder
                .HasKey(d => d.IdDenuncia);

            builder
                .Property(d => d.Descricao)
                .HasMaxLength(250)
                .IsRequired();

            builder
                .Property(d => d.DataHora)
                .IsRequired();

            builder
                .HasOne(d => d.Usuario)
                .WithMany(u => u.Denuncias)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(d => d.Localizacao)
                .WithMany()
                .HasForeignKey(d => d.IdLocalizacao)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(d => d.OrgaoPublico)
                .WithMany()
                .HasForeignKey(d => d.IdOrgaoPublico)
                .OnDelete(DeleteBehavior.Cascade);



        }
    
    
    }
}
