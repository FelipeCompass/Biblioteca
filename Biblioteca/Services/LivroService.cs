using Biblioteca.Data;
using Biblioteca.DTOs;
using Biblioteca.Interfaces;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services
{
    public class LivroService : ILivroService
    {
        private readonly BibliotecaContext _context;

        public LivroService(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<List<Livro>> ListarTodosAsync()
        {
            return await _context.Livros.ToListAsync();
        }

        public async Task<Livro?> BuscarPorIdAsync(int id)
        {
            return await _context.Livros.FindAsync(id);
        }

        public async Task<Livro> CriarAsync(LivroDto dto)
        {
            var livro = new Livro
            {
                Titulo = dto.Titulo,
                Autor = dto.Autor,
                Genero = dto.Genero,
                AnoPublicacao = dto.AnoPublicacao,
                Disponivel = dto.Disponivel
            };

            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
            return livro;
        }

        public async Task<bool> AtualizarAsync(int id, LivroDto dto)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null) return false;

            livro.Titulo = dto.Titulo;
            livro.Autor = dto.Autor;
            livro.Genero = dto.Genero;
            livro.AnoPublicacao = dto.AnoPublicacao;
            livro.Disponivel = dto.Disponivel;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null) return false;

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}