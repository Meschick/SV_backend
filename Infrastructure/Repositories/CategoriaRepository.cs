using Microsoft.EntityFrameworkCore;
using SV_backend.Domain.Entities;
using SV_backend.Domain.Interfaces;
using SV_backend.Infrastructure.Data.Context;

namespace SV_backend.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly SvDbContext _context;

        public CategoriaRepository(SvDbContext context)
        {
            _context = context;
        }

        public async Task<Categoria?> ObterPorIdAsync(int id)
        {
            return await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Categoria>> ObterTodosAsync()
        {
            return await _context.Categorias.ToListAsync();
        }
    }
}
