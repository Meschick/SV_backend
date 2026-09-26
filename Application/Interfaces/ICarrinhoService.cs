using SV_backend.Domain.Models;

namespace SV_backend.Application.Interfaces
{
    public interface ICarrinhoService
    {
        Task<CarrinhoCompra> ObterCarrinhoAsync(string carrinhoId);
        Task<CarrinhoCompra> AtualizarCarrinhoAsync(CarrinhoCompra carrinho);
        Task<bool> RemoverCarrinhoAsync(string carrinhoId);
    }
}
