namespace SV_backend.Application.DTOs
{
    public class ProdutoResponseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal PrecoBase { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
        public IEnumerable<ProdutoVariacaoResponseDto>? Variacoes { get; set; }
    }
}
