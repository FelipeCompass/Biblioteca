using Biblioteca.DTOs;
using Biblioteca.Models;

namespace Biblioteca.Interfaces
{
    public interface IPessoaService
    {
        Task<IEnumerable<Pessoa>> ListarTodasAsync();
        Task<Pessoa?> BuscarPorIdAsync(int id);
        Task<Pessoa> CriarAsync(PessoaDTO dto);
        Task<bool> AtualizarAsync(int id, PessoaDTO dto);
        Task<bool> RemoverAsync(int id);
    }

}
