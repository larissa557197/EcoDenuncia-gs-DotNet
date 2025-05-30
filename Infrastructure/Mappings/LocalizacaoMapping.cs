using EcoDenuncia.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EcoDenuncia.Infrastructure.Mappings
{
    public class LocalizacaoMapping: IEntityTypeConfiguration<Localizacao>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Localizacao> builder)
        {
            builder
                .ToTable("TBL_LOCALIZACAO");
            builder
                .HasKey(l => l.IdLocalização);

            builder
                .Property(l => l.Logradouro)
                .HasMaxLength(100)
                .IsRequired();

            builder 
                .Property(l => l.Numero)
                .HasMaxLength(10)
                .IsRequired();

            builder
                .Property(l => l.Complemento)
                .HasMaxLength(50);

            builder
                .Property(l => l.Cep)
                .HasMaxLength(8)
                .IsRequired();



            builder
                .HasOne(l => l.Bairro)
                .WithMany(b => b.Localizacoes)
                .HasForeignKey(l => l.IdBairro)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
