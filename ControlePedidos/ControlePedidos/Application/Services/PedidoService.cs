using ApiControlePedidos.Domain.Entities;
using ApiControlePedidos.Domain.Repositories;

namespace ApiControlePedidos.Application.Services
{
    public class PedidoService
    {

        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;


        public PedidoService(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository)
        {

            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
        }


        public Pedido IniciarPedido(string nome)
        {
            var pedido = new Pedido(nome);
            _pedidoRepository.CreatePedido(pedido);
            return pedido;
        }

        public void AdicionarProdutoAoPedido(int pedidoId, int produtoId)
        {
            var pedido = _pedidoRepository.GetPedidoById(pedidoId);
            if (pedido == null) throw new Exception("Pedido não encontrado");

            var produto = _produtoRepository.GetProdutoById(produtoId);
            if (produto == null) throw new Exception("Produto não encontrado");

            pedido.AdicionarProduto(produto);
            _pedidoRepository.UpdatePedido(pedidoId, pedido);
        }

        public void RemoverProdutoDoPedido(int pedidoId, int produtoId)
        {
            var pedido = _pedidoRepository.GetPedidoById(pedidoId);
            if (pedido == null) throw new Exception("Pedido não encontrado");

            var produto = _produtoRepository.GetProdutoById(produtoId);
            if (produto == null) throw new Exception("Produto não encontrado");

            pedido.RemoverProduto(produto);
            _pedidoRepository.UpdatePedido(pedidoId, pedido);
        }

        public void FecharPedido(int pedidoId)
        {
            var pedido = _pedidoRepository.GetPedidoById(pedidoId);
            if (pedido == null) throw new Exception("Pedido não encontrado");

            pedido.FecharPedido();
            _pedidoRepository.UpdatePedido(pedidoId, pedido);
        }

        public IEnumerable<Pedido> ListarPedidos()
        {
            return _pedidoRepository.GetAllPedidos();
        }

        public Pedido ObterPedidoPorId(int id)
        {
            return _pedidoRepository.GetPedidoById(id);
        }

    }


}

