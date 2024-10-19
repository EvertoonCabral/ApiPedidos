using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiControlePedidos.Domain.Entities
{
    [Table("Produtos")]
    public class Produto
    {
        [Key] 
        public int Id { get; private set; }

        public string Nome { get; set; } // Torne a propriedade pública

        public decimal Preco { get; set; } // Torne a propriedade pública

        public int Quantidade { get; set; } 

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
    }
}
