using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal VentaTotal { get; set; }
        public FormaPago FormaPago { get; set; }
        public FormaEntrega FormaEntrega { get; set; }
        public Direccion Direccion { get; set; }
        public Tarjeta Tarjeta { get; set; }

    }
}
