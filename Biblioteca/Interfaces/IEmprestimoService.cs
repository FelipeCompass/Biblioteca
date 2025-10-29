namespace Biblioteca.Interfaces
{
    using Biblioteca.Models;
    using Biblioteca.DTOs;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEmprestimoService
    {
        Task<IEnumerable<Emprestimo>> ListarTodosAsync();
        Task<Emprestimo?> BuscarPorIdAsync(int id);
        Task<Emprestimo> CriarAsync(EmprestimoDTO dto);
        Task<bool> AtualizarAsync(int id, EmprestimoDTO dto);
        Task<bool> RemoverAsync(int id);
    }
}