using Primeiro_Projeto.Models;
using Primeiro_Projeto.Services;
using System.Net.WebSockets;

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
        string mensagem = "\n                                 Boas Vindas a Hamburgueria mais famosa do Brasi!\n";

        int opcaoEscolhidaNumeric;

        while (true)
        {
            ExibirLogo();
            Console.WriteLine(mensagem);
            Console.WriteLine("                                           Digite 1 para cardapio");
            Console.WriteLine("                                           Digite 2 para fazer pedido");
            Console.WriteLine("                                           Digite 3 para avaliar loja");
            Console.WriteLine("                                           Digite 4 para sair");

            Console.Write("\n                                               Digite uma opção: ");
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
                    Console.ReadLine();
                    continue;

                case 2:
                    Console.Clear();
                    ExibirLogo();
                    _produtosService.ObterCardapio();
                    CriarPedido();
                    return;

                case 3:
                    Avaliar();
                    return;


                case 4:
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
        Console.WriteLine("                              Insira seus dados:\n");

        Console.Write("                          Nome: ");
        string nome = Console.ReadLine()!;

        Console.Write("                      Telefone: ");
        string telefone = Console.ReadLine()!;

        Console.Write("                         Email: ");
        string email = Console.ReadLine()!;


        Cliente cliente = new Cliente(nome, telefone, email);

        Pedido pedidoProduto = new Pedido();


        int opcao;
        bool adicionandoItens = true;

        while (adicionandoItens)
        {
            Console.Clear();
            ExibirLogo();
            Console.Write("\n                                                    Faça o seu pedido: ");
            string entradaPedido = Console.ReadLine()!;

            if (!int.TryParse(entradaPedido, out opcao) || opcao < 0)
            {
                Console.WriteLine("\n                                              Essa opção não existe no cardápio.");
                Thread.Sleep(2000);
                continue;
            }

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Codigo invalido");
                continue;
            }

            _produtosService.TentarObterProduto(opcao, out Produto produto);
            pedidoProduto.AdicionarProduto(produto);

            decimal subtotal = 0;
            decimal total = 0;

            subtotal = pedidoProduto.CalcularTotal();

            bool pergunta = true;

            while (pergunta)
            {
                Console.Clear();
                ExibirLogo();

                pedidoProduto.MostrarResumo();

                Console.WriteLine($"\n                                                                    Sub Total: {subtotal}");

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

                    total = subtotal;

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

        Console.Clear();
        ExibirLogo();

        Console.Write("\n\n                               Rua: ");
        string rua = Console.ReadLine()!;

        Console.Write("                                Número: ");
        string numero = Console.ReadLine()!;

        Console.Write("                                Bairro: ");
        string bairro = Console.ReadLine()!;

        Console.Write("                                Cidade: ");
        string cidade = Console.ReadLine()!;

        Console.Write("                                   CEP: ");
        string cep = Console.ReadLine()!;

        Endereco endereco = new Endereco(rua, numero, bairro, cidade, cep);

        _pedidoService.AdicionarPedido(pedidoProduto);

        Console.Clear();
        ExibirLogo();

        ListarPedidos();

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
                    return;

                case 2:
                    Console.Clear();
                    gurdaAvaliacao += 2;
                    ExibirLogo();
                    Console.WriteLine($"                                                   Você avaliou com {gurdaAvaliacao}");
                    return;

                case 3:
                    Console.Clear();
                    gurdaAvaliacao += 3;
                    ExibirLogo();
                    Console.WriteLine($"                                                   Você avaliou com {gurdaAvaliacao}");
                    return;

                case 4:
                    Console.Clear();
                    gurdaAvaliacao += 4;
                    ExibirLogo();
                    Console.WriteLine($"                                                   Você avaliou com {gurdaAvaliacao}");
                    return;

                case 5:
                    Console.Clear();
                    gurdaAvaliacao += 5;
                    ExibirLogo();
                    Console.WriteLine($"                                                   Você avaliou com {gurdaAvaliacao}");
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
            Console.WriteLine("                  Nenhum pedido cadastrado");
            return;
        }

        foreach (var pedido in pedidos)
        {
            Console.WriteLine(pedido);
        }
    }
}

