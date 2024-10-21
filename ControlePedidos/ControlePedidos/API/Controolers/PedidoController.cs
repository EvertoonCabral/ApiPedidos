using ApiControlePedidos.Application.Services;
using ApiControlePedidos.Domain.Entities;
using ApiControlePedidos.Domain.Enums;
using ControlePedidos.Application.DTOs;
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
        public async Task<ActionResult<PedidoDTO>> IniciarPedido(string nome)
        {
            var pedido = await _pedidoService.IniciarPedido(nome);

            // Utilizando DTO para nao exibir a data de fechamento/cancelamento e a lista de produtos,
            // tendo em vista que o pedido esta sendo aberto
            var pedidoDTO = new PedidoDTO
            {
                Id = pedido.Id,
                Nome = pedido.Nome,
                Status = pedido.Status.ToString(),
                DataCadastro = pedido.DataCadastro.ToString("dd/MM/yyyy HH:mm:ss")
            };

            return Ok(pedidoDTO);
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



        [HttpPut("{pedidoId}/CancelarPedido")]
        public async Task<IActionResult> CancelarPedido(int pedidoId)
        {
            try
            {
                await _pedidoService.CancelarPedido(pedidoId);
                return Ok("Pedido cancelado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("ListarPedidos")]
        public ActionResult<IEnumerable<Pedido>> ListarPedidos(int NumPaginas = 1, int TamanhoPagina = 10)
        {

            var pedidos = _pedidoService.ListarPedidos(NumPaginas, TamanhoPagina);
            return Ok(pedidos);

        }



        [HttpGet("ListarPedidosPorStatus")]
        public ActionResult<IEnumerable<Pedido>> ListarPedidosPorStatus(StatusPedido status)
        {

            var pedidos = _pedidoService.ListarPedidosPorStatus(status);
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
