using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Servicos
{
    public class CompraServico : ICompraServico
    {
        private readonly ICompraRepository _compraRepository;

        public CompraServico(ICompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }

        public async Task<Compra> ObterCompraPorIdAsync(int compraId)
        {
            return await _compraRepository.ObterPorIdAsync(compraId);
        }

        public async Task<int> AdicionarCompraAsync(Compra compra)
        {
            // Lógica adicional, validações, etc., podem ser adicionadas aqui antes de chamar o repositório
            return await _compraRepository.AdicionarAsync(compra);
        }

    }
}

