namespace SV_backend.Application.DTOs
{
    public class ProdutoVariacaoRequest
    {
        public string? SKU { get; set; }
        public string? Tamanho { get; set; }
        public string? Cor { get; set; }
        public int Estoque { get; set; }
    }
}
