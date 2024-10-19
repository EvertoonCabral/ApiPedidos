using ApiControlePedidos.Domain.Entities;

namespace ApiControlePedidos.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Produto GetProdutoById(int id);
        IEnumerable<Produto> GetAllProdutos();
        void DeleteProduto(int id);
        void UpdateProduto(int id, Produto produto);
        Task CreateProduto(Produto produto);


    }
}
