using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Infrastructure.Contexts
{
    public class LivrariaDbContext : DbContext
    {
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<Carrinho.ItemCarrinho> ItensCarrinho { get; set; }


        public LivrariaDbContext(DbContextOptions<LivrariaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("livraria");
            modelBuilder.Entity<Livro>().ToTable("Produtos");

            modelBuilder.Entity<Carrinho.ItemCarrinho>()
                .HasKey(ic => new { ic.LivroId, ic.CarrinhoId }); 

            modelBuilder.Entity<Carrinho.ItemCarrinho>()
                .HasOne(ic => ic.Carrinho)
                .WithMany(c => c.Itens)
                .HasForeignKey(ic => ic.CarrinhoId);

            modelBuilder.Entity<Carrinho.ItemCarrinho>()
                .ToTable("ItensCarrinho"); 

            modelBuilder.Entity<Carrinho.ItemCarrinho>()
                .HasOne(ic => ic.Livro)
                .WithMany()
                .HasForeignKey(ic => ic.LivroId);

        }
    }
}
