using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Configurations
{
    public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable("Emprestimos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.DataEmprestimo)
                .IsRequired();

            builder.Property(e => e.DataDevolucao)
                .IsRequired(false);

            builder.HasIndex(e => e.LivroId);
            builder.HasIndex(e => e.PessoaId);

            builder
                .HasOne(e => e.Livro)
                .WithMany(l => l.Emprestimos)
                .HasForeignKey(e => e.LivroId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Pessoa)
                .WithMany(p => p.Emprestimos)
                .HasForeignKey(e => e.PessoaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}