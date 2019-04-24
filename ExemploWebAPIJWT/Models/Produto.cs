using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploWebAPIJWT.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Qtde { get; set; }

        public Produto()
        {

        }


        public Produto(int id, string nome, decimal preco, int qtde)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Qtde = qtde;
        }

    }
}
