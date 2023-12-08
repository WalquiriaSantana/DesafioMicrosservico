using Livraria.Domain.Entities;
using Livraria.Infrastructure.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class LivrosController : ControllerBase
{
    private readonly LivrariaDbContext _dbContext;

    public LivrosController(LivrariaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
    {
        return await _dbContext.Livros.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Livro>> GetLivro(int id)
    {
        var livro = await _dbContext.Livros.FindAsync(id);

        if (livro == null)
        {
            return NotFound();
        }

        return livro;
    }

    [HttpPost]
    public async Task<ActionResult<Livro>> PostLivro(Livro livro)
    {
        _dbContext.Livros.Add(livro);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction("GetLivro", new { id = livro.Id }, livro);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutLivro(int id, Livro livro)
    {
        if (id != livro.Id)
        {
            return BadRequest();
        }

        _dbContext.Entry(livro).State = EntityState.Modified;

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LivroExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    private bool LivroExists(int id)
    {
        return _dbContext.Livros.Any(e => e.Id == id);
    }
}
