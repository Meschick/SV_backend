using System;
using SV_backend.Domain.Entities;

namespace SV_backend.Domain.Interfaces;

public interface ICategoriaService
{
    Task<IEnumerable<Categoria>> ObterTodosAsync();
    Task<Categoria?> ObterPorIdAsync(int id);
}
