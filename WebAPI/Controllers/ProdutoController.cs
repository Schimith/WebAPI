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
    //Contexto /api/produtos
    [ApiController]
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        //Metodo para acesso a interface produto
        private readonly IProdutoService produtoService;
        public ProdutoController(IProdutoService produto)
        {
            produtoService = produto;
        }
        //Metodo para o contexto raiz /api/produtos
        [HttpGet]        
        [Route("")]
        public IEnumerable<Produto> GetProdutos()
        {
            return produtoService.GetProdutos();
        }
        //Metodo para o contexto /api/produtos/add
        [HttpPost]        
        [Route("add")]
        public Produto AddProduto(Produto produto)
        {
            return produtoService.AddProduto(produto);
        }
        //Metodo para o contexto /api/produtos/edit
        [HttpPut]
        [Route("edit")]
        public Produto EditProduto(Produto produto)
        {
            return produtoService.UpdateProduto(produto);
        }
        //Metodo para o contexto /api/produtos/delete?id=chaveprimaria
        [HttpDelete]        
        [Route("delete")]
        public Produto DeleteProduto(int id)
        {
            return produtoService.DeleteProduto(id);
        }
        //Metodo para o contexto /api/produtos/get?id=chaveprimaria
        [HttpGet]        
        [Route("get")]
        public Produto GetProdutoId(int id)
        {
            return produtoService.GetProdutoById(id);
        }
    }
}
