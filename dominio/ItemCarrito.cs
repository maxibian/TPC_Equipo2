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
        public decimal PrecioUnitario { get; set; }

        public string NombreProducto
        {
            get { return Producto.Nombre; }
        }
        public decimal Subtotal
        {
            get { return Cantidad * PrecioUnitario; }
        }
    }

}



