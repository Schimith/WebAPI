using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Produto
    {
        public Produto()
        {
            Pedidoprodutos = new HashSet<Pedidoproduto>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Pedidoproduto> Pedidoprodutos { get; set; }
    }
}
