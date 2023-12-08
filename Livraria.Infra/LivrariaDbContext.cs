using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Infrastructure.Contexts
{
    public class LivrariaDbContext : DbContext
    {
        public LivrariaDbContext(DbContextOptions<LivrariaDbContext> options) : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Adicione configurações de entidade ou relacionamento aqui, se necessário.
            // Exemplo:
            // modelBuilder.Entity<Livro>().Property(l => l.Titulo).HasMaxLength(100);
        }
    }
}
