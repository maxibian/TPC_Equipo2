using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Direccion
    {

        public int IdDireccion { get; set; }

        public int IdCliente { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Localidad { get; set; }
        public string CodigoPostal { get; set; }
        public string Observacion { get; set; }


    }
}
