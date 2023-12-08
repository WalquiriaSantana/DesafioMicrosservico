using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces;
using Livraria.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Infra.Repository
{
    public class CompraRepository : ICompraRepository
    {
        private readonly LivrariaDbContext _dbContext; // Substitua 'SeuDbContext' pelo contexto do seu banco de dados

        public CompraRepository(LivrariaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Compra> ObterPorIdAsync(int compraId)
        {
            return await _dbContext.Compras.FindAsync(compraId);
        }

        public async Task<List<Compra>> ObterTodasComprasAsync()
        {
            return await _dbContext.Compras.ToListAsync();
        }

        public async Task<int> AdicionarAsync(Compra compra)
        {
            _dbContext.Compras.Add(compra);
            await _dbContext.SaveChangesAsync();
            return compra.Id;
        }

        // Outros métodos de repositório relacionados a compras
    }
}
