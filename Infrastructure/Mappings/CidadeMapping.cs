using EcoDenuncia.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EcoDenuncia.Infrastructure.Mappings
{
    public class CidadeMapping : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cidade> builder)
        {
            builder
                .ToTable("TBL_CIDADE");

            builder
                .HasKey(c => c.IdCidade);

            builder.Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasOne(c => c.Estado)
                .WithMany(e => e.Cidades)
                .HasForeignKey(c => c.IdEstado)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
