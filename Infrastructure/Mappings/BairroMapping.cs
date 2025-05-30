using EcoDenuncia.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EcoDenuncia.Infrastructure.Mappings
{
    public class BairroMapping: IEntityTypeConfiguration<Bairro>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Bairro> builder)
        {
            builder
                .ToTable("TBL_BAIRRO");

            builder
                .HasKey(b => b.IdBairro);

            builder.Property(b => b.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasOne(b => b.Cidade)
                .WithMany(c => c.Bairros)
                .HasForeignKey(b => b.IdCidade)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
