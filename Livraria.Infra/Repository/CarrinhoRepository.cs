using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces;
using Livraria.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Infra.Repository
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly LivrariaDbContext _dbContext;

        public CarrinhoRepository(LivrariaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Carrinho> ObterPorIdAsync(int carrinhoId)
        {
            return await _dbContext.Carrinhos
                .Include(c => c.Itens)
                .FirstOrDefaultAsync(c => c.Id == carrinhoId);
        }

        public async Task<int> AdicionarAsync(Carrinho carrinho)
        {
            _dbContext.Carrinhos.Add(carrinho);
            await _dbContext.SaveChangesAsync();
            return carrinho.Id;
        }

        public async Task AtualizarAsync(Carrinho carrinho)
        {
            _dbContext.Carrinhos.Update(carrinho);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Carrinho>> ObterTodosCarrinhosAsync()
        {
            return await _dbContext.Carrinhos.ToListAsync();
        }

        // Outros métodos de repositório relacionados ao carrinho
    }
}
