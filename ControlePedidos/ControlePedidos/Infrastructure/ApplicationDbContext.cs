using Microsoft.EntityFrameworkCore;
using ApiControlePedidos.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ApiControlePedidos.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Especificando o tipo SQL para a coluna Preco pq se nao da pau na migration
            modelBuilder.Entity<Produto>()
                .Property(p => p.Preco)
                .HasColumnType("decimal(18,2)");
        }


    }
}
