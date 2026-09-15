using Microsoft.Extensions.Caching.Distributed;
using SV_backend.Domain.Interfaces;
using SV_backend.Domain.Models;
using System.Text.Json;

namespace SV_backend.Infrastructure.Services
{
    public class RedisCarrinhoService : ICarrinhoService
    {
        private readonly IDistributedCache _cache;
        private static readonly TimeSpan CartTtl = TimeSpan.FromHours(24);

        public RedisCarrinhoService(IDistributedCache cache) 
        {

            _cache = cache;
        }
        public async Task<CarrinhoCompra> ObterCarrinhoAsync(string carrinhoId)
        {
            var data = await _cache.GetStringAsync(GetRedisKey(carrinhoId));

            if (string.IsNullOrEmpty(data)) 
            {
                return new CarrinhoCompra(carrinhoId);
            }

            return JsonSerializer.Deserialize<CarrinhoCompra>(data);
        }

        public async Task<CarrinhoCompra> AtualizarCarrinhoAsync(CarrinhoCompra carrinho)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = CartTtl
            };

            var serializedCarrinho = JsonSerializer.Serialize(carrinho);

            await _cache.SetStringAsync(GetRedisKey(carrinho.Id), serializedCarrinho, options);

            return await ObterCarrinhoAsync(carrinho.Id) ?? carrinho;
        }

        public async Task<bool> RemoverCarrinhoAsync(string carrinhoId)
        {
            await _cache.RemoveAsync(GetRedisKey(carrinhoId));
            return true;
        }
        private static string GetRedisKey(string carrinhoId) => $"carrinho:{carrinhoId}";
    }
}
