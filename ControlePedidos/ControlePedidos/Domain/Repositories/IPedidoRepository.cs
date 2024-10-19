using ApiControlePedidos.Domain.Entities;

namespace ApiControlePedidos.Domain.Repositories
{
    public interface IPedidoRepository
    {

        Pedido GetPedidoById(int id);
        IEnumerable<Pedido> GetAllPedidos();

        void CreatePedido(Pedido pedido);
        void UpdatePedido(int id, Pedido pedido);
        void DeletePedido(int id);



    }
}
