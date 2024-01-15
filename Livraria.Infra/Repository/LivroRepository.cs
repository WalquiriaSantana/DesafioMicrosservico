using System.Collections.Generic;
using System.Threading.Tasks;
using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces;
using Livraria.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Infra.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly LivrariaDbContext _context;

        public LivroRepository(LivrariaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Livro>> ObterTodosAsync()
        {
            return await _context.Livros.ToListAsync();
        }

        public async Task<Livro> ObterPorIdAsync(int livroId)
        {
            return await _context.Livros.FindAsync(livroId);
        }

        public async Task AdicionarAsync(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Livro livro)
        {
            _context.Livros.Update(livro);
            await _context.SaveChangesAsync();
        }
    }
}
