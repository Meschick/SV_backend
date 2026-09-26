using AutoMapper;
using SV_backend.Application.DTOs;
using SV_backend.Domain.Entities;
using SV_backend.Domain.Interfaces;
using SV_backend.Application.Results;

namespace SV_backend.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        private readonly ICategoriaRepository _categoriaRepository;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper, ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<Result<ProdutoResponseDto>> ObterProdutoPorIdAsync(Guid id)
        {
            try
            {
                var produto = await _produtoRepository.ObterProdutoPorIdAsync(id);
                if (produto == null) return Result<ProdutoResponseDto>.Fail("Produto não encontrado.", 404);

                var dto = _mapper.Map<ProdutoResponseDto>(produto);
                return Result<ProdutoResponseDto>.Success(dto, 200);
            }
            catch (Exception e)
            {
                return Result<ProdutoResponseDto>.Fail($"Erro ao obter produto: {e.Message}", 500);
            }
        }

        public async Task<Result<IEnumerable<ProdutoResponseDto>>> ObterProdutosAtivosAsync(string? categoriaSlug = null)
        {
            try
            {
                var produtos = await _produtoRepository.ObterProdutosAtivosAsync(categoriaSlug);
                var dtos = produtos.Select(p => _mapper.Map<ProdutoResponseDto>(p));
                return Result<IEnumerable<ProdutoResponseDto>>.Success(dtos, 200);
            }
            catch (Exception e)
            {
                return Result<IEnumerable<ProdutoResponseDto>>.Fail($"Erro ao listar produtos: {e.Message}", 500);
            }
        }

        public async Task<Result<ProdutoResponseDto>> CriarProdutoAsync(CriarProdutoRequest produtoDto)
        {
            try
            {
                // Validação estrutural básica
                var validationErrors = ValidateCriarProdutoRequest(produtoDto).ToList();
                if (validationErrors.Any())
                    return Result<ProdutoResponseDto>.Fail(validationErrors, 400);

                // Validação: categoria existe
                var categoria = await _categoriaRepository.ObterPorIdAsync(produtoDto.CategoriaId);
                if (categoria == null)
                    return Result<ProdutoResponseDto>.Fail("Categoria não encontrada.", 400);

                // Validação básica nas variações (SKUs não vazios e sem duplicatas no payload)
                if (produtoDto.Variacoes != null)
                {
                    var skus = produtoDto.Variacoes.Select(v => v.SKU).ToList();
                    if (skus.Any(string.IsNullOrWhiteSpace))
                        return Result<ProdutoResponseDto>.Fail("Uma ou mais variações possuem SKU inválido.", 400);
                    if (skus.Count != skus.Distinct().Count())
                        return Result<ProdutoResponseDto>.Fail("SKUs duplicados nas variações do produto.", 400);
                    // Verificar SKUs existentes no banco
                    var skusExistentes = await _produtoRepository.ObterSkusExistentesAsync(skus);
                    if (skusExistentes != null && skusExistentes.Any())
                    {
                        var list = string.Join(", ", skusExistentes);
                        return Result<ProdutoResponseDto>.Fail($"Os SKUs já existem no sistema: {list}", 400);
                    }
                }

                var produto = _mapper.Map<Produto>(produtoDto);

                // Garantir ligação com a categoria existente
                produto.CategoriaId = produtoDto.CategoriaId;

                _produtoRepository.AdicionarNovoProduto(produto);

                await _produtoRepository.SalvarAlteracoesAsync();

                var dto = _mapper.Map<ProdutoResponseDto>(produto);
                return Result<ProdutoResponseDto>.Success(dto, statusCode: 201);
            }
            catch (Exception e)
            {
                return Result<ProdutoResponseDto>.Fail($"Erro ao criar produto: {e.Message}", 500);
            }
        }

        private IEnumerable<string> ValidateCriarProdutoRequest(CriarProdutoRequest produtoDto)
        {
            if (produtoDto == null)
                return new[] { "Payload inválido." };

            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(produtoDto.Nome))
                errors.Add("Nome é obrigatório.");

            if (produtoDto.PrecoBase <= 0)
                errors.Add("PrecoBase deve ser maior que zero.");

            if (produtoDto.CategoriaId <= 0)
                errors.Add("CategoriaId inválido.");

            if (produtoDto.Variacoes != null)
            {
                foreach (var v in produtoDto.Variacoes)
                {
                    if (string.IsNullOrWhiteSpace(v.SKU))
                        errors.Add("SKU da variação é obrigatório.");
                    if (v.Estoque < 0)
                        errors.Add("Estoque da variação não pode ser negativo.");
                }
            }

            return errors;
        }
    }
}
