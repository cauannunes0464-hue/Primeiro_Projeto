using System;
using System.Collections.Generic;
using System.Text;

namespace Primeiro_Projeto.Models
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public Cliente (string nome, string telefone, string email) 
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;

        }

        public void Mostrar()
        {
            Console.WriteLine($"                                                      Cliente: {Nome}");
            Console.WriteLine($"                                                     Telefone: {Telefone}");
            Console.WriteLine($"                                                        Email: {Email}");
        }

    }
}
