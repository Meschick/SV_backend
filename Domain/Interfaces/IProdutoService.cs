using SV_backend.Application.DTOs;
using SV_backend.Domain.Entities;
using SV_backend.Application.Results;

namespace SV_backend.Domain.Interfaces
{
    public interface IProdutoService
    {
        Task<Result<ProdutoResponseDto>> CriarProdutoAsync(CriarProdutoRequest produtoDto);
        Task<Result<ProdutoResponseDto>> ObterProdutoPorIdAsync(Guid id);
        Task<Result<IEnumerable<ProdutoResponseDto>>> ObterProdutosAtivosAsync(string? categoriaSlug = null);
    }
}
