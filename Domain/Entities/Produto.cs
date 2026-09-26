using System.Globalization;

namespace SV_backend.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int CategoriaId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal PrecoBase { get; set; }
        public bool Ativo { get; set; } = true;


        // Relacionamento PRODUTO > 1 CATEGORIA
        // Relacionamento PRODUTO > muitos VARIACOES
        public Categoria Categoria { get; set; } = null!;
        public ICollection<ProdutoVariacao> Variacoes { get; set; } = new List<ProdutoVariacao>();
    }
 
}
