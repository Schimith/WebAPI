using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.IServices;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services
{
    public class ClienteService :IClienteService
    {
        //Metodo para acesso ao sgbd
        LOJAContext dbContext;
        public ClienteService(LOJAContext _db)
        {
            dbContext = _db;
        }
        //Metodo para retornar os clientes
        public IEnumerable<Cliente> GetCliente()
        {
            var cliente = dbContext.Clientes.ToList();
            return cliente;
        }
        //Metodo para adicionar novo cliente
        public Cliente AddCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                dbContext.Clientes.Add(cliente);
                dbContext.SaveChanges();
                return cliente;
            }
            return null;
        }
        //Metodo para atualizar cliente
        public Cliente UpdateCliente(Cliente cliente)
        {
            dbContext.Entry(cliente).State = EntityState.Modified;
            dbContext.SaveChanges();
            return cliente;
        }
        //Metodo para deletar cliente
        public Cliente DeleteCliente(int id)
        {
            var cliente = dbContext.Clientes.FirstOrDefault(x => x.Id == id);
            dbContext.Entry(cliente).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return cliente;
        }
        //Metodo para retornar cliente pelo id
        public Cliente GetClienteById(int id)
        {
            var cliente = dbContext.Clientes.FirstOrDefault(x => x.Id == id);
            return cliente;
        }
    }
}
