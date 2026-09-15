namespace SV_backend.Domain.Models
{
    public class CarrinhoCompra
    {
        public string Id { get; set; } = string.Empty;
        public List<ItemCarrinho> Items { get; set; } = new();
        public decimal Total => Items.Sum(item => item.SubTotal);
        public CarrinhoCompra() { }

        public CarrinhoCompra(string id) {
            Id = id;
        }
    }
}
