using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    internal class Tarjeta
    {
        public int IdTarjeta { get; set; }
        public int NumeroTarjeta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int CodigoSeguridad { get; set; }
        public TipoTarjeta TipoTarjeta { get; set; }
        public bool Estado { get; set; }
    }
}
