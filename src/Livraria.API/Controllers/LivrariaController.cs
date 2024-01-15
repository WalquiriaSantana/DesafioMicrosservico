using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class LivrosController : ControllerBase
{
    private readonly ILivroRepository _livroRepository;
    private readonly ICarrinhoRepository _carrinhoRepository;

    public LivrosController(ILivroRepository livroRepository, ICarrinhoRepository carrinhoRepository)
    {
        _livroRepository = livroRepository;
        _carrinhoRepository = carrinhoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
    {
        var livros = await _livroRepository.ObterTodosAsync();
        return Ok(livros);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Livro>> GetLivro(int id)
    {
        var livro = await _livroRepository.ObterPorIdAsync(id);

        if (livro == null)
        {
            return NotFound();
        }

        return livro;
    }

    [HttpPost]
    public async Task<ActionResult<Livro>> PostLivro(Livro livro)
    {
        await _livroRepository.AdicionarAsync(livro);

        return CreatedAtAction("GetLivro", new { id = livro.Id }, livro);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutLivro(int id, Livro livro)
    {
        if (id != livro.Id)
        {
            return BadRequest();
        }

        var livroExistente = await _livroRepository.ObterPorIdAsync(id);
        if (livroExistente == null)
        {
            return NotFound();
        }

        livroExistente.Nome = livro.Nome;
        livroExistente.Valor = livro.Valor;
        livroExistente.Imagem = livro.Imagem;
        livroExistente.Quantidade = livro.Quantidade;

        await _livroRepository.AtualizarAsync(livroExistente);

        return NoContent();
    }

    private async Task<bool> LivroExistsAsync(int id)
    {
        var livro = await _livroRepository.ObterPorIdAsync(id);
        return livro != null;
    }
}
