using ApiControlePedidos.Application.Services;
using ApiControlePedidos.Domain.Entities;
using ControlePedidos.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControlePedidos.WebApi.Controllers
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

        [HttpPost("AdicionarProduto")]
        public async Task<ActionResult<Produto>> AddProduto([FromBody] Produto p1)
        {
            try
            {
                var produto = await _produtoService.CreateProduto(p1);
                return CreatedAtAction(nameof(AddProduto), new { id = produto.Id }, produto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno do servidor.");
            }
        }

        [HttpGet("ListarProdutos")]
        public ActionResult<IEnumerable<Produto>> ListarProdutos(int numeroPagina = 1, int tamanhoPagina = 10)
        {
            try
            {
                var produtos = _produtoService.ListarProdutosPaginados(numeroPagina, tamanhoPagina);
                return Ok(produtos);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
