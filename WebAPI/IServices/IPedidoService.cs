using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.IServices
{
    public interface IPedidoService
    {
        //Retorna lista de pedidos
        IEnumerable<Pedido> GetPedidos();
        //Retorna pedido pelo ID
        Pedido GetPedidoById(int id);
        //Adiciona novo pedido
        Pedido AddPedido(Pedido pedido);
        //Atualiza pedido
        Pedido UpdatePedido(Pedido pedido);
        //Deleta pedido
        Pedido DeletePedido(int id);
    }
}
