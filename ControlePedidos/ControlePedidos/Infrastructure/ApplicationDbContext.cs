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



    }
}
