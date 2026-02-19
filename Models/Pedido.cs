using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;


namespace Primeiro_Projeto.Models
{
    public class Pedido
    {
        public Cliente Cliente { get; set; }
        public Endereco Endereco { get; set; }
        public Pagamento Pagamento { get; set; }

        private List<Produto> produtos;
        public IReadOnlyList<Produto> Produtos
        {
            get
            {
                return this.produtos.AsReadOnly();  // AsReadOnly() cria uma versão protegida da lista. Não permite ex: pedido.produto.Add(produto);
            }
        }
        public Pedido()
        {
            this.produtos = new List<Produto>();
        }

        public void AdicionarProduto(Produto produto)
        {
            if (produto == null)
            {
                throw new ArgumentNullException("produto");
            }

            this.produtos.Add(produto);

        }

        public decimal CalcularTotal()
        {
            return this.produtos.Sum(p => p.Preco);
        }

        public void MostrarResumo()
        {
            foreach (var produto in this.produtos)
            {
                produto.MostrarProduto();
               // Console.WriteLine($"                                         {produto.Nome} - R$ {produto.Preco:F2}\n");
            }

            // Console.WriteLine($"                                                      \nTotal: R$ {CalcularTotal():F2}");
        }

        public void MostrarResumoCompleto()
        {
            Console.WriteLine("              ========= RESUMO DO PEDIDO =========");

            Cliente.Mostrar();
            Console.WriteLine();

            Endereco.MostrarEndereço();
            Console.WriteLine();

            Console.WriteLine("              Produtos: ");
            foreach (var produto in this.produtos)
            {
                Console.WriteLine($"                                         {produto.Nome} - R$ {produto.Preco:F2}\n");
            }
            Console.WriteLine($"\nTotal: R$ {CalcularTotal():F2}\n");

            if (Pagamento != null)
            {
                Pagamento.Mostrar(CalcularTotal());
            }

        }

    }

}
