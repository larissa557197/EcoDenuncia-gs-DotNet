using EcoDenuncia.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EcoDenuncia.Infrastructure.Mappings
{
    public class EstadoMapping: IEntityTypeConfiguration<Estado>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Estado> builder)
        {
            builder
                .ToTable("TBL_ESTADO");

            builder
                .HasKey(e => e.IdEstado);

            builder
                .Property(e => e.Nome)
                .HasMaxLength(100)
                .IsRequired();
            builder
                .Property(e => e.Uf)
                .HasMaxLength(2)
                .IsRequired();

            builder
                .HasOne(e => e.Cidades)
                .WithMany()
                .HasForeignKey(c => c.IdEstado)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
