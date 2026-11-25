using dominio;
using System;
using System.Collections;
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
            if (Cantidad <= 0)
                throw new Exception("La cantidad debe ser mayor a cero.");
            try
            {
                datos.setearConsulta("SELECT Cantidad FROM ITEMCARRITO WHERE IdCarrito = @IdCarrito AND IdProducto = @IdProducto");
                datos.setearParametro("@IdCarrito", IdCarrito);
                datos.setearParametro("@IdProducto", IdProducto);
                int enCarrito = datos.ejecutarEscalar();      

                datos.setearConsulta("SELECT Stock FROM PRODUCTO WHERE IdProducto = @IdProducto");
                datos.setearParametro("@IdProducto", IdProducto);
                int stock = datos.ejecutarEscalar();

                if (enCarrito + Cantidad > stock)

                    throw new Exception("No hay stock suficiente.");

                if (enCarrito > 0)
                {
                    datos.setearConsulta("UPDATE ITEMCARRITO SET Cantidad = Cantidad + @Cantidad WHERE IdCarrito = @IdCarrito AND IdProducto = @IdProducto");
                }
                else
                {
                    datos.setearConsulta("INSERT INTO ITEMCARRITO (IdCarrito, IdProducto, Cantidad, PrecioUnitario) VALUES (@IdCarrito, @IdProducto, @Cantidad, @PrecioUnitario)");
                    datos.setearParametro("@PrecioUnitario", PrecioUnitario);
                }
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

        public void agregarItemSession(List<ItemCarrito> lista, int idProducto, int cantidad)
        {
            if (cantidad <= 0)
                throw new Exception("La cantidad debe ser mayor a cero.");

            
            foreach (ItemCarrito item in lista)
            {
                if (item.Producto.IdProducto == idProducto)
                {
                    if (item.Producto.Stock < item.Cantidad + cantidad)
                        throw new Exception("No hay stock suficiente.");

                    item.Cantidad += cantidad;
                    return;
                }
            }

            
            ProductoNegocio productoNegocio = new ProductoNegocio();
            Producto producto = productoNegocio.obtenerProducto(idProducto);
            if (producto == null)
                return;

            if (producto.Stock < cantidad)
                throw new Exception("No hay stock suficiente.");

            ItemCarrito nuevo = new ItemCarrito();
            nuevo.Producto = producto;
            nuevo.Cantidad = cantidad;
            nuevo.PrecioUnitario = producto.Precio;
            lista.Add(nuevo);
        }

        public void modificarItemSession(List<ItemCarrito> lista, int idProducto, int cantidad)
        {
            foreach (ItemCarrito item in lista)
            {
                if (item.Producto.IdProducto == idProducto)
                {
                    item.Cantidad = cantidad;
                    return;
                }
            }
        }

        public void eliminarItemSession(List<ItemCarrito> lista, int idProducto)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Producto.IdProducto == idProducto)
                {
                    lista.RemoveAt(i);
                    return;
                }
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



        public void vaciarCarrito(int idCarrito)
        {
            try
            {
                datos.setearConsulta("DELETE FROM ITEMCARRITO WHERE IdCarrito = @IdCarrito");
                datos.setearParametro("@IdCarrito", idCarrito);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<ItemCarrito> listar(int idCarrito)
        {
            List<ItemCarrito> lista = new List<ItemCarrito>();

            try
            {
                datos.setearConsulta("SELECT IC.IdItemCarrito, IC.IdCarrito,IC.IdProducto, IC.Cantidad, IC.PrecioUnitario,P.Nombre, P.Descripcion, P.Precio, P.Stock FROM ITEMCARRITO IC INNER JOIN PRODUCTO P ON P.IdProducto = IC.IdProducto WHERE IC.IdCarrito = @IdCarrito ORDER BY IC.IdItemCarrito");
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
                    if (datos.Lector["Descripcion"] != DBNull.Value)
                        producto.Descripcion = (string)datos.Lector["Descripcion"];
                    producto.Precio = (decimal)datos.Lector["Precio"];
                    producto.Stock = (int)datos.Lector["Stock"];

                    item.Producto = producto;

                    lista.Add(item);
                }
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }
    }
}
