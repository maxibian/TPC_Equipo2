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
        public void agregar(int idCliente)
        {
            try
            {
                datos.setearConsulta("IF NOT EXISTS (SELECT 1 FROM CARRITO WHERE IdCliente = @IdCliente) INSERT INTO CARRITO (IdCliente) VALUES (@IdCliente)");
                //datos.setearConsulta("INSERT INTO CARRITO (IdCliente) VALUES (@IdCliente)");
                datos.setearParametro("@IdCliente", idCliente);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public Carrito obtenerCarrito(int IdCliente)
        {
            Carrito carrito = null;
            try
            {
                datos.setearConsulta("SELECT IdCarrito, IdCliente FROM CARRITO WHERE IdCliente = @IdCliente");
                datos.setearParametro("@IdCliente", IdCliente);
                datos.ejecutarLectura();
                
                if (datos.Lector.Read())
                {
                    carrito = new Carrito();
                    carrito.IdCarrito = (int)datos.Lector["IdCarrito"];
                    carrito.IdCliente = (int)datos.Lector["IdCliente"];
                }
                return carrito;
            }
            finally
            {
                datos.cerrarConexion();
            }   
        }

        public Carrito obtenerOCrearCarrito(int idCliente)
        {
            Carrito carrito = obtenerCarrito(idCliente);
            if (carrito == null)
            {
                agregar(idCliente);
                carrito = obtenerCarrito(idCliente);
            }
            return carrito;
        }


        public void pasarItemsDeSession(int idCliente, List<ItemCarrito> listaSession)
        {
            if (listaSession == null || listaSession.Count == 0)
                return;

            Carrito carrito = obtenerOCrearCarrito(idCliente);
            ItemCarritoNegocio itemNegocio = new ItemCarritoNegocio();

            foreach (ItemCarrito item in listaSession)
            {
                try
                {
                    itemNegocio.agregarItemCarrito(carrito.IdCarrito, item.Producto.IdProducto, item.Cantidad, item.PrecioUnitario);
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
        }
    }
}
