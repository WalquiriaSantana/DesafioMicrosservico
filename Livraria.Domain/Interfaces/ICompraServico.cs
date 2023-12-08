using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Interfaces
{
    public interface ICompraServico
    {
        Task<Compra> ObterCompraPorIdAsync(int compraId);
        Task<int> AdicionarCompraAsync(Compra compra);
    }
}
