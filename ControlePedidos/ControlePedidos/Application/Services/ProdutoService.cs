using ApiControlePedidos.Domain.Entities;
using ApiControlePedidos.Domain.Repositories;

namespace ControlePedidos.Application.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> CreateProduto(Produto produto)
        {
            if (produto == null)
            {
                throw new ArgumentNullException(nameof(produto), "Produto não pode ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(produto.Nome))
            {
                throw new ArgumentException("Nome do produto não pode ser vazio.", nameof(produto.Nome));
            }

            await _produtoRepository.CreateProduto(produto);
            return produto;
        }
    }
}
