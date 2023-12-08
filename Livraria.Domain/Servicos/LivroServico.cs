using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces;

namespace Livraria.Domain.Servicos
{
    public class LivroServico : ILivroServico
    {
        private readonly ILivroRepository _livroRepository;

        public LivroServico(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<List<Livro>> ObterTodosLivrosAsync()
        {
            return await _livroRepository.ObterTodosAsync();
        }

        public async Task<Livro> ObterLivroPorIdAsync(int livroId)
        {
            return await _livroRepository.ObterPorIdAsync(livroId);
        }

    }
}
