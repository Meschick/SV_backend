using SV_backend.Domain.Entities;

namespace SV_backend.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<Categoria?> ObterPorIdAsync(int id);
        Task<IEnumerable<Categoria>> ObterTodosAsync();
    }
}
