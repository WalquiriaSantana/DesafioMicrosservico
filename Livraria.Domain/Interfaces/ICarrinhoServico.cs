using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Interfaces
{
    public interface ICarrinhoServico
    {
        Task<Carrinho> ObterCarrinhoPorIdAsync(int carrinhoId);
        Task<int> AdicionarCarrinhoAsync(Carrinho carrinho);
        Task AtualizarCarrinhoAsync(Carrinho carrinho);
    }
}
