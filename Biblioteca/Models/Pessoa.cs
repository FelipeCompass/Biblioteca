using System.Text.Json.Serialization;

namespace Biblioteca.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;

        // Navegação para empréstimos
        [JsonIgnore]
        public ICollection<Emprestimo>? Emprestimos { get; set; }
    }
}


