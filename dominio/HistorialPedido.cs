using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class HistorialPedido
    {
        public int IdHistorialPedido { get; set; }
        public Pedido IdPedido { get; set; }
        public Cliente IdCliente { get; set; }
    }
}
