using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CarritoNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public Carrito obtenerCarrito(int IdCliente)
        {
            Carrito a = new Carrito();
            return a;
            //para que compile
        }
        public void agregarProducto(int IdCarrito, int IdProducto)
        {

        }
        public void quitarProducto(int IdCarrito, int IdProducto)
        {

        }
        public void modificarCantidad(int IdCarrito,int IdProducto, int Cantidad)
        {

        }

    }
}
