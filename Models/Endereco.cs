using System;
using System.Collections.Generic;
using System.Text;

namespace Primeiro_Projeto.Models
{
    public class Endereco
    {
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; } 

        public Endereco(string rua, string numero, string bairro, string cidade, string cep)        
        {
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Cep = cep;
        }
        public void MostrarEndereço ()
        {
            Console.WriteLine("Endereço da entrega:\n");
            Console.WriteLine($"{Rua}, {Numero} - {Bairro}");
            Console.WriteLine($"{Cidade}, CEP: {Cep}");
        }
    }
}
