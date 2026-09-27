using SV_backend.Domain.Entities;

namespace SV_backend.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ObterProdutosAtivosAsync(string? categoriaSlug = null);
        Task<Produto?> ObterProdutoPorIdAsync(Guid id);
        Task AdicionarNovoProduto(Produto produto);
        Task<IEnumerable<string>> ObterSkusExistentesAsync(IEnumerable<string> skus);
        void RemoverProduto(Produto produto);
        Task SalvarAlteracoesAsync();
    }
}
