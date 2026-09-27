using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using SV_backend.Application.DTOs;
using SV_backend.Domain.Interfaces;
using SV_backend.Application.Results;
using SV_backend.API.Extensions;

namespace SV_backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarProduto([FromBody] CriarProdutoRequest produtoDto)
        {
            var produtoResult = await _produtoService.CriarProdutoAsync(produtoDto);
            return produtoResult.ToActionResult(this);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _produtoService.ObterProdutoPorIdAsync(id);
            return result.ToActionResult(this);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? categoriaSlug = null)
        {
            var result = await _produtoService.ObterProdutosAtivosAsync(categoriaSlug);
            return result.ToActionResult(this);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _produtoService.RemoverProdutoAsync(id);
            return result.ToActionResult(this);
        }
    }
}
