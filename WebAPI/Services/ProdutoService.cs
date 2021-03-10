using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.IServices;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services
{
    public class ProdutoService :IProdutoService
    {
        //Metodo para acesso ao sgbd
        LOJAContext dbContext;
        public ProdutoService(LOJAContext _db)
        {
            dbContext = _db;
        }
        //Metodo para retornar os produtos
        public IEnumerable<Produto> GetProdutos()
        {
            var produto = dbContext.Produtos.ToList();
            return produto;
        }
        //Metodo para adicionar novo produto
        public Produto AddProduto(Produto produto)
        {
            if (produto != null)
            {
                dbContext.Produtos.Add(produto);
                dbContext.SaveChanges();
                return produto;
            }
            return null;
        }
        //Metodo para atualizar produto
        public Produto UpdateProduto(Produto produto)
        {
            dbContext.Entry(produto).State = EntityState.Modified;
            dbContext.SaveChanges();
            return produto;
        }
        //Metodo para deletar produto
        public Produto DeleteProduto(int id)
        {
            var produto = dbContext.Produtos.FirstOrDefault(x => x.Id == id);
            dbContext.Entry(produto).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return produto;
        }
        //Metodo para retornar produto pelo id
        public Produto GetProdutoById(int id)
        {
            var produto = dbContext.Produtos.FirstOrDefault(x => x.Id == id);
            return produto;
        }
    }
}
