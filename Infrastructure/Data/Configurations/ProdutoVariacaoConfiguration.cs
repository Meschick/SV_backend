using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SV_backend.Domain.Entities;

namespace SV_backend.Infrastructure.Data.Configurations
{
    public class ProdutoVariacaoConfiguration : IEntityTypeConfiguration<ProdutoVariacao>
    {
        public void Configure(EntityTypeBuilder<ProdutoVariacao> builder)
        {
            builder.ToTable("ProdutoVariacoes");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.SKU)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.HasIndex(p => p.SKU)
                .IsUnique();

            builder.Property(p => p.Cor)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.Property(p => p.Tamanho)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("varchar(10)");

            builder.Property(p => p.Estoque)
                .IsRequired();

            builder.HasOne(p => p.Produto)
                .WithMany(p => p.Variacoes)
                .HasForeignKey(p => p.ProdutoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
