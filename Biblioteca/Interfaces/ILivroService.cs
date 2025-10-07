using Biblioteca.DTOs;
using Biblioteca.Models;

namespace Biblioteca.Interfaces
{
    public interface ILivroService
    {
        Task<List<Livro>> ListarTodosAsync();
        Task<Livro?> BuscarPorIdAsync(int id);
        Task<Livro> CriarAsync(LivroDto dto);
        Task<bool> AtualizarAsync(int id, LivroDto dto);
        Task<bool> RemoverAsync(int id);
    }

}
