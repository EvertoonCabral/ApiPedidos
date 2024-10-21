using ApiControlePedidos.Domain.Entities;
using ApiControlePedidos.Domain.Repositories;
using ApiControlePedidos.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ControlePedidos.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateProduto(Produto produto)
        {

            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync(); 
        }
        public async Task DeleteProduto(int id)
        {
            var produto = await GetProdutoById(id); 
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync(); 
            }
        }

        public IEnumerable<Produto> GetAllProdutos()
        {
            return _context.Produtos.ToList();
        }


        public async Task<Produto> GetProdutoById(int id)
        {
            return await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task UpdateProduto(int id, Produto produto)
        {
            var existingProduto = await GetProdutoById(id);
            if (existingProduto != null)
            {
                existingProduto.Nome = produto.Nome;
                existingProduto.Preco = produto.Preco;
                existingProduto.Quantidade = produto.Quantidade;

                await _context.SaveChangesAsync(); 
            }
        }






    }
}
