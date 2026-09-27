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
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categorias = await _categoriaService.ObterTodosAsync();
            return Result<IEnumerable<object>>.Success(categorias).ToActionResult(this);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoria = await _categoriaService.ObterPorIdAsync(id);
            return Result<object>.Success(categoria, 200).ToActionResult(this);
        }
    }
}
