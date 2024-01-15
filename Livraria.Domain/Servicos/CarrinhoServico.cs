using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces;

namespace Livraria.Domain.Servicos
{
    public class CarrinhoServico : ICarrinhoServico
    {
        private readonly ICarrinhoRepository _carrinhoRepository;

        public CarrinhoServico(ICarrinhoRepository carrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
        }

        public async Task<Carrinho> ObterCarrinhoPorIdAsync(int carrinhoId)
        {
            return await _carrinhoRepository.ObterPorIdAsync(carrinhoId);
        }

        public async Task<int> AdicionarCarrinhoAsync(Carrinho carrinho)
        {
            return await _carrinhoRepository.AdicionarAsync(carrinho);
        }

        public async Task AtualizarCarrinhoAsync(Carrinho carrinho)
        {
            await _carrinhoRepository.AtualizarAsync(carrinho);
        }
    }
}

