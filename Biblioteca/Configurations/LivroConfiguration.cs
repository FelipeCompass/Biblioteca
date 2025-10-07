namespace Biblioteca.Configurations
{
    using global::Biblioteca.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    namespace Biblioteca.Configurations
    {
        public class LivroConfiguration : IEntityTypeConfiguration<Livro>
        {
            public void Configure(EntityTypeBuilder<Livro> builder)
            {
                builder.ToTable("Livros");

                builder.Property(l => l.Titulo)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(l => l.Autor)
                    .HasMaxLength(100);

                builder.Property(l => l.Genero)
                    .HasMaxLength(50);
            }
        }
    }
}
