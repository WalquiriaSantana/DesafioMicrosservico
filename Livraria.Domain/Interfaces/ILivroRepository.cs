using Livraria.Domain.Entities;

namespace Livraria.Domain.Interfaces
{
    public interface ILivroRepository
    {
        Task<List<Livro>> ObterTodosAsync();
        Task<Livro> ObterPorIdAsync(int livroId);
        Task AdicionarAsync(Livro livro);
        Task AtualizarAsync(Livro livro);
    }
}
