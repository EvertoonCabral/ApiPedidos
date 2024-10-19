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
        public void DeleteProduto(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> GetAllProdutos()
        {
            throw new NotImplementedException();
        }

        public Produto GetProdutoById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduto(int id, Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
