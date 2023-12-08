using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Entities
{
    public class Compra
    {
        public int Id { get; set; }
        public Carrinho Carrinho { get; set; }
        public DateTime DataCompra { get; set; }
        public decimal ValorTotal { get; set; }
        public string Status { get; set; }
    }
}
