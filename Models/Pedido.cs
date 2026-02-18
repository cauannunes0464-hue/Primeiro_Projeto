using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Primeiro_Projeto.Models
{
    public class Pedido
    {
        private List<Produto> _produtos;
        public IReadOnlyList<Produto> Produtos
        {
            get
            {
                return _produtos.AsReadOnly();  // AsReadOnly() cria uma versão protegida da lista. Não permite ex: pedido.produto.Add(produto);
            }
        }
        public Pedido()
        {
            _produtos = new List<Produto>();
        }

        public void AdicionarProduto(Produto produto)
        {
            if (produto == null)
            {
                throw new ArgumentNullException("produto");
            }

            _produtos.Add(produto);

        }

        public decimal CalcularTotal()
        {
            return _produtos.Sum(p => p.Preco);
        }

        public void MostrarResumo()
        {
            foreach (var produto in _produtos)
            {
                Console.WriteLine($"                                         {produto.Nome} - R$ {produto.Preco:F2}\n");

            }

            // Console.WriteLine($"                                                      \nTotal: R$ {CalcularTotal():F2}");
        }

    }

}
