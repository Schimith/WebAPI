using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.IServices;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services
{
    public class PedidoProdutoService :IPedidoProdutoService
    {
        //Metodo para acesso ao sgbd
        LOJAContext dbContext;
        public PedidoProdutoService(LOJAContext _db)
        {
            dbContext = _db;
        }
        //Metodo para retornar os pedidos por produtos
        public IEnumerable<Pedidoproduto> GetPedidosProdutos()
        {
            var pedidoproduto = dbContext.Pedidoprodutos.ToList();
            return pedidoproduto;
        }
        //Metodo para adicionar novo pedido por produto
        public Pedidoproduto AddPedidoProduto(Pedidoproduto pedidoproduto)
        {
            if (pedidoproduto != null)
            {
                dbContext.Pedidoprodutos.Add(pedidoproduto);
                dbContext.SaveChanges();
                return pedidoproduto;
            }
            return null;
        }
        //Metodo para atualizar pedido por produto
        public Pedidoproduto UpdatePedidoProduto(Pedidoproduto pedidoproduto)
        {
            dbContext.Entry(pedidoproduto).State = EntityState.Modified;
            dbContext.SaveChanges();
            return pedidoproduto;
        }
        //Metodo para deletar pedido por produto
        public Pedidoproduto DeletePedidoProduto(int id)
        {
            var pedidoproduto = dbContext.Pedidoprodutos.FirstOrDefault(x => x.Id == id);
            dbContext.Entry(pedidoproduto).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return pedidoproduto;
        }
        //Metodo para retornar pedido por produto pelo id
        public Pedidoproduto GetPedidoProdutoById(int id)
        {
            var pedidoproduto = dbContext.Pedidoprodutos.FirstOrDefault(x => x.Id == id);
            return pedidoproduto;
        }
    }
}
