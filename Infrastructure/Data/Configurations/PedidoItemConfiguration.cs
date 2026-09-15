using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SV_backend.Domain.Entities;

namespace SV_backend.Infrastructure.Data.Configurations
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItems");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Quantidade)
                .IsRequired();

            builder.Property(i => i.PrecoUnitario)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.HasOne(i => i.Pedido)
                .WithMany(p => p.Itens)
                .HasForeignKey(i => i.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.ProdutoVariacao)
                .WithMany()
                .HasForeignKey(i => i.ProdutoVariacaoId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
