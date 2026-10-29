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
        //detallesPedido
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        //formaPago
        //formaEntrega
        public Direccion Direccion { get; set; }
        //estadoPedido

    }
}
