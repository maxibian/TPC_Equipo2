using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Tarjeta
    {
        public int IdTarjeta { get; set; }
        public int IdCliente { get; set; }
        public string NumeroTarjeta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        //public int CodigoSeguridad { get; set; }
        public string NombreYApellidoTitular { get; set; }
        public TipoTarjeta TipoTarjeta { get; set; }
        public MarcaTarjeta MarcaTarjeta { get; set; }
        public bool Estado { get; set; }
    }
}
