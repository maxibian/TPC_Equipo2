using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using dominio;
using negocio;

namespace dominio
{ 
public static class Helper
{
        public static void AgregarAlCarrito(int idProducto)
        {
            var session = HttpContext.Current.Session;

            ItemCarritoNegocio itemNegocio = new ItemCarritoNegocio();


            if (session["cliente"] != null)
            {
                // El cliente está logueado, se puede agregar al carrito
                Cliente cliente = (Cliente)session["cliente"];
                CarritoNegocio carritoNegocio = new CarritoNegocio();
                dominio.Carrito carrito = carritoNegocio.obtenerOCrearCarrito(cliente.IdCliente);

                Producto producto = new ProductoNegocio().obtenerProducto(idProducto);
                itemNegocio.agregarItemCarrito(carrito.IdCarrito, idProducto, 1, producto.Precio);
            }
            else
            {
                // El cliente no está logueado, se puede agregar al carrito de sesión
                List<ItemCarrito> lista = (List<ItemCarrito>)session["Carrito"];
                if (lista == null)
                    lista = new List<ItemCarrito>();

                itemNegocio.agregarItemSession(lista, idProducto, 1);
                session["Carrito"] = lista;
            }
        }

    }
}
