using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    internal class ItemCarrito
    {
        public int IdItemCarrito { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
