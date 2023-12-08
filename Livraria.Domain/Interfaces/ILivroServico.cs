using Livraria.Domain.Entities;

namespace Livraria.Domain.Interfaces
{
    public interface ILivroServico
    {
        Task<List<Livro>> ObterTodosLivrosAsync();
        Task<Livro> ObterLivroPorIdAsync(int livroId);
    }
}
