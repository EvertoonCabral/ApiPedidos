using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiControlePedidos.Domain.Entities
{
    [Table("Produtos")]
    public class Produto
    {
        [Key] 
        public int Id { get; private set; }

        public string Nome { get; set; } 

        public decimal Preco { get; set; } 

        public int Quantidade { get; set; }
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime DataCadastro { get; private set; }

        public Produto(string nome, decimal preco, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
            DataCadastro = DateTime.UtcNow;
        }

        public Produto()
        {
            DataCadastro = DateTime.UtcNow;
        }

        public Produto(string v1, int v2)
        {
        }
    }
}
