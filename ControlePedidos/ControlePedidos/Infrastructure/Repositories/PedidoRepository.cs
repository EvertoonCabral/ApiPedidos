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

        public async Task<Pedido> GetPedidoById(int pedidoId)
        {
            return await _context.Pedidos
                                 .Include(p => p.Produtos) // Inclui os produtos no pedido
                                 .FirstOrDefaultAsync(p => p.Id == pedidoId);
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

        public async Task AddProdutoToPedido(int pedidoId, Produto produto)
        {
            var pedido = await GetPedidoById(pedidoId);

            if (pedido == null)
                throw new Exception("Pedido não encontrado.");

            pedido.AdicionarProduto(produto); // Utilize o método da entidade Pedido para adicionar o produto.
            await _context.SaveChangesAsync();
        }


        public async Task UpdatePedido(int id, Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }


        public async Task DeletePedido(int id)
        {
            var pedido = await GetPedidoById(id); // Aguardar a tarefa para obter o Pedido
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync(); // Aguardar a conclusão da operação
            }
        }

    }
}
