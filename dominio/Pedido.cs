using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    internal class Pedido
    {
        public int IdPedido { get; set; }
        public Cliente Cliente { get; set; }
        public List<DetallePedido> DetallesPedido { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public FormaPago FormaPago { get; set; }
        public FormaEntrega FormaEntrega { get; set; }
        public Direccion Direccion { get; set; }
        public EstadoPedido EstadoPedido { get; set; }

    }
}
