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


            public async Task<Pedido> IniciarPedido(string nome)
            {
                var pedido = new Pedido(nome);
                await _pedidoRepository.CreatePedido(pedido);
                return pedido;
            }

            public async Task AdicionarProdutoAoPedido(int pedidoId, int produtoId)
            {
                var pedido = await _pedidoRepository.GetPedidoById(pedidoId); 
                if (pedido == null) throw new Exception("Pedido não encontrado");

                var produto = await _produtoRepository.GetProdutoById(produtoId); 
                if (produto == null) throw new Exception("Produto não encontrado");

                pedido.AdicionarProduto(produto);
                await _pedidoRepository.UpdatePedido(pedidoId, pedido);
            }

            public async Task RemoverProdutoDoPedido(int pedidoId, int produtoId)
            {
                var pedido = await _pedidoRepository.GetPedidoById(pedidoId); 
                if (pedido == null) throw new Exception("Pedido não encontrado");

                var produto = await _produtoRepository.GetProdutoById(produtoId); 
                if (produto == null) throw new Exception("Produto não encontrado");

                pedido.RemoverProduto(produto);
                await _pedidoRepository.UpdatePedido(pedidoId, pedido); 
            }


        public async Task FecharPedido(int pedidoId)
        {
            var pedido = await _pedidoRepository.GetPedidoById(pedidoId);
            if (pedido == null) throw new Exception("Pedido não encontrado");

            pedido.FecharPedido(); // Altera o status para fechado e define a data de fechamento
            await _pedidoRepository.UpdatePedido(pedidoId, pedido);
        }


        public IEnumerable<Pedido> ListarPedidos()
            {
                return _pedidoRepository.GetAllPedidos();
            }

            public async Task<Pedido> ObterPedidoPorId(int id)
            {
                return await _pedidoRepository.GetPedidoById(id); // Aguarde a obtenção do pedido
            }


        }


    }

