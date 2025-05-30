using EcoDenuncia.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EcoDenuncia.Infrastructure.Mappings
{
    public class OrgaoPublicoMapping: IEntityTypeConfiguration<OrgaoPublico>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OrgaoPublico> builder)
        {
            builder
                .ToTable("TBL_ORGAO_PUBLICO");

            builder
                .HasKey(o => o.IdOrgaoPublico);

            builder
                .Property(o => o.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder
                .Property(o => o.AreaAtuacao)
                .HasMaxLength(8)
                .IsRequired();
        }
    }
}
