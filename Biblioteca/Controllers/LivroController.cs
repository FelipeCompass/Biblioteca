using Biblioteca.DTOs;
using Biblioteca.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var livros = await _livroService.ListarTodosAsync();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var livro = await _livroService.BuscarPorIdAsync(id);
            if (livro == null) return NotFound();
            return Ok(livro);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] LivroDto dto)
        {
            var livro = await _livroService.CriarAsync(dto);
            return CreatedAtAction(nameof(BuscarPorId), new { id = livro.Id }, livro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] LivroDto dto)
        {
            var atualizado = await _livroService.AtualizarAsync(id, dto);
            if (!atualizado) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var removido = await _livroService.RemoverAsync(id);
            if (!removido) return NotFound();
            return NoContent();
        }
    }
}
