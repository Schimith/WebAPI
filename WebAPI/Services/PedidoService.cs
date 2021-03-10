using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.IServices;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services
{
    public class PedidoService :IPedidoService
    {
        //Metodo para acesso ao sgbd
        LOJAContext dbContext;
        public PedidoService(LOJAContext _db)
        {
            dbContext = _db;
        }
        //Metodo para retornar os pedidos
        public IEnumerable<Pedido> GetPedidos()
        {
            var pedido = dbContext.Pedidos.ToList();
            return pedido;
        }
        //Metodo para adicionar novo pedido
        public Pedido AddPedido(Pedido pedido)
        {
            if (pedido != null)
            {
                dbContext.Pedidos.Add(pedido);
                dbContext.SaveChanges();
                return pedido;
            }
            return null;
        }
        //Metodo para atualizar pedido
        public Pedido UpdatePedido(Pedido pedido)
        {
            dbContext.Entry(pedido).State = EntityState.Modified;
            dbContext.SaveChanges();
            return pedido;
        }
        //Metodo para deletar pedido
        public Pedido DeletePedido(int id)
        {
            var pedido = dbContext.Pedidos.FirstOrDefault(x => x.Id == id);
            dbContext.Entry(pedido).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return pedido;
        }
        //Metodo para retornar pedido pelo id
        public Pedido GetPedidoById(int id)
        {
            var pedido = dbContext.Pedidos.FirstOrDefault(x => x.Id == id);
            return pedido;
        }
    }
}
