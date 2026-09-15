namespace SV_backend.Domain.Enums
{
    public enum PedidoStatus
    {
        Criado = 1,
        AguardandoPagamento = 2,
        Pago = 3,
        EmPreparacao = 4,
        Enviado = 5,
        Entregue = 6,
        Cancelado = 7
    }
}
