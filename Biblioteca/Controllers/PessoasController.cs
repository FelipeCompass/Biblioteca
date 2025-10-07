using Biblioteca.DTOs;
using Biblioteca.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoasController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await _pessoaService.ListarTodasAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var pessoa = await _pessoaService.BuscarPorIdAsync(id);
            return pessoa == null ? NotFound() : Ok(pessoa);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PessoaDTO dto)
        {
            var pessoa = await _pessoaService.CriarAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = pessoa.Id }, pessoa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PessoaDTO dto)
        {
            var atualizado = await _pessoaService.AtualizarAsync(id, dto);
            return atualizado ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _pessoaService.RemoverAsync(id);
            return removido ? NoContent() : NotFound();
        }
    }

}
