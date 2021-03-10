using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.IServices;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services
{
    public class ClientePedidoService :IClientePedidoService
    {
        //Metodo para acesso ao sgbd
        LOJAContext dbContext;
        public ClientePedidoService(LOJAContext _db)
        {
            dbContext = _db;
        }
        //Metodo para retornar os pedidos por clientes
        public IEnumerable<Clientepedido> GetClientePedidos()
        {
            var clientepedido = dbContext.Clientepedidos.ToList();
            return clientepedido;
        }
        //Metodo para adicionar novo pedido por cliente
        public Clientepedido AddClientePedido(Clientepedido clientepedido)
        {
            if (clientepedido != null)
            {
                dbContext.Clientepedidos.Add(clientepedido);
                dbContext.SaveChanges();
                return clientepedido;
            }
            return null;
        }
        //Metodo para atualizar pedido por cliente
        public Clientepedido UpdateClientePedido(Clientepedido clientepedido)
        {
            dbContext.Entry(clientepedido).State = EntityState.Modified;
            dbContext.SaveChanges();
            return clientepedido;
        }
        //Metodo para deletar pedido por cliente
        public Clientepedido DeleteClientePedido(int id)
        {
            var clientepedido = dbContext.Clientepedidos.FirstOrDefault(x => x.Id == id);
            dbContext.Entry(clientepedido).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return clientepedido;
        }
        //Metodo para retornar pedido por cliente pelo id
        public Clientepedido GetClientePedidoById(int id)
        {
            var clientepedido = dbContext.Clientepedidos.FirstOrDefault(x => x.Id == id);
            return clientepedido;
        }
    }
}
