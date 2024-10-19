using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.ComTypes;

namespace ApiControlePedidos.Domain.Entities
{
    [Table("Produtos")]
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public int Quantidade { get; private set; }
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

