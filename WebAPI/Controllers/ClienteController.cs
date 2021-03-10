using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.OData;
using WebAPI.IServices;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    //Contexto /api/clientes
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        //Metodo para acesso a interface cliente
        private readonly IClienteService clienteService;
        public ClienteController(IClienteService cliente)
        {
            clienteService = cliente;
        }
        //Metodo para o contexto raiz /api/clientes
        [HttpGet]
        [Route("")]
        //Odata
        [EnableQuery]
        public IEnumerable<Cliente> GetClientes()
        {
            return clienteService.GetCliente();
        }
        //Metodo para o contexto /api/clientes/add
        [HttpPost]        
        [Route("add")]
        public Cliente AddCliente(Cliente cliente)
        {
            return clienteService.AddCliente(cliente);
        }
        //Metodo para o contexto /api/clientes/edit
        [HttpPut]
        [Route("edit")]
        public Cliente EditCliente(Cliente cliente)
        {
            return clienteService.UpdateCliente(cliente);
        }
        //Metodo para o contexto /api/clientes/delete?id=chaveprimaria
        [HttpDelete]        
        [Route("delete")]
        public Cliente DeleteCliente(int id)
        {
            return clienteService.DeleteCliente(id);
        }
        //Metodo para o contexto /api/clientes/get?id=chaveprimaria
        [HttpGet]        
        [Route("get")]
        public Cliente GetClienteId(int id)
        {
            return clienteService.GetClienteById(id);
        }
    }
}
