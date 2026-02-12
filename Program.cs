// Burger House

string mensagem = "\n                                 Boas Vindas a Hamburgueria mais famosa do Brasi!\n";

Dictionary < int, (string Nome,decimal Preco, string Descricao)> cardapio1 = new Dictionary < int, (string, decimal, string) > ()

{
    { 1, ("Hambúrguer Clássico ............" ,18.00m, "\nPão, carne, queijo e salada")},
    { 2, ("Cheeseburger ..................." ,20.00m, " " )},
    { 3, ("Bacon Burger ..................." ,22.00m, "\nPão, carne, queijo e bacon")},
    { 4, ("X-Salada ......................." ,21.00m, "\nPão, carne, queijo, alface e tomate")},
    { 5, ("X-Egg .........................." ,23.00m, "\nPão, carne, queijo e ovo" )},
    { 6, ("Burger Duplo ..................." ,26.00m, "\nPão, 2 carnes e queijo")},
    { 7, ("Batata Frita ..................." ,10.00m, " " )},
    { 8, ("Batata com Cheddar e Bacon ....." ,14.00m, " " )},
    { 9, ("Refrigerante Lata .............." , 6.00m, " " )},
    { 10, ("Milk Shake ...................." ,12.00m, " " )}
};

List<(string Nome, decimal Preco, string Descricao)> pedidos = new List<(string Nome, decimal Preco, string Descricao)>();


void ExibirTitulo()
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
        ExibirTitulo();
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
        ExibirTitulo();
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

        indice = opcao - 1;                                     //indice = opcao - 1;   Converte a opção(1,2,3) para índice(0,1,2)  LISTA E DICIONARIO SEMPRE COMEÇA DO INDICE 0!

        if (indice < 0 || indice >= cardapio1.Count)
        {
            Console.WriteLine("\n                                               Essa opção não existe no cardápio.");
            Thread.Sleep(2000);
            continue;
        }

        var escolhido = cardapio1[opcao];
        pedidos.Add(escolhido);

        bool pergunta = true;
        while (pergunta)
        {
            Console.Clear();
            ExibirTitulo();

            foreach (var pedido in pedidos)
            {
                Console.WriteLine($"                                         {pedido.Nome} - R$ {pedido.Preco:F2}\n");
            }

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
                ExibirTitulo();

                Console.WriteLine("                                                 Seu carinho: \n");
                foreach (var pedido in pedidos)
                {
                    Console.WriteLine($"                                         {pedido.Nome} - R$ {pedido.Preco:F2}\n");
                }

                Thread.Sleep(500);
                Console.WriteLine("\n\n                               Estamos te direcionando para etapa de preencimento de endereço...");
                Thread.Sleep(1500);
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
    Thread.Sleep(100);
    ExibirTitulo();

    Console.Write("\n\n                                Endereço: ");
    string entradaEndereco = Console.ReadLine()!;

    Console.Write("                                Número: ");
    string numero = Console.ReadLine()!;

    Console.Write("                                Bairro: ");
    string entradaBairro= Console.ReadLine()!;

    Thread.Sleep(1000);
    Pagamento();
}

void Pagamento()
{
    Console.Clear();
    Thread.Sleep(100);
    ExibirTitulo();

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
            ExibirTitulo();
            continue;
        }
        switch (opcaoEcolhidaNumericPaga)
        {
            case 1:
                Console.Clear();
                ExibirTitulo();
                
                Console.WriteLine("                                          Oba! Seu pedido esta sendo preparado\n");
                Thread.Sleep(1000);
                Console.WriteLine("                           Tempo de esperas é de 35 a 45 minutos, Obrigado pela preferencia!\n");
                Thread.Sleep(2000);
                return;

            case 2:
                Console.Clear();
                ExibirTitulo();

                Console.WriteLine("                                          Oba! Seu pedido esta sendo preparado\n");
                Thread.Sleep(1000);
                Console.WriteLine("                           Tempo de esperas é de 35 a 45 minutos, Obrigado pela preferencia!\n");
                Thread.Sleep(2000);
                return;

            case 3:
                Console.Clear();
                ExibirTitulo();

                Console.WriteLine("                                          Oba! Seu pedido esta sendo preparado\n");
                Thread.Sleep(1000);
                Console.WriteLine("                           Tempo de esperas é de 35 a 45 minutos, Obrigado pela preferencia!\n");
                Thread.Sleep(2000);
                return;

            case 4:
                Console.Clear();
                ExibirTitulo();

                Console.Write("                                                       Troco para: ");
                string troco = Console.ReadLine()!;
                Thread.Sleep(1000);
                Console.Clear();

                ExibirTitulo();
                Console.WriteLine("                                           Oba! Seu pedido esta sendo preparado\n");
                Thread.Sleep(1000);
                Console.WriteLine("                           Tempo de esperas é de 35 a 45 minutos, Obrigado pela preferencia!\n");
                Thread.Sleep(2000);
                return;

            default:
                Console.WriteLine("\n                                                    Opção invalida!\n\n\n");
                Thread.Sleep(2000);
                Console.Clear();
                ExibirTitulo();
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
        ExibirTitulo();
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
            ExibirTitulo();
            continue;
        }

        switch (opcaoEscolhidaNumericAvalia)
        {
            case 1:
                Console.Clear();
                gurdaAvaliacao += 1;
                ExibirTitulo();
                Console.WriteLine($"                                                   Você avaliou com {gurdaAvaliacao}");
                return;

            case 2:
                Console.Clear();
                gurdaAvaliacao += 2;
                ExibirTitulo();
                Console.WriteLine($"                                                   Você avaliou com {gurdaAvaliacao}");
                return;

            case 3:
                Console.Clear();
                gurdaAvaliacao += 3;
                ExibirTitulo();
                Console.WriteLine($"                                                   Você avaliou com {gurdaAvaliacao}");
                return;

            case 4:
                Console.Clear();
                gurdaAvaliacao += 4;
                ExibirTitulo();
                Console.WriteLine($"                                                   Você avaliou com {gurdaAvaliacao}");
                return;

            case 5:
                Console.Clear();
                gurdaAvaliacao += 5;
                ExibirTitulo();
                Console.WriteLine($"                                                   Você avaliou com {gurdaAvaliacao}");
                return;

            default:
                Console.WriteLine("\n                                                    Opção invalida!\n\n\n");
                Thread.Sleep(2000);
                Console.Clear();
                ExibirTitulo();
                break;
        }
    }

}

void Sair()
{
    Console.Clear();
    ExibirTitulo();
    Thread.Sleep(500);
    Console.WriteLine($"\n\n                                            Obrigado pela preferencia!\n\n\n\n");
}

ExibirOpcoes();