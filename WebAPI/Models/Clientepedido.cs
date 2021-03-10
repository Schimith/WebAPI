using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Clientepedido
    {
        public int Id { get; set; }
        public int? Cliente { get; set; }
        public int? Pedido { get; set; }

        public virtual Cliente ClienteNavigation { get; set; }
        public virtual Pedido PedidoNavigation { get; set; }
    }
}
