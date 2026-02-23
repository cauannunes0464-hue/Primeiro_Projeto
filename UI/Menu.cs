using Primeiro_Projeto.Models;
using Primeiro_Projeto.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Primeiro_Projeto.UI
{
    public class Menu
    {
        private PedidoService _pedidoService;
        private ProdutosServices _produtosService;

        public Menu()
        {
            _pedidoService = new PedidoService();  // this.pedidoService é a mesma coisa de _pedidoService
            _produtosService = new ProdutosServices();
        }

        public void Iniciar()
        {
            string mensagem = "\n                                        Boas Vindas a Hamburgueria mais famosa do Brasi!\n";

            int opcaoEscolhidaNumeric;
          

            while (true)
            {
                Console.Clear();
                ExibirLogo();
                Console.WriteLine(mensagem);
                Console.WriteLine("                                                  Digite 1 para cardapio");
                Console.WriteLine("                                                  Digite 2 para fazer pedido");
                Console.WriteLine("                                                  Digite 3 para avaliar loja");
                Console.WriteLine("                                                  Digite 4 para ver pedidos");
                Console.WriteLine("                                                  Digite 5 para sair");

                Console.Write("\n                                                   Digite uma opção: ");
                string entrada = Console.ReadLine()!;  // Console.ReadLine()! ---> coloca um terminal na frente da frase "Digite sua opção" para armazenar esse valor na variavel opcaoEscolhida, que é tipo string. O sinal de ( ! ) indica que essa variavel não pode ter uma valor NULO

                if (!int.TryParse(entrada, out opcaoEscolhidaNumeric) || opcaoEscolhidaNumeric < 0)
                {
                    Console.WriteLine("\n                                                    Opção invalida!\n\n\n");
                    Thread.Sleep(2000);
                    Console.Clear();
                    continue;
                }

                switch (opcaoEscolhidaNumeric)
                {
                    case 1:
                        Console.Clear();
                        ExibirLogo();
                        _produtosService.ObterCardapio();
                        Console.ReadKey();
                        Console.Clear();
                        continue;

                    case 2:
                        Console.Clear();
                        ExibirLogo();
                        CriarPedido();
                        return;

                    case 3:
                        Avaliar();
                        return;


                    case 4:
                        ListarPedidos();
                        return;

                    case 5:
                        Console.Clear();
                        ExibirLogo();
                        Thread.Sleep(500);
                        Console.WriteLine($"\n\n                                            Obrigado pela preferencia!\n\n\n\n");
                        return;

                    default:
                        Console.WriteLine("\n                                                    Opção invalida!\n\n\n");
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                }
            }
        }

        private void ExibirLogo()
        {
            Console.WriteLine(@"             
         
            ██████╗░██╗░░░██╗██████╗░░██████╗░███████╗██████╗░      ██╗░░██╗░█████╗░██╗░░░██╗░██████╗███████╗
            ██╔══██╗██║░░░██║██╔══██╗██╔════╝░██╔════╝██╔══██╗      ██║░░██║██╔══██╗██║░░░██║██╔════╝██╔════╝
            ██████╦╝██║░░░██║██████╔╝██║░░██╗░█████╗░░██████╔╝      ███████║██║░░██║██║░░░██║╚█████╗░█████╗░░
            ██╔══██╗██║░░░██║██╔══██╗██║░░╚██╗██╔══╝░░██╔══██╗      ██╔══██║██║░░██║██║░░░██║░╚═══██╗██╔══╝░░
            ██████╦╝╚██████╔╝██║░░██║╚██████╔╝███████╗██║░░██║      ██║░░██║╚█████╔╝╚██████╔╝██████╔╝███████╗
            ╚═════╝░░╚═════╝░╚═╝░░╚═╝░╚═════╝░╚══════╝╚═╝░░╚═╝      ╚═╝░░╚═╝░╚════╝░░╚═════╝░╚═════╝░╚══════╝

        ");
        }

        private void CriarPedido()
        {
            Console.WriteLine("                                                       Insira seus dados:\n");

            Console.Write("                                                         Nome: ");
            string nome = Console.ReadLine()!;

            Console.Write("\n                                                     Telefone: ");
            string telefone = Console.ReadLine()!;

            Console.Write("\n                                                        Email: ");
            string email = Console.ReadLine()!;


            Cliente cliente = new Cliente(nome, telefone, email);

            Pedido pedidoProduto = new Pedido(cliente);


            bool adicionandoItens = true;

            while (adicionandoItens)
            {
                Console.Clear();
                ExibirLogo();
                _produtosService.ObterCardapio();
                Console.Write("\n                                                      Faça o seu pedido: ");
                string entradaPedido = Console.ReadLine()!;


                if (!int.TryParse(entradaPedido, out int opcao) || opcao <= 0)
                {
                    Console.WriteLine("\n                                              Essa opção não existe no cardápio.");
                    Thread.Sleep(2000);
                    continue;
                }

                if (_produtosService.TentarObterProduto(opcao, out Produto produto))
                {
                    pedidoProduto.AdicionarProduto(produto);

                    decimal subtotal = 0;

                    subtotal = pedidoProduto.CalcularTotal();

                    bool pergunta = true;

                    while (pergunta)
                    {
                        Console.Clear();
                        ExibirLogo();

                        pedidoProduto.MostrarResumo();

                        Console.WriteLine($"\n                                                                     Sub Total: {subtotal}");

                        Console.Write("\n                                        Deseja adicionar mais um item em seu carrinho? ");
                        string escolhaSimOuNao = Console.ReadLine()!.Trim().ToLower();                                                       // To.Lower serve para padronizar qualquer tipo de string na entrada para minusculo 

                        if (!escolhaSimOuNao.All(char.IsLetter))
                        {
                            Console.WriteLine("\n\n                                              Digite apenas letras.");
                            Thread.Sleep(1500);
                            continue;
                        }

                        else if (escolhaSimOuNao != "sim" && escolhaSimOuNao != "não" && escolhaSimOuNao != "nao")
                        {
                            Console.WriteLine("\n\n                                                Resposta inválida.");
                            Thread.Sleep(1500);
                            continue;
                        }

                        else if (escolhaSimOuNao == "não" || escolhaSimOuNao == "nao")
                        {
                            Thread.Sleep(1500);
                            Console.Clear();
                            ExibirLogo();

                            Console.WriteLine("                                                 Seu carinho: \n");
                            pedidoProduto.MostrarResumo();
                            pedidoProduto.CalcularTotal();

                            Thread.Sleep(500);
                            Console.WriteLine("\n\n                               Estamos te direcionando para etapa de preencimento de endereço...");
                            Thread.Sleep(4000);

                            adicionandoItens = false;
                            break;
                        }

                        else if (escolhaSimOuNao == "sim")
                        {
                            break;
                        }

                    }

                }

                else
                {
                    Console.WriteLine("                                             Produto não encontrado.");
                    Thread.Sleep(2000);
                    continue;
                }

            }

            Console.Clear();
            ExibirLogo();

            Console.Write("\n\n                                              Rua/Av: ");
            string rua = Console.ReadLine()!;

            Console.Write("                                              Número: ");
            string numero = Console.ReadLine()!;

            Console.Write("                                              Bairro: ");
            string bairro = Console.ReadLine()!;

            Console.Write("                                              Cidade: ");
            string cidade = Console.ReadLine()!;

            Console.Write("                                                 CEP: ");
            string cep = Console.ReadLine()!;

            Endereco endereco = new Endereco(rua, numero, bairro, cidade, cep);

            _pedidoService.AdicionarPedido(pedidoProduto);
            pedidoProduto.DefinirEndereco(endereco);

            Console.Clear();
            ExibirLogo();

            pedidoProduto.MostrarResumoCompleto();
            Console.WriteLine("\n\n                       *************************  Precione qualquer tecla!  ***************************       ");
            Console.ReadKey();

            int opcaoEcolhidaNumericPaga;

            while (true)
            {
                Console.Clear();
                ExibirLogo();
                Console.WriteLine("\n                                                      Forma de pagamento\n");
                Console.WriteLine("                                                             1- Debito");
                Console.WriteLine("                                                             2- Credito");
                Console.WriteLine("                                                             3- Pix");
                Console.WriteLine("                                                             4- Dinheiro\n");


                Console.Write("                                                               Opção: ");
                string pagamentoForma = Console.ReadLine()!;

                if (!int.TryParse(pagamentoForma, out opcaoEcolhidaNumericPaga) || opcaoEcolhidaNumericPaga == 0)
                {
                    Console.WriteLine("\n                                                    Opção invalida!\n\n\n");
                    Thread.Sleep(2000);
                    Console.Clear();
                    ExibirLogo();
                    continue;
                }

                switch (opcaoEcolhidaNumericPaga)
                {
                    case 1:
                        Console.Clear();
                        ExibirLogo();

                        Console.WriteLine("                                          Oba! Seu pedido esta sendo preparado\n");
                        Thread.Sleep(1000);
                        Console.WriteLine("                           Tempo de espera é de 35 a 45 minutos, Obrigado pela preferencia!\n");
                        Thread.Sleep(2000);
                        Iniciar();
                        return;

                    case 2:
                        Console.Clear();
                        ExibirLogo();

                        Console.WriteLine("                                          Oba! Seu pedido esta sendo preparado\n");
                        Thread.Sleep(1000);
                        Console.WriteLine("                           Tempo de espera é de 35 a 45 minutos, Obrigado pela preferencia!\n");
                        Thread.Sleep(2000);
                        Iniciar();
                        return;

                    case 3:
                        Console.Clear();
                        ExibirLogo();

                        Console.WriteLine("                                          Oba! Seu pedido esta sendo preparado\n");
                        Thread.Sleep(1000);
                        Console.WriteLine("                           Tempo de espera é de 35 a 45 minutos, Obrigado pela preferencia!\n");
                        Thread.Sleep(2000);
                        Iniciar();
                        return;

                    case 4:
                        while (true)
                        {
                            Console.Clear();
                            ExibirLogo();
                            Console.Write("                                                   Troco para: ");

                            string entradaValor = Console.ReadLine()!;
                            string forma = "dinheiro";

                            if (!int.TryParse(entradaValor, out int troco) || troco <= 0)
                            {
                              Console.WriteLine("\n                                                     Apenas números.");
                              Thread.Sleep(2000);
                              continue;
                            }

                            decimal valor = Convert.ToDecimal(entradaValor);

                            if (valor < pedidoProduto.CalcularTotal())
                            {
                                Console.WriteLine("\n                                         Valor pago inferior ao valor Total");
                                Thread.Sleep(3000);
                                continue;
                            }

                            if (valor > pedidoProduto.CalcularTotal() *45.0m)
                            {
                                Console.WriteLine("\n                                                Valor de troco muito alto");
                                Thread.Sleep(3000);
                                continue;
                            }

                            else
                            {
                                Pagamento pagamento = new Pagamento(forma, valor);

                                Console.Clear();
                                ExibirLogo();
                                pagamento.Mostrar(pedidoProduto.CalcularTotal());

                                Console.ReadKey();

                                Console.Clear();
                                ExibirLogo();
                                Console.WriteLine("                                           Oba! Seu pedido esta sendo preparado\n");
                                Thread.Sleep(1000);
                                Console.WriteLine("                           Tempo de espera é de 35 a 45 minutos, Obrigado pela preferencia!\n");
                                Thread.Sleep(2000);
                                Iniciar();
                                return;
                            }
                        }

                    default:
                        Console.WriteLine("\n                                                    Opção invalida!\n\n\n");
                        Thread.Sleep(2000);
                        Console.Clear();
                        ExibirLogo();
                        break;
                }
            }
        }

        private void Avaliar()
        {
            int gurdaAvaliacao = 0;
            int opcaoEscolhidaNumericAvalia;

            while (true)
            {
                Console.Clear();
                ExibirLogo();
                Console.WriteLine("                                  Como você considera sua experiencia com o sistema?\n");

                Console.WriteLine("                                                        1- Ruim");
                Console.WriteLine("                                                        2- Regular");
                Console.WriteLine("                                                        3- Bom");
                Console.WriteLine("                                                        4- Muito Bom");
                Console.WriteLine("                                                        5- Excelente\n");
                string entradaAvalia = Console.ReadLine()!;

                if (!int.TryParse(entradaAvalia, out opcaoEscolhidaNumericAvalia) || opcaoEscolhidaNumericAvalia < 0)
                {
                    Console.WriteLine("\n                                                    Opção invalida!\n\n\n");
                    Thread.Sleep(2000);
                    Console.Clear();
                    ExibirLogo();
                    continue;
                }

                switch (opcaoEscolhidaNumericAvalia)
                {
                    case 1:
                        Console.Clear();
                        gurdaAvaliacao += 1;
                        ExibirLogo();
                        Console.WriteLine($"                                                   Você avaliou com {gurdaAvaliacao}");
                        Thread.Sleep(2000);
                        Iniciar();
                        return;

                    case 2:
                        Console.Clear();
                        gurdaAvaliacao += 2;
                        ExibirLogo();
                        Console.WriteLine($"                                                   Você avaliou com {gurdaAvaliacao}");
                        Thread.Sleep(2000);
                        Iniciar();
                        return;

                    case 3:
                        Console.Clear();
                        gurdaAvaliacao += 3;
                        ExibirLogo();
                        Console.WriteLine($"                                                   Você avaliou com {gurdaAvaliacao}");
                        Thread.Sleep(2000);
                        Iniciar();
                        return;

                    case 4:
                        Console.Clear();
                        gurdaAvaliacao += 4;
                        ExibirLogo();
                        Console.WriteLine($"                                                   Você avaliou com {gurdaAvaliacao}");
                        Thread.Sleep(2000);
                        Iniciar();
                        return;

                    case 5:
                        Console.Clear();
                        gurdaAvaliacao += 5;
                        ExibirLogo();
                        Console.WriteLine($"                                                   Você avaliou com {gurdaAvaliacao}");
                        Thread.Sleep(2000);
                        Iniciar();
                        return;

                    default:
                        Console.WriteLine("\n                                                    Opção invalida!\n\n\n");
                        Thread.Sleep(2000);
                        Console.Clear();
                        ExibirLogo();
                        break;
                }
            }
        }

        private void ListarPedidos()
        {
            var pedidos = _pedidoService.ListarPedidosCriados();

            if (pedidos.Count == 0)
            {
                Console.Write("\n                                                  Nenhum pedido cadastrado");
                Thread.Sleep(4000);
                Iniciar();
                return;
            }

            Console.Clear();
            ExibirLogo();

            foreach (var pedido in pedidos)
            {
                Console.WriteLine(pedido);
            }
            Console.ReadKey();
            Iniciar();

        }

    }
}