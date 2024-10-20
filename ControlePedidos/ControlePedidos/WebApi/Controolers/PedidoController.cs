using ApiControlePedidos.Application.Services;
using ApiControlePedidos.Domain.Entities;
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

        [HttpPost("AbrirPedido")]
        public async Task<ActionResult<Pedido>> IniciarPedido(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return BadRequest("Nome do pedido não pode ser vazio.");
            }

            var pedido = await _pedidoService.IniciarPedido(nome);
            return Ok(pedido);
        }

        [HttpPost("{pedidoId}/produtos/{produtoId}/AdicionarProduto")]
        public async Task<IActionResult> AdicionarProdutoAoPedido(int pedidoId, int produtoId)
        {
            try
            {
                await _pedidoService.AdicionarProdutoAoPedido(pedidoId, produtoId);
                return Ok("Produto adicionado ao pedido com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{pedidoId}/produtos/{produtoId}/RemoverProduto")]
        public async Task<IActionResult> RemoverProduto(int pedidoId, int produtoId)
        {
            try
            {
                await _pedidoService.RemoverProdutoDoPedido(pedidoId, produtoId);
                return Ok("Produto removido do pedido com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{pedidoId}/FecharPedido")]
        public async Task<IActionResult> FecharPedido(int pedidoId)
        {
            try
            {
                await _pedidoService.FecharPedido(pedidoId);
                return Ok("Pedido fechado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarPedidos")]
        public ActionResult<IEnumerable<Pedido>> ListarPedidos()
        {
            var pedidos = _pedidoService.ListarPedidos();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> ObterPedidoPorId(int id)
        {
            var pedido = await _pedidoService.ObterPedidoPorId(id);
            if (pedido == null)
            {
                return NotFound("Pedido não encontrado.");
            }

            return Ok(pedido);
        }
    }
}
