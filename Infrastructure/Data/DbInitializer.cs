using Microsoft.EntityFrameworkCore;
using SV_backend.Domain.Entities;

namespace SV_backend.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // 1. Categorias
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nome = "Camisetas", Slug = "camisetas" },
                new Categoria { Id = 2, Nome = "Calças", Slug = "calcas" },
                new Categoria { Id = 3, Nome = "Casacos & Jaquetas", Slug = "casacos-jaquetas" }
            );

            // IDs fixos para referenciar
            var produto1Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var produto2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");

            // 2. Produtos
            modelBuilder.Entity<Produto>().HasData(
                new Produto
                {
                    Id = produto1Id,
                    CategoriaId = 1,
                    Nome = "Camiseta Oversized Minimalist",
                    PrecoBase = 129.90m,
                    Ativo = true
                },
                new Produto
                {
                    Id = produto2Id,
                    CategoriaId = 2,
                    Nome = "Calça Chino Slim Fit",
                    PrecoBase = 249.90m,
                    Ativo = true
                }
            );

            // 3. Variações / SKUs (Tamanhos P, M, G | Cores Preto, Off-White, Khaki)
            modelBuilder.Entity<ProdutoVariacao>().HasData(
                // Camiseta Oversized Preta
                new ProdutoVariacao { Id = Guid.NewGuid(), ProdutoId = produto1Id, SKU = "CAM-OVR-BLK-P", Tamanho = "P", Cor = "Preto", Estoque = 15 },
                new ProdutoVariacao { Id = Guid.NewGuid(), ProdutoId = produto1Id, SKU = "CAM-OVR-BLK-M", Tamanho = "M", Cor = "Preto", Estoque = 30 },
                new ProdutoVariacao { Id = Guid.NewGuid(), ProdutoId = produto1Id, SKU = "CAM-OVR-BLK-G", Tamanho = "G", Cor = "Preto", Estoque = 20 },

                // Camiseta Oversized Off-White
                new ProdutoVariacao { Id = Guid.NewGuid(), ProdutoId = produto1Id, SKU = "CAM-OVR-WHT-M", Tamanho = "M", Cor = "Off-White", Estoque = 25 },

                // Calça Chino Khaki
                new ProdutoVariacao { Id = Guid.NewGuid(), ProdutoId = produto2Id, SKU = "CAL-CHN-KHK-40", Tamanho = "40", Cor = "Khaki", Estoque = 10 },
                new ProdutoVariacao { Id = Guid.NewGuid(), ProdutoId = produto2Id, SKU = "CAL-CHN-KHK-42", Tamanho = "42", Cor = "Khaki", Estoque = 12 }
            );
        }
    }
}
