using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.IServices;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    //Contexto /api/clientes/pedidos
    [ApiController]
    [Route("api/clientes/pedidos")]
    public class ClientePedidoController : ControllerBase
    {
        //Metodo para acesso a interface clientePedido
        private readonly IClientePedidoService clientePedidoService;
        public ClientePedidoController(IClientePedidoService clientePedido)
        {
            clientePedidoService = clientePedido;
        }
        //Metodo para o contexto raiz /api/clientes/pedidos
        [HttpGet]        
        [Route("")]
        public IEnumerable<Clientepedido> GetClientesPedidos()
        {
            return clientePedidoService.GetClientePedidos();
        }
        //Metodo para o contexto /api/clientes/pedidos/add
        [HttpPost]        
        [Route("add")]
        public Clientepedido AddClientePedido(Clientepedido clientePedido)
        {
            return clientePedidoService.AddClientePedido(clientePedido);
        }
        //Metodo para o contexto /api/clientes/pedidos/edit
        [HttpPut]
        [Route("edit")]
        public Clientepedido EditClientePedido(Clientepedido clientePedido)
        {
            return clientePedidoService.UpdateClientePedido(clientePedido);
        }
        //Metodo para o contexto /api/clientes/pedidos/delete?id=chaveprimaria
        [HttpDelete]        
        [Route("delete")]
        public Clientepedido DeleteClientePedido(int id)
        {
            return clientePedidoService.DeleteClientePedido(id);
        }
        //Metodo para o contexto /api/clientes/pedidos/get?id=chaveprimaria
        [HttpGet]        
        [Route("get")]
        public Clientepedido GetClientePedidoId(int id)
        {
            return clientePedidoService.GetClientePedidoById(id);
        }
    }
}
