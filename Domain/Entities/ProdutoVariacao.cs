
namespace SV_backend.Domain.Entities
{
    public class ProdutoVariacao
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProdutoId { get; set; }
        public string SKU { get; set; } = string.Empty;
        public string Tamanho { get; set; } = string.Empty;
        public string Cor { get; set; } = string.Empty;
        public int Estoque { get; set; }

        // Relacionamento
        public Produto Produto { get; set; } = null!;
    }
}
