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
        AccesoDatos datos = new AccesoDatos();

        public void agregarItemCarrito(int IdCarrito, int IdProducto, int Cantidad, decimal PrecioUnitario)
        {
            try
            {
                datos.setearConsulta("INSERT INTO ITEMCARRITO (IdCarrito, IdProducto, Cantidad, PrecioUnitario) VALUES (@IdCarrito, @IdProducto, @Cantidad, @PrecioUnitario)");
                datos.setearParametro("@IdCarrito", IdCarrito);
                datos.setearParametro("@IdProducto", IdProducto);
                datos.setearParametro("@Cantidad", Cantidad);
                datos.setearParametro("@PrecioUnitario", PrecioUnitario);
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

        public void modificarItemCarrito(int IdCarrito, int Cantidad)
        {
            try
            {
                datos.setearConsulta("UPDATE ITEMCARRITO SET Cantidad = @Cantidad WHERE IdCarrito = @IdCarrito");
                datos.setearParametro("@IdCarrito", IdCarrito);
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
        public void eliminarItemCarrito(int IdCarrito)
        {
            try
            {
                datos.setearConsulta("DELETE FROM ITEMCARRITO WHERE IdCarrito = @IdCarrito");
                datos.setearParametro("@IdCarrito", IdCarrito);
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
        public List<ItemCarrito> listar(int idCarrito)
        {
            List<ItemCarrito> lista = new List<ItemCarrito>();

            datos.setearConsulta("SELECT IC.IdItemCarrito, IC.IdCarrito,IC.IdProducto, IC.Cantidad, IC.PrecioUnitario,P.Nombre, P.Descripcion, P.Precio, P.Stock FROM ITEMCARRITO IC INNER JOIN PRODUCTO P ON P.IdProducto = IC.IdProducto WHERE IC.IdCarrito = @IdCarrito");
            datos.setearParametro("@IdCarrito", idCarrito);
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                ItemCarrito item = new ItemCarrito();

                item.IdItemCarrito = (int)datos.Lector["IdItemCarrito"];
                item.IdCarrito = (int)datos.Lector["IdCarrito"];
                item.Cantidad = (int)datos.Lector["Cantidad"];
                item.PrecioUnitario = (decimal)datos.Lector["PrecioUnitario"];

                Producto producto = new Producto();

                producto.IdProducto = (int)datos.Lector["IdProducto"];
                producto.Nombre = (string)datos.Lector["Nombre"];
                producto.Descripcion = (string)datos.Lector["Descripcion"];
                producto.Precio = (decimal)datos.Lector["Precio"];
                producto.Stock = (int)datos.Lector["Stock"];

                item.Producto = producto;

                lista.Add(item);
            }

            datos.cerrarConexion();

            return lista;
        }
    }
}
