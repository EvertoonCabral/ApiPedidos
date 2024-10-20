using ApiControlePedidos.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ApiControlePedidos.Domain.Entities
{
    [Table("Pedidos")]
    public class Pedido
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public StatusPedido Status { get; private set; }

        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime DataCadastro { get; private set; }

        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime? DataFechamento { get; private set; }

        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime? DataCancelamento { get; private set; }

        private List<Produto> _produtos;
        public IReadOnlyCollection<Produto> Produtos => _produtos.AsReadOnly();

        public Pedido(string nome)
        {
            Nome = nome;
            Status = StatusPedido.ABERTO;
            DataCadastro = DateTime.UtcNow;
            _produtos = new List<Produto>();
        }

        public void AdicionarProduto(Produto produto)
        {
            if (Status == StatusPedido.ABERTO)
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
            if (Status == StatusPedido.ABERTO)
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
            if (Status != StatusPedido.ABERTO)
            {
                throw new InvalidOperationException("O pedido já está fechado ou cancelado.");
            }

            if (!_produtos.Any())
            {
                throw new InvalidOperationException("O pedido não pode ser fechado sem produtos.");
            }

            Status = StatusPedido.ABERTO;
            DataFechamento = DateTime.UtcNow;
        }



        public void CancelarPedido()
        {
            Status = StatusPedido.CANCELADO;
            DataCancelamento = DateTime.UtcNow;
        }


    }
}

