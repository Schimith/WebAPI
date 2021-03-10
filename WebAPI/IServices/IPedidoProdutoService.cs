using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.IServices
{
    public interface IPedidoProdutoService
    {
        //Retorna lista de pedidos por produtos
        IEnumerable<Pedidoproduto> GetPedidosProdutos();
        //Retorna pedido por produto pelo ID
        Pedidoproduto GetPedidoProdutoById(int id);
        //Adiciona novo pedido por produto
        Pedidoproduto AddPedidoProduto(Pedidoproduto pedidoproduto);
        //Atualiza pedido por produto
        Pedidoproduto UpdatePedidoProduto(Pedidoproduto pedidoproduto);
        //Deleta pedido por produto
        Pedidoproduto DeletePedidoProduto(int id);
    }
}
