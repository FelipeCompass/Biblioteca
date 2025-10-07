using Biblioteca.Configurations;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }

        //public DbSet<Livro> Livros { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        //public DbSet<Emprestimo> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaConfiguration());
           //modelBuilder.ApplyConfiguration(new LivroConfiguration());
            //modelBuilder.ApplyConfiguration(new EmprestimoConfiguration());
        }
    }
}