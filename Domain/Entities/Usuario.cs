using SV_backend.Domain.Enums;

namespace SV_backend.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public string Email{ get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public UserRole UserRole { get; set; }

        // Relacionamento USUARIO > muitos PEDIDOS
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
