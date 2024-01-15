using System.Collections.Generic;
using System.Threading.Tasks;
using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces;
using Livraria.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Infra.Repository
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly LivrariaDbContext _context;

        public CarrinhoRepository(DbContextOptions<LivrariaDbContext> options)
        {
            _context = new LivrariaDbContext(options);
        }

        public async Task<Carrinho> ObterPorIdAsync(int carrinhoId)
        {
            return await _context.Carrinhos
                .Include(c => c.Itens)
                .FirstOrDefaultAsync(c => c.Id == carrinhoId);
        }

        public async Task<int> AdicionarAsync(Carrinho carrinho)
        {
            _context.Carrinhos.Add(carrinho);
            await _context.SaveChangesAsync();
            return carrinho.Id;
        }

        public async Task AtualizarAsync(Carrinho carrinho)
        {
            _context.Carrinhos.Update(carrinho);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Carrinho>> ObterTodosCarrinhosAsync()
        {
            return await _context.Carrinhos.ToListAsync();
        }
    }
}
