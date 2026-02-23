# 🍔 Sistema de Hamburgueria

![C#](https://img.shields.io/badge/C%23-.NET-512BD4?logo=dotnet)
![POO](https://img.shields.io/badge/Paradigma-POO-blue)
![Status](https://img.shields.io/badge/status-Finalizado-brightgreen)

**Sistema de pedidos para uma hamburgueria desenvolvido em C# com foco em Programação Orientada a Objetos (POO) e organização em camadas (Models, Services e UI).**

---
## 📌 Sobre o Projeto

Este projeto simula o funcionamento de uma hamburgueria, permitindo:

- Cadastro de cliente
- Associação de endereço
- Criação de pedidos
- Adição de produtos ao pedido
- Escolha de forma de pagamento
- Cálculo automático do total
- Listagem de pedidos criados

O sistema é executado via Console Application.

---
## Estrutura do Projeto

📁 Models
   
   └── Cliente.cs
   
   └── Endereco.cs

   └── Pagamento.cs

   └── Pedido.cs

   └── Produto.cs

📁 Services

   └── PedidoServices.cs

   └── ProdutoServices.cs

📁 UI

   └── Menu.cs

📄 Program.cs

---

## 🧠 Arquitetura Utilizada

O projeto foi dividido em camadas para melhor organização:

 ## 📦 Models

Contém as entidades do sistema:

- Cliente
- Endereço
- Pedido
- Produto
- Pagamento

## ⚙ Services

Responsável pelas regras de negócio:

- Criação de pedidos
- Listagem de pedidos
- Gerenciamento de produtos

## 🖥 UI

Responsável pela interação com o usuário:

- Menu principal
- Exibição de opções
- Entrada de dados

## ▶ Program
Ponto de entrada da aplicação.

---

## 🛠 Tecnologias Utilizadas

- C#
- .NET
- Console Application
- Visual Studio
  
---

## 🧠 Conceitos Aplicados

- Programação Orientada a Objetos
- Encapsulamento
- Propriedades (get / set)
- Sobrescrita de ToString()
- List<T>
- Dictionary<TKey, TValue>
- Separação de responsabilidades
- Validação de entrada com while

---

## 🚀 Como Executar

Clone o repositório:

- git clone LINK_DO_SEU_REPOSITORIO

- Abra no Visual Studio

- Execute com Ctrl + F5
  
---

## 🎯 Objetivo

Praticar conceitos fundamentais de POO e organização de código, simulando um sistema real de pedidos.

👨‍💻 Autor

Cauan Nunes
Estudante de Análise e Desenvolvimento de Sistemas
