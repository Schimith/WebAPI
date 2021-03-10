using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.IServices
{
    public interface IClienteService
    {
        //Retorna lista de clientes
        IEnumerable<Cliente> GetCliente();
        //Retorna cliente pelo ID
        Cliente GetClienteById(int id);
        //Adiciona novo cliente
        Cliente AddCliente(Cliente cliente);
        //Atualiza cliente
        Cliente UpdateCliente(Cliente cliente);
        //Deleta cliente
        Cliente DeleteCliente(int id);
    }
}
