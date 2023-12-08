using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Interfaces
{
    public interface ICompraRepository
    {
        Task<Compra> ObterPorIdAsync(int compraId);
        Task<int> AdicionarAsync(Compra compra);
    }
}
