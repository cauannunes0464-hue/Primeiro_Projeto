using System;
using System.Collections.Generic;
using System.Text;
using Primeiro_Projeto.Models;

namespace Primeiro_Projeto.Services
{
    public class ProdutosServices
    {
        private Dictionary<int, Produto> _cardapio;

        public ProdutosServices()
        {
            _cardapio = new Dictionary<int, Produto>()
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
                { 10,new Produto("Milk Shake .....................", 12.00m, " ")},

            };
        }

        public void ObterCardapio()
        {
            foreach (var item in _cardapio)
            {
                Console.WriteLine($"                                         {item.Key} - {item.Value.Nome} - R$ {item.Value.Preco:F2}\n");
            }

        }

        public bool TentarObterProduto(int codigo, out Produto produto)
        {
            return _cardapio.TryGetValue(codigo, out produto);
        }
    }
}
