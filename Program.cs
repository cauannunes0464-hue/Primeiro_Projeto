// Burger House

using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Threading;
using System.Linq;
using System.Collections.Concurrent;
using System.Threading.Channels;

string mensagem = "\n                                 Boas Vindas a Hamburgueria mais famosa do Brasi!\n";

List<string> cardapio1 = new List<string>
    {

        "\n                                       1 - Hambúrguer Clássico ........... R$ 18,00\n                                             Pão, carne, queijo e salada\n",
        "                                       2 - Cheeseburger .................. R$ 20,00\n                                             Pão, carne, queijo e bacon\n",
        "                                       3 - Bacon Burger .................. R$ 22,00\n                                             Pão, carne, queijo e bacon\n",
        "                                       4 - X-Salada ...................... R$ 21,00\n                                             Pão, carne, queijo, alface e tomate\n",
        "                                       5 - X-Egg ......................... R$ 23,00\n                                             Pão, carne, queijo e ovo\n",
        "                                       6 - Burger Duplo .................. R$ 26,00\n                                             Pão, 2 carnes e queijo\n",
        "                                       7 - Batata Frita .................. R$ 10,00\n\n",
        "                                       8 - Batata com Cheddar e Bacon .... R$ 14,00\n\n",
        "                                       9 - Refrigerante Lata ............. R$ 6,00\n\n",
        "                                       10 - Milk Shake.................... R$ 12, 00\n\n"

    };

List<string> pedidos = new List<string>();

void ExibiTitulo()
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

void ExibirOpcoes()
{
    int opcaoEscolhidaNumeric;

    while (true)
    {
        ExibiTitulo();
        Console.WriteLine(mensagem);
        Console.WriteLine("                                           Digite 1 para fazer pedido");
        Console.WriteLine("                                           Digite 2 para avaliar loja");
        Console.WriteLine("                                           Digite 3 para sair");

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
                Cardapio_Pedido();
                return;

            case 2: avaliar();
                return;

            case 3: Sair();
                return;

            default:  
                Console.WriteLine("\n                                                    Opção invalida!\n\n\n");
                Thread.Sleep(2000);
                Console.Clear();
                break;
        }
    }
}

void Cardapio_Pedido()
{
    bool adicionandoItens = true;
    int indice;

    while (adicionandoItens)
    {
        Thread.Sleep(200);
        Console.Clear();
        ExibiTitulo();
        Thread.Sleep(200);

        foreach (string cardapio in cardapio1)
        {
            Console.WriteLine($"{cardapio}");
        }

        Console.Write("                                                    Faça o seu pedido: ");
        string entradaPedido = Console.ReadLine()!;

        if (!int.TryParse(entradaPedido, out int opcao) || opcao < 0)
        {
            Console.WriteLine("\n                                                       Opção errada!");
            Thread.Sleep(2000);
            continue;
        }

        indice = opcao - 1;                                     //indice = opcao - 1;   Converte a opção(1,2,3) para índice(0,1,2)  LISTA E DICIONARIO SEMPRE COMEÇA DO INDICE 0!

        if (indice < 0 || indice >= cardapio1.Count)
        {
            Console.WriteLine("\n                                               Essa opção não existe no cardápio.");
            Thread.Sleep(2000);
            continue;
        }

        if (indice >= 0 && indice < cardapio1.Count)
        {
            string escolhido = cardapio1[indice];
            pedidos.Add(escolhido);

            Console.Clear();
            ExibiTitulo();

            foreach (string pedido in pedidos)
            {
                Console.WriteLine($"           \n {pedido}");
            }

            Console.Write("\n                                        Deseja adicionar mais um item em seu carrinho? ");
            string escolhaSimOuNao = Console.ReadLine()!.ToLower();                                                       // To.Lower serve para padronizar qualquer tipo de string na entrada para minusculo 
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
                ExibiTitulo();

                Console.WriteLine("                                                 Seu carinho: ");

                foreach (string pedido in pedidos)
                {
                    Console.WriteLine($"                            \n{pedido}");
                }

                Thread.Sleep(500);
                Console.WriteLine("\n\n                               Estamos te direcionando para etapa de preencimento de endereço...");
                Thread.Sleep(1500);
                endereco();
                break;
            }
        }
    }
}


void endereco()
{
    Console.WriteLine("\n\n                                                             Deu certo");
}

void avaliar()

{
    int gurdaAvaliacao = 0;
    int opcaoEscolhidaNumericAvalia;

    while (true)
    {
        Console.Clear();
        ExibiTitulo();
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
            ExibiTitulo();
            continue;
        }

        switch (opcaoEscolhidaNumericAvalia)
        {
            case 1:
                Console.Clear();
                gurdaAvaliacao += 1;
                ExibiTitulo();
                Console.WriteLine($"                                                   Você avaliou com {gurdaAvaliacao}");
                return;

            case 2:
                Console.Clear();
                gurdaAvaliacao += 2;
                ExibiTitulo();
                Console.WriteLine($"                                                   Você avaliou com {gurdaAvaliacao}");
                return;

            case 3:
                Console.Clear();
                gurdaAvaliacao += 3;
                ExibiTitulo();
                Console.WriteLine($"                                                   Você avaliou com {gurdaAvaliacao}");
                return;

            case 4:
                Console.Clear();
                gurdaAvaliacao += 4;
                ExibiTitulo();
                Console.WriteLine($"                                                   Você avaliou com {gurdaAvaliacao}");
                return;

            case 5:
                Console.Clear();
                gurdaAvaliacao += 5;
                ExibiTitulo();
                Console.WriteLine($"                                                   Você avaliou com {gurdaAvaliacao}");
                return;

            default:
                Console.WriteLine("\n                                                    Opção invalida!\n\n\n");
                Thread.Sleep(2000);
                Console.Clear();
                ExibiTitulo();
                break;

        }
    }

}

void Sair()
{
    Console.Clear();
    ExibiTitulo();
    Thread.Sleep(2000);
    Console.WriteLine($"\n\n                                            Obrigado pela preferencia!\n\n\n\n");
}


ExibirOpcoes();
