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
    //Contexto /api/pedidos
    [ApiController]
    [Route("api/pedidos")]
    public class PedidoController : ControllerBase
    {
        //Metodo para acesso a interface pedido
        private readonly IPedidoService pedidoService;
        public PedidoController(IPedidoService pedido)
        {
            pedidoService = pedido;
        }
        //Metodo para o contexto raiz /api/pedidos
        [HttpGet]        
        [Route("")]
        public IEnumerable<Pedido> GetPedidos()
        {
            return pedidoService.GetPedidos();
        }
        //Metodo para o contexto /api/pedidos/add
        [HttpPost]        
        [Route("add")]
        public Pedido AddPedido(Pedido pedido)
        {
            return pedidoService.AddPedido(pedido);
        }
        //Metodo para o contexto /api/pedidos/edit
        [HttpPut]
        [Route("edit")]
        public Pedido EditPedido(Pedido pedido)
        {
            return pedidoService.UpdatePedido(pedido);
        }
        //Metodo para o contexto /api/pedidos/delete?id=chaveprimaria
        [HttpDelete]        
        [Route("delete")]
        public Pedido DeletePedido(int id)
        {
            return pedidoService.DeletePedido(id);
        }
        //Metodo para o contexto /api/pedidos/get?id=chaveprimaria
        [HttpGet]        
        [Route("get")]
        public Pedido GetPedidoId(int id)
        {
            return pedidoService.GetPedidoById(id);
        }
    }
}
