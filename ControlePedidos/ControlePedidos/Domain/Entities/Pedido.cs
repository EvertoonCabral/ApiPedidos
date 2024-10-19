using ApiControlePedidos.Domain.Enums;


namespace ApiControlePedidos.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public StatusPedido Status { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataFechamento { get; private set; }
        public DateTime? DataCancelamento { get; private set; }

        private List<Produto> _produtos;
        public IReadOnlyCollection<Produto> Produtos => _produtos.AsReadOnly();

        public Pedido(string nome)
        {
            Nome = nome;
            Status = StatusPedido.aberto;
            DataCadastro = DateTime.UtcNow;
            _produtos = new List<Produto>();
        }

        public void AdicionarProduto(Produto produto)
        {
            // Adiciona produto apenas se o pedido estiver aberto
            if (Status == StatusPedido.aberto)
            {
                _produtos.Add(produto);
            }
            else
            {
                throw new InvalidOperationException("Não é possível adicionar produtos a um pedido fechado ou cancelado.");
            }
        }

        public void RemoverProduto(Produto produto)
        {
            if (Status == StatusPedido.aberto)
            {
                _produtos.Remove(produto);
            }
            else
            {
                throw new InvalidOperationException("Não é possível remover produtos de um pedido fechado ou cancelado.");
            }
        }

        public void FecharPedido()
        {
            if (!_produtos.Any())
            {
                throw new InvalidOperationException("O pedido não pode ser fechado sem produtos.");
            }
            Status = StatusPedido.fechado;
            DataFechamento = DateTime.UtcNow;
        }

        public void CancelarPedido()
        {
            Status = StatusPedido.cancelado;
            DataCancelamento = DateTime.UtcNow;
        }


    }
}

