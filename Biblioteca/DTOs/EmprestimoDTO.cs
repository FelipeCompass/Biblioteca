namespace Biblioteca.DTOs
{
    public class EmprestimoDTO
    {
        public int LivroId { get; set; }
        public int PessoaId { get; set; }
        public DateTime? DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }
}