using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Clientepedidos = new HashSet<Clientepedido>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Clientepedido> Clientepedidos { get; set; }
    }
}
