using Microsoft.AspNetCore.Mvc;
using SV_backend.Domain.Interfaces;
using SV_backend.Application.Results;
using SV_backend.API.Extensions;

namespace SV_backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categorias = await _categoriaRepository.ObterTodosAsync();
            return Result<IEnumerable<object>>.Success(categorias).ToActionResult(this);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoria = await _categoriaRepository.ObterPorIdAsync(id);
            if (categoria == null)
                return Result<object>.Fail("Categoria não encontrada.", 404).ToActionResult(this);

            return Result<object>.Success(categoria, 200).ToActionResult(this);
        }
    }
}
