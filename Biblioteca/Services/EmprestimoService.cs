using Biblioteca.Data;
using Biblioteca.DTOs;
using Biblioteca.Interfaces;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly BibliotecaContext _context;

        public EmprestimoService(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Emprestimo>> ListarTodosAsync() =>
            await _context.Emprestimos
                .Include(e => e.Livro)
                .Include(e => e.Pessoa)
                .ToListAsync();

        public async Task<Emprestimo?> BuscarPorIdAsync(int id) =>
            await _context.Emprestimos
                .Include(e => e.Livro)
                .Include(e => e.Pessoa)
                .FirstOrDefaultAsync(e => e.Id == id);

        public async Task<Emprestimo> CriarAsync(EmprestimoDTO dto)
        {
            var livro = await _context.Livros.FindAsync(dto.LivroId);
            if (livro == null)
                throw new InvalidOperationException("Livro não encontrado.");

            if (!livro.Disponivel)
                throw new InvalidOperationException("Livro não está disponível para empréstimo.");

            var emprestimo = new Emprestimo
            {
                LivroId = dto.LivroId,
                PessoaId = dto.PessoaId,
                DataEmprestimo = dto.DataEmprestimo ?? DateTime.UtcNow,
                DataDevolucao = dto.DataDevolucao
            };

            _context.Emprestimos.Add(emprestimo);
            livro.Disponivel = false;
            _context.Livros.Update(livro);

            await _context.SaveChangesAsync();
            return emprestimo;
        }

        public async Task<bool> AtualizarAsync(int id, EmprestimoDTO dto)
        {
            var emprestimo = await _context.Emprestimos.FindAsync(id);
            if (emprestimo == null) return false;

            emprestimo.LivroId = dto.LivroId;
            emprestimo.PessoaId = dto.PessoaId;
            emprestimo.DataEmprestimo = dto.DataEmprestimo ?? emprestimo.DataEmprestimo;
            emprestimo.DataDevolucao = dto.DataDevolucao;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var emprestimo = await _context.Emprestimos.FindAsync(id);
            if (emprestimo == null) return false;

            // opcional: marcar livro como disponível se devolvido
            var livro = await _context.Livros.FindAsync(emprestimo.LivroId);
            if (livro != null) livro.Disponivel = true;

            _context.Emprestimos.Remove(emprestimo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}