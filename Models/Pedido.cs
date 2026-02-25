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
        public Pedido (Cliente cliente)
        {
            Cliente = cliente;
            this.produtos = new List<Produto>();  
        }
        public void DefinirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }
        public void DefinirPagamento(Pagamento pagamento)
        {
            Pagamento = pagamento;
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
            }

        }
    
        public string GerarResumoCompleto()
        {
            Console.WriteLine("                                              ========= RESUMO DO PEDIDO =========\n");

            Cliente.Mostrar();
            Console.WriteLine();

            Endereco.MostrarEndereço();
            Console.WriteLine();

            Console.WriteLine("                                                           Produtos: \n");
            foreach (var produto in this.produtos)
            {
                Console.WriteLine($"                                            {produto.Nome} - R$ {produto.Preco:F2}\n");
            }

            Console.WriteLine($"                                                                        Total: R$ {CalcularTotal():F2}\n");

            if (Pagamento != null)
            {
                Pagamento.Mostrar(CalcularTotal());
            }

        }
        public override string ToString()
        {
            return $"\n                                                  Cliente: {Cliente.Nome} | Total: R$ {CalcularTotal():F2}";

        }
    }

}
