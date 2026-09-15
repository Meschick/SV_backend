using SV_backend.Domain.Enums;

namespace SV_backend.Domain.Entities
{
    public class Pedido
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UsuarioId { get; set; }
        public PedidoStatus Status { get; set; } = PedidoStatus.Criado;
        public decimal Total { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        // Relacionamentos
        public Usuario Usuario { get; set; } = null!;
        public ICollection<PedidoItem> Itens { get; set; } = new List<PedidoItem>();
    }
}
