using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            Clientepedidos = new HashSet<Clientepedido>();
            Pedidoprodutos = new HashSet<Pedidoproduto>();
        }

        public int Id { get; set; }
        public DateTime? Datapedido { get; set; }
        public float? Total { get; set; }

        public virtual ICollection<Clientepedido> Clientepedidos { get; set; }
        public virtual ICollection<Pedidoproduto> Pedidoprodutos { get; set; }
    }
}
