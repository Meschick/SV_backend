using Microsoft.EntityFrameworkCore;
using SV_backend.Domain.Entities;

namespace SV_backend.Infrastructure.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.PrecoBase)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(p => p.Ativo)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasOne( p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
