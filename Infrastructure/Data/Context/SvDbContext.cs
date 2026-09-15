using Microsoft.EntityFrameworkCore;
using SV_backend.Domain.Entities;
using System.Net.Http.Headers;
using System.Reflection;

namespace SV_backend.Infrastructure.Data.Context
{
    // Classe de contexto do Entity Framework para o banco de dados SV.
    // Esta classe herda de DbContext e é responsável por gerenciar a conexão com o banco de dados.
    // Mapea as entidades para as tabelas correspondentes.


    public class SvDbContext : DbContext
    {
        public SvDbContext(DbContextOptions<SvDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Produto> Produtos => Set<Produto>();
        public DbSet<ProdutoVariacao> ProdutoVariacoes => Set<ProdutoVariacao>();
        public DbSet<Pedido> Pedidos => Set<Pedido>();
        public DbSet<PedidoItem> PedidoItems => Set<PedidoItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly
                (Assembly.GetExecutingAssembly());

            DbInitializer.Seed(modelBuilder);
        }

    }
}
