using ApiControlePedidos.Domain.Entities;
using ApiControlePedidos.Domain.Repositories;
using ApiControlePedidos.Infrastructure.Repositories;
using ControlePedidos.Infrastructure.Repositories;

namespace ControlePedidos.Application.Services
{
    public class ProdutoService
    {

        private readonly IProdutoRepository _produtoRepository;

         public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> CreateProduto(Produto p1)
        {
            var produto = new Produto();
            await _produtoRepository.CreateProduto(produto);
            return produto;
        }

    }
}
