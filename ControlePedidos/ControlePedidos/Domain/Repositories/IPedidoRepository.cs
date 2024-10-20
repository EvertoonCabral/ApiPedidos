using ApiControlePedidos.Domain.Entities;

namespace ApiControlePedidos.Domain.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido> GetPedidoById(int id);
        Task CreatePedido(Pedido pedido);
        Task UpdatePedido(int id, Pedido pedido);
        Task DeletePedido(int id);
        IEnumerable<Pedido> GetAllPedidos();
    }

}
