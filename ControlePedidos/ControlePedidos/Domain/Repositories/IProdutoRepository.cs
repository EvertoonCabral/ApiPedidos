using ApiControlePedidos.Domain.Entities;

namespace ApiControlePedidos.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto> GetProdutoById(int id);
        Task CreateProduto(Produto produto);
        Task UpdateProduto(int id, Produto produto);
        Task DeleteProduto(int id);
        IEnumerable<Produto> GetAllProdutos();
    }

}
