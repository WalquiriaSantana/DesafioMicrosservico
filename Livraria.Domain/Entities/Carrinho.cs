using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Entities
{
    public class Carrinho
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public int IdCompra { get; set; }
        public int Quantidade { get; set; }
        public List<ItemCarrinho> Itens { get; set; } = new List<ItemCarrinho>();

        public class ItemCarrinho
        {
            public int LivroId { get; set; }
            public int Quantidade { get; set; }
        }
    }
}
