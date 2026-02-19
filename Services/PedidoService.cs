using System;
using System.Collections.Generic;
using System.Text;
using Primeiro_Projeto.Models;

namespace Primeiro_Projeto.Services
{
    public class PedidoService
    {
        private List<Pedido> _pedidosCriados;

        public PedidoService()
        {
            _pedidosCriados = new List<Pedido>();
        }

        public void AdicionarPedido(Pedido pedido)
        {
            _pedidosCriados.Add(pedido);
        }

        public List<Pedido> ListarPedidosCriados()
        {
            return _pedidosCriados;
        }

    }

}
