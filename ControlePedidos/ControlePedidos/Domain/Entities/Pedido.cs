﻿using ApiControlePedidos.Domain.Enums;
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
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataFechamento { get; private set; }
        public DateTime? DataCancelamento { get; private set; }

        [JsonIgnore]
        private List<Produto> _produtos;
        [JsonIgnore]
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
            if (Status != StatusPedido.aberto)
            {
                throw new InvalidOperationException("O pedido já está fechado ou cancelado.");
            }

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

