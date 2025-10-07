using Biblioteca.Data;
using Biblioteca.DTOs;
using Biblioteca.Interfaces;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly BibliotecaContext _context;

        public PessoaService(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pessoa>> ListarTodasAsync() =>
            await _context.Pessoas.ToListAsync();

        public async Task<Pessoa?> BuscarPorIdAsync(int id) =>
            await _context.Pessoas.FindAsync(id);

        public async Task<Pessoa> CriarAsync(PessoaDTO dto)
        {
            var pessoa = new Pessoa
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Telefone = dto.Telefone
            };
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }

        public async Task<bool> AtualizarAsync(int id, PessoaDTO dto)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa == null) return false;

            pessoa.Nome = dto.Nome;
            pessoa.Email = dto.Email;
            pessoa.Telefone = dto.Telefone;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa == null) return false;

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
