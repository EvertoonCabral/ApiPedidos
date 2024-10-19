﻿using ApiControlePedidos.Domain.Entities;
using ApiControlePedidos.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiControlePedidos.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {

        private readonly ApplicationDbContext _context;

        public PedidoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Pedido GetPedidoById(int id)
        {
            return _context.Pedidos
                .Include(p => p.Produtos) // Inclui os produtos relacionados
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Pedido> GetAllPedidos()
        {
            return _context.Pedidos
                .Include(p => p.Produtos) // Inclui os produtos relacionados
                .ToList();
        }

        public async Task CreatePedido(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync(); // Aguarde a conclusão da operação
        }


        public void UpdatePedido(int id, Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            _context.SaveChangesAsync();
        }

        public void DeletePedido(int id)
        {
            var pedido = GetPedidoById(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                _context.SaveChangesAsync();
            }
        }
    }
}
