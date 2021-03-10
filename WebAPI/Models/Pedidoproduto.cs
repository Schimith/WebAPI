using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Pedidoproduto
    {
        public int Id { get; set; }
        public int? Pedido { get; set; }
        public int? Produto { get; set; }

        public virtual Pedido PedidoNavigation { get; set; }
        public virtual Produto ProdutoNavigation { get; set; }
    }
}
