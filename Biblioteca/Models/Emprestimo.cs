namespace Biblioteca.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }

        public int LivroId { get; set; }
        public int PessoaId { get; set; }

        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }

        // Navegações
        public Livro? Livro { get; set; }
        public Pessoa? Pessoa { get; set; }
    }
}