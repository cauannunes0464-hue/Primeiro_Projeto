// Burger House
using Primeiro_Projeto.Models;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Threading.Channels;
using static System.Runtime.InteropServices.JavaScript.JSType;

string mensagem = "\n                                 Boas Vindas a Hamburgueria mais famosa do Brasi!\n";

Dictionary < int, Produto> cardapio1 = new Dictionary < int, Produto>()
{ 

    { 1, new Produto("Hambúrguer Clássico ............", 18.00m,"" )},
    { 2, new Produto("Cheeseburger ...................", 20.00m, "\nPão, carne, queijo e bacon")},
    { 3, new Produto("Bacon Burger ...................", 22.00m, "\nPão, carne, queijo e bacon")},
    { 4, new Produto("X-Salada .......................", 21.00m, "\nPão, carne, queijo, alface e tomate")},
    { 5, new Produto("X-Egg ..........................", 23.00m, "\nPão, carne, queijo e ovo")},
    { 6, new Produto("Burger Duplo ...................", 26.00m, "\nPão, 2 carnes e queijo")},
    { 7, new Produto("Batata Frita ...................", 10.00m, " ")},
    { 8, new Produto("Batata com Cheddar e Bacon .....", 14.00m, " ")},
    { 9, new Produto("Refrigerante Lata ..............",  6.00m, " ")},
    { 10, new Produto("Milk Shake ....................", 12.00m, " ")},

};

Pedido pedido = new Pedido();


void ExibirLogo()
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
        ExibirLogo();
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

            case 2: Avaliar();
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
    int opcao;

    while (adicionandoItens)
    {
        Thread.Sleep(200);
        Console.Clear();
        ExibirLogo();
        Thread.Sleep(200);

        foreach (var item in cardapio1)
        {
            Console.WriteLine($"                                       {item.Key} - {item.Value.Nome} - R$ {item.Value.Preco:F2}\n");
        }

        Console.Write("\n                                                    Faça o seu pedido: ");
        string entradaPedido = Console.ReadLine()!;

        if (!int.TryParse(entradaPedido, out opcao) || opcao < 0)
        {
            Console.WriteLine("\n                                                       Opção errada!");
            Thread.Sleep(2000);
            continue;
        }

        indice = opcao;                                     //indice = opcao - 1;   Converte a opção(1,2,3) para índice(0,1,2)  LISTA E DICIONARIO SEMPRE COMEÇA DO INDICE 0!

        if (indice < 0 || indice >= cardapio1.Count)
        {
            Console.WriteLine("\n                                               Essa opção não existe no cardápio.");
            Thread.Sleep(2000);
            continue;
        }

        Produto escolhido = cardapio1[indice];
        pedido.AdicionarProduto(escolhido);

        decimal subtotal = 0;
        decimal total = 0;
        subtotal = pedido.CalcularTotal();

        bool pergunta = true;

        while (pergunta)
        {
            Console.Clear();
            ExibirLogo();

            pedido.MostrarResumo();

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
                foreach (var produto in pedido.Produtos)
                {
                    Console.WriteLine($"                                         {produto.Nome} - R$ {produto.Preco:F2}\n");
                }

                Console.WriteLine($"                                                                Total a pagar: {total}");

                Thread.Sleep(500);
                Console.WriteLine("\n\n                               Estamos te direcionando para etapa de preencimento de endereço...");
                Thread.Sleep(4000);
                Endereco();
                adicionandoItens = false;
                break;
            }

            else if (escolhaSimOuNao == "sim")
            {
                break;
            }

        }
    }
}

void Endereco()
{
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

    Endereco endereco = new Endereco(rua, numero, bairro, cidade, cep );

    Thread.Sleep(1000);
    DadosCliente();
    
}

void DadosCliente()
{
    Console.Clear();
    Thread.Sleep(100);
    ExibirLogo();

    Console.WriteLine("                              Insira seus dados:\n");

    Console.Write("                          Nome: ");
    string nome = Console.ReadLine()!;

    Console.Write("                      Telefone: ");
    string telefone = Console.ReadLine()!;

    Console.Write("                         Email: ");
    string email = Console.ReadLine()!;

    Cliente cliente = new Cliente(nome, telefone, email);

    Thread.Sleep(1000);
    Pagamento();
}

void Pagamento()
{
    Console.Clear();
    Thread.Sleep(100);
    ExibirLogo();
  

    int opcaoEcolhidaNumericPaga;

    while (true)
    {
        Console.WriteLine("                                                   Forma de pagamento\n");
        Console.WriteLine("                                                        1- Debito");
        Console.WriteLine("                                                        2- Credito");
        Console.WriteLine("                                                        3- Pix");
        Console.WriteLine("                                                        4- Dinheiro\n");

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
                Console.WriteLine("                           Tempo de esperas é de 35 a 45 minutos, Obrigado pela preferencia!\n");
                Thread.Sleep(2000);
                return;

            case 2:
                Console.Clear();
                ExibirLogo();

                Console.WriteLine("                                          Oba! Seu pedido esta sendo preparado\n");
                Thread.Sleep(1000);
                Console.WriteLine("                           Tempo de esperas é de 35 a 45 minutos, Obrigado pela preferencia!\n");
                Thread.Sleep(2000);
                return;

            case 3:
                Console.Clear();
                ExibirLogo();

                Console.WriteLine("                                          Oba! Seu pedido esta sendo preparado\n");
                Thread.Sleep(1000);
                Console.WriteLine("                           Tempo de esperas é de 35 a 45 minutos, Obrigado pela preferencia!\n");
                Thread.Sleep(2000);
                return;

            case 4:
                Console.Clear();
                ExibirLogo();

                Console.Write("                                                       Troco para: ");
                string troco = Console.ReadLine()!;
                Thread.Sleep(1000);
                Console.Clear();

                ExibirLogo();
                Console.WriteLine("                                           Oba! Seu pedido esta sendo preparado\n");
                Thread.Sleep(1000);
                Console.WriteLine("                           Tempo de esperas é de 35 a 45 minutos, Obrigado pela preferencia!\n");
                Thread.Sleep(2000);
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

void Avaliar()

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

void Sair()
{
    Console.Clear();
    ExibirLogo();
    Thread.Sleep(500);
    Console.WriteLine($"\n\n                                            Obrigado pela preferencia!\n\n\n\n");
}

ExibirOpcoes();