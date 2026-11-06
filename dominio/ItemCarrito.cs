using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class ItemCarrito
    {
        public int IdItemCarrito { get; set; }
        public int IdCarrito { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }
}



