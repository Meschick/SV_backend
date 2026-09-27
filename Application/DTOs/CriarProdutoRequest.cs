namespace SV_backend.Application.DTOs
{
    public class CriarProdutoRequest
    {
        public string? Nome { get; set; }
        public decimal PrecoBase { get; set; }
        public int CategoriaId { get; set; }
        public IEnumerable<ProdutoVariacaoRequest>? Variacoes { get; set; }
    }
}
