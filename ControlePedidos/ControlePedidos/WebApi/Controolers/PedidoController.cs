using ApiControlePedidos.Application.Services;
using ApiControlePedidos.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiControlePedidos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost("iniciar")]
        public async Task<ActionResult<Pedido>> IniciarPedido(string nome)
        {
            var pedido = await _pedidoService.IniciarPedido(nome);
            return Ok(pedido);
        }


        [HttpPost("{pedidoId}/produtos/{produtoId}/adicionar")]
        public ActionResult AdicionarProduto(int pedidoId, int produtoId)
        {
            _pedidoService.AdicionarProdutoAoPedido(pedidoId, produtoId);
            return NoContent();
        }

        [HttpDelete("{pedidoId}/produtos/{produtoId}/remover")]
        public ActionResult RemoverProduto(int pedidoId, int produtoId)
        {
            _pedidoService.RemoverProdutoDoPedido(pedidoId, produtoId);
            return NoContent();
        }

        [HttpPost("{pedidoId}/fechar")]
        public ActionResult FecharPedido(int pedidoId)
        {
            _pedidoService.FecharPedido(pedidoId);
            return NoContent();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> ListarPedidos()
        {
            var pedidos = _pedidoService.ListarPedidos();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public ActionResult<Pedido> ObterPedidoPorId(int id)
        {
            var pedido = _pedidoService.ObterPedidoPorId(id);
            return Ok(pedido);
        }
    }
}
