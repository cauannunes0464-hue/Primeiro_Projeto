using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Primeiro_Projeto.Models
{
    public class Pagamento
    {
        public string Forma { get; set; }
        public decimal Valor  { get; set; } 
        
        public Pagamento (string forma, decimal valor)
        {
            Forma = forma;
            Valor = valor;
        }

        public decimal CalcularTroco (decimal totalPedido)
        {
            if(Forma.ToLower() == "dinheiro")
            {
                return Valor - totalPedido;
            }

            return 0;
        }

        public void Mostrar(decimal totalPedido)
        {
            Console.WriteLine($"Forma de Pagamento: {Forma}");
            Console.WriteLine($"Valor pago: R$ {Valor:F2}");

            if ( Forma.ToLower() == "dinheiro")
            {
                Console.WriteLine($"Troco: R$V{CalcularTroco(totalPedido):F2}");
            }

        }
    }
}
