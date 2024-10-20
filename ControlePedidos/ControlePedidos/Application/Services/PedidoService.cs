    using ApiControlePedidos.Domain.Entities;
using ApiControlePedidos.Domain.Enums;
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

            pedido.FecharPedido(); 
            await _pedidoRepository.UpdatePedido(pedidoId, pedido);
        }


        public async Task CancelarPedido(int pedidoId)
        {
            var pedido = await _pedidoRepository.GetPedidoById(pedidoId);

            if (pedido == null)
            {
                throw new Exception("Pedido não encontrado.");
            }

            pedido.CancelarPedido();

            await _pedidoRepository.UpdatePedido(pedidoId,pedido);
        }




        public IEnumerable<Pedido> ListarPedidos(int pageNumber, int pageSize)
        {
            return _pedidoRepository.GetAllPedidos()
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
        }


        public IEnumerable<Pedido> ListarPedidosPorStatus(StatusPedido status)
        {
            return _pedidoRepository.GetAllPedidos()
                    .Where(p => p.Status == status)
                    .ToList();
        }



        public async Task<Pedido> ObterPedidoPorId(int id)
            {
                return await _pedidoRepository.GetPedidoById(id);   
            }


        }


    }

