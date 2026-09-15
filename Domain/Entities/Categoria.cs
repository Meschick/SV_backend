namespace SV_backend.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;

        // Relacionamento CATEGORIA > muitos PRODUTOS
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();

    }
}
