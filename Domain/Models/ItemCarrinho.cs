namespace SV_backend.Domain.Models
{
    public class ItemCarrinho
    {
        public Guid ProdutoVariacaoId { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public string Tamanho { get; set; } = string.Empty;
        public string Cor { get; set; } = string.Empty;
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }

        public decimal SubTotal => ObterSubTotal();


        public decimal ObterSubTotal()
        {
            return PrecoUnitario * Quantidade;
        }

    }
}
