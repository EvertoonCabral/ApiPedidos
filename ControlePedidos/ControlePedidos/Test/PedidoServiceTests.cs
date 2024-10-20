using ApiControlePedidos.Application.Services;
using ApiControlePedidos.Domain.Entities;
using Moq;
using Xunit;
using System;
using System.Linq;
using System.Threading.Tasks;
using ApiControlePedidos.Domain.Enums;
using ApiControlePedidos.Domain.Repositories;

public class PedidoServiceTests
{
    private readonly Mock<IPedidoRepository> _pedidoRepositoryMock;
    private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
    private readonly PedidoService _pedidoService;

    public PedidoServiceTests()
    {
        //mocks
        _pedidoRepositoryMock = new Mock<IPedidoRepository>();
        _produtoRepositoryMock = new Mock<IProdutoRepository>();

        // Inicializar o PedidoService com os mocks
        _pedidoService = new PedidoService(_pedidoRepositoryMock.Object, _produtoRepositoryMock.Object);
    }

    [Fact]
    public async Task Deve_Iniciar_Pedido_Com_Sucesso()
    {
        // Arrange
        string nome = "Teste Cliente";

        // Act
        var pedido = await _pedidoService.IniciarPedido(nome);

        // Assert
        Assert.NotNull(pedido);
        Assert.Equal(nome, pedido.Nome);
        Assert.Equal(StatusPedido.ABERTO, pedido.Status);
    }

    [Fact]
    public async Task Deve_Adicionar_Produto_Ao_Pedido()
    {
        // Arrange
        var pedido = new Pedido("Teste Pedido");
        var produto = new Produto("Produto Teste", 50);


        _pedidoRepositoryMock.Setup(repo => repo.GetPedidoById(pedido.Id))
            .ReturnsAsync(pedido);

        // simulando a recuperação de um produto existente
        _produtoRepositoryMock.Setup(repo => repo.GetProdutoById(produto.Id))
            .ReturnsAsync(produto);

        // Act
        await _pedidoService.AdicionarProdutoAoPedido(pedido.Id, produto.Id);

        // Assert
        Assert.Contains(pedido.Produtos, p => p.Id == produto.Id);
    }

}
