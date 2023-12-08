using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Interfaces
{
    public interface ICarrinhoRepository
    {
        Task<Carrinho> ObterPorIdAsync(int carrinhoId);
        Task<int> AdicionarAsync(Carrinho carrinho);
        Task AtualizarAsync(Carrinho carrinho);
    }
}
