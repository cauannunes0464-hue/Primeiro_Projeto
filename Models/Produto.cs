using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Primeiro_Projeto.Models
{
    public class Produto
    {
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public string Descricao { get; private set; }

        public Produto(string nome, decimal preco, string descricao) 
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do produto não pode ser vazio.");

            if (preco <= 0)
                throw new ArgumentException("Preço deve ser maior que zero");

            Nome = nome;
            Preco = preco;
            Descricao = descricao;

        }

        public void MostrarProduto()
        {
            Console.WriteLine($"                                            {Nome} R$ {Preco:F2}");
        }
    }
}
