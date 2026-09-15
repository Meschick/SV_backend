namespace SV_backend.Domain.Entities
{
    public class PedidoItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PedidoId { get; set; }
        public Guid ProdutoVariacaoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; } // Preço congelado no ato da compra

        // Relacionamentos
        public Pedido Pedido { get; set; } = null!;
        public ProdutoVariacao ProdutoVariacao { get; set; } = null!;
    }
}
