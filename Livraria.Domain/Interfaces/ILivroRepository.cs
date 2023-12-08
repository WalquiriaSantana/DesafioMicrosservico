using Livraria.Domain.Entities;

namespace Livraria.Domain.Interfaces
{
    public interface ILivroRepository
    {
        Task<List<Livro>> ObterTodosAsync();
        Task<Livro> ObterPorIdAsync(int livroId);
    }
}
