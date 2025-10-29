using System.Text.Json.Serialization;

namespace Biblioteca.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public int AnoPublicacao { get; set; }
        public bool Disponivel { get; set; }

        // Navegação para empréstimos
        [JsonIgnore]
        public ICollection<Emprestimo>? Emprestimos { get; set; }
    }

}
