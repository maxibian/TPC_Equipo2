using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ItemCarritoNegocio
    {
        //public int IdItemCarrito { get; set; }
        //public int IdCarrito { get; set; }
        //public Producto Producto { get; set; }
        //public int Cantidad { get; set; }

        AccesoDatos datos = new AccesoDatos();

        public void agregarItemCarrito(int IdCarrito, int IdProducto, int Cantidad)
        {
            try
            {
                datos.setearConsulta("INSERT INTO ITEMCARRITO (IdCarrito, IdProducto, Cantidad) VALUES (@IdCarrito, @IdProducto, @Cantidad)");
                datos.setearParametro("@IdCarrito", IdCarrito);
                datos.setearParametro("@IdProducto", IdProducto);
                datos.setearParametro("@Cantidad", Cantidad);
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

        public void modificarItemCarrito(int IdCarrito, int IdProducto, int Cantidad)
        {
            try
            {
                datos.setearConsulta("UPDATE ITEMCARRITO SET Cantidad = @Cantidad WHERE IdCarrito = @IdCarrito AND IdProducto = @IdProducto");
                datos.setearParametro("@IdCarrito", IdCarrito);
                datos.setearParametro("@IdProducto", IdProducto);
                datos.setearParametro("@Cantidad", Cantidad);
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
        public void eliminarItemCarrito(int IdCarrito, int IdProducto)
        {
            try
            {
                datos.setearConsulta("DELETE FROM ITEMCARRITO WHERE IdCarrito = @IdCarrito AND IdProducto = @IdProducto");
                datos.setearParametro("@IdCarrito", IdCarrito);
                datos.setearParametro("@IdProducto", IdProducto);
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
    }
}
