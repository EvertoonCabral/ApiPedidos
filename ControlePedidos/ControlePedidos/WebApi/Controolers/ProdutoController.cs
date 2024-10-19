using ApiControlePedidos.Application.Services;
using ApiControlePedidos.Domain.Entities;
using ControlePedidos.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlePedidos.WebApi.Controolers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly ProdutoService _produtoService;


        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }


        [HttpPost("AddProduto")]
        public async Task<ActionResult<Pedido>> IniciarPedido(Produto p1)
        {
            var produto = await _produtoService.CreateProduto(p1);
            return Ok(produto);
        }


    }
}
