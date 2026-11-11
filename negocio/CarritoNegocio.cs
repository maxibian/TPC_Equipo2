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
                datos.setearConsulta("INSERT INTO CARRITO (IdCliente) VALUES (@IdCliente)");
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
                    carrito.IdCarrito = (int)datos.Lector["IdCarrito"];
                    carrito.IdCliente = (int)datos.Lector["IdCliente"];
                }
            }
            finally
            {
                datos.cerrarConexion();
            }
            return carrito;
        }
        public void eliminar(int idCarrito)
        {
            try
            {
                datos.setearConsulta("DELETE FROM CARRITO WHERE IdCarrito = @IdCarrito");
                datos.setearParametro("@IdCarrito", idCarrito);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
