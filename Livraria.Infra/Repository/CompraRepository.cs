using System.Collections.Generic;
using System.Threading.Tasks;
using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces;
using Livraria.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Infra.Repository
{
    public class CompraRepository : ICompraRepository
    {
        private readonly LivrariaDbContext _context;

        public CompraRepository(DbContextOptions<LivrariaDbContext> options)
        {
            _context = new LivrariaDbContext(options);
        }

        public async Task<Compra> ObterPorIdAsync(int compraId)
        {
            return await _context.Compras.FindAsync(compraId);
        }

        public async Task<List<Compra>> ObterTodasComprasAsync()
        {
            return await _context.Compras.ToListAsync();
        }

        public async Task<int> AdicionarAsync(Compra compra)
        {
            _context.Compras.Add(compra);
            await _context.SaveChangesAsync();
            return compra.Id;
        }
    }
}
