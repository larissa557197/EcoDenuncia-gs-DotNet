using EcoDenuncia.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoDenuncia.Infrastructure.Mappings
{
    public class AcompanhamentoDenunciaMapping: IEntityTypeConfiguration<AcompanhamentoDenuncia>
    {
        public void Configure(EntityTypeBuilder<AcompanhamentoDenuncia> builder)
        {
            builder
                .ToTable("TBL_ACOMPANHAMENTO_DENUNCIAS");
            
            builder
                .HasKey(a => a.IdAcompanhamento);
            
            builder
                .Property(a => a.Status)
                .HasConversion<string>()
                .IsRequired();

            builder
                .Property(a => a.DataAtualizacao)
                .IsRequired();

            builder
                .Property(a => a.Observacao)
                .HasMaxLength(500);

            builder
                .HasOne(a => a.Denuncia)
                .WithMany()
                .HasForeignKey(a => a.IdDenuncia)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
