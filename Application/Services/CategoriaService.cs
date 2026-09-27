using System;
using SV_backend.Domain.Entities;
using SV_backend.Domain.Interfaces;

namespace SV_backend.Application.Services;

public class CategoriaService : ICategoriaService
{

    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<Categoria?> ObterPorIdAsync(int id)
    {
        return await _categoriaRepository.ObterPorIdAsync(id);
    }

    public Task<IEnumerable<Categoria>> ObterTodosAsync()
    {
        throw new NotImplementedException();
    }
}
