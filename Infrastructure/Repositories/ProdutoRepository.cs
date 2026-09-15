using Microsoft.EntityFrameworkCore;
using SV_backend.Domain.Entities;
using SV_backend.Domain.Interfaces;
using SV_backend.Infrastructure.Data.Context;

namespace SV_backend.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly SvDbContext _context;

        public ProdutoRepository(SvDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarNovoProduto(Produto produto)
        {
            await _context.AddAsync(produto);
        }

        public async Task<Produto?> ObterProdutoPorIdAsync(Guid id)
        {
           return await _context.Produtos
              .Include(p => p.categoria)
              .Include(p => p.Variacoes)
              .FirstOrDefaultAsync(p => p.Id == id);

        }

        public async Task<IEnumerable<Produto>> ObterProdutosAtivosAsync(string? categoriaSlug = null)
        {
            var query = _context.Produtos
                .Include(p => p.categoria)
                .Include(p => p.Variacoes)
                .Where(p => p.Ativo);

            if (!string.IsNullOrEmpty(categoriaSlug))
            {
                query = query.Where(p => p.categoria.Slug == categoriaSlug);
            }

            return await query.ToListAsync();
        }

        public async Task SalvarAlteracoesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
