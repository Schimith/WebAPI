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
    //Contexto /api/pedidos/produtos
    [ApiController]
    [Route("api/pedidos/produtos")]
    public class PedidoProdutoController : ControllerBase
    {
        //Metodo para acesso a interface pedidoProduto
        private readonly IPedidoProdutoService pedidoProdutoService;
        public PedidoProdutoController(IPedidoProdutoService pedidoProduto)
        {
            pedidoProdutoService = pedidoProduto;
        }
        //Metodo para o contexto raiz /api/pedidos/produtos
        [HttpGet]        
        [Route("")]
        public IEnumerable<Pedidoproduto> GetPedidosProdutos()
        {
            return pedidoProdutoService.GetPedidosProdutos();
        }
        //Metodo para o contexto /api/pedidos/produtos/add
        [HttpPost]        
        [Route("add")]
        public Pedidoproduto AddPedidoProduto(Pedidoproduto pedidoProduto)
        {
            return pedidoProdutoService.AddPedidoProduto(pedidoProduto);
        }
        //Metodo para o contexto /api/pedidos/produtos/edit
        [HttpPut]
        [Route("edit")]
        public Pedidoproduto EditPedidoProduto(Pedidoproduto pedidoProduto)
        {
            return pedidoProdutoService.UpdatePedidoProduto(pedidoProduto);
        }
        //Metodo para o contexto /api/pedidos/produtos/delete?id=chaveprimaria
        [HttpDelete]        
        [Route("delete")]
        public Pedidoproduto DeletePedido(int id)
        {
            return pedidoProdutoService.DeletePedidoProduto(id);
        }
        //Metodo para o contexto /api/pedidos/produtos/get?id=chaveprimaria
        [HttpGet]        
        [Route("get")]
        public Pedidoproduto GetPedidoProdutoId(int id)
        {
            return pedidoProdutoService.GetPedidoProdutoById(id);
        }
    }
}
