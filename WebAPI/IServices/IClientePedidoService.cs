using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.IServices
{
    public interface IClientePedidoService
    {
        //Retorna lista de pedidos por clientes
        IEnumerable<Clientepedido> GetClientePedidos();
        //Retorna pedido por cliente pelo ID
        Clientepedido GetClientePedidoById(int id);
        //Adiciona novo pedido por cliente
        Clientepedido AddClientePedido(Clientepedido clientepedido);
        //Atualiza pedido por cliente
        Clientepedido UpdateClientePedido(Clientepedido clientepedido);
        //Deleta pedido por cliente
        Clientepedido DeleteClientePedido(int id);
    }
}
