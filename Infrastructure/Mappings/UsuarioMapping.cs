using EcoDenuncia.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoDenuncia.Infrastructure.Mappings
{
    public class UsuarioMapping: IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .ToTable("TBL_USUARIOS");

            builder
                .HasKey(u => u.IdUsuario);

            builder
                .Property(u => u.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(u => u.Email)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(u => u.Senha)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(u => u.TipoUsuario)
                .HasConversion<string>()
                .IsRequired();

            builder
                .HasMany(u => u.Denuncias)
                .WithOne(d => d.Usuario)
                .HasForeignKey(d => d.IdUsuario);
              



        }
    }
}
