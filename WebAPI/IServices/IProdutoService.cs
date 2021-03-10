using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.IServices
{
    public interface IProdutoService
    {
        //Retorna lista de produtos
        IEnumerable<Produto> GetProdutos();
        //Retorna produto pelo ID
        Produto GetProdutoById(int id);
        //Adiciona novo produto
        Produto AddProduto(Produto produto);
        //Atualiza produto
        Produto UpdateProduto(Produto produto);
        //Deleta produto
        Produto DeleteProduto(int id);
    }
}
