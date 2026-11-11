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
            try
            {
                //Si existe el item en el carrito suma 1 en vez de agregar un nuevo item
                //Comprueba q sea stock suficiente para agregar la cantidad deseada
                datos.setearConsulta(@"
                IF @Cantidad <= 0
                    THROW 50001, 'La cantidad debe ser mayor a cero.', 1;

                IF EXISTS (
                    SELECT 1 FROM ITEMCARRITO
                    WHERE IdCarrito = @IdCarrito
                    AND IdProducto = @IdProducto
                 )
                BEGIN
                    IF EXISTS(
                        SELECT 1 FROM PRODUCTO P
                        INNER JOIN ITEMCARRITO IC ON IC.IdProducto = P.IdProducto
                        WHERE IC.IdCarrito = @IdCarrito
                        AND IC.IdProducto = @IdProducto
                        AND P.Stock >= IC.Cantidad + @Cantidad
                    )
                    BEGIN
                        UPDATE ITEMCARRITO
                        SET Cantidad = Cantidad + @Cantidad
                        WHERE IdCarrito = @IdCarrito
                        AND IdProducto = @IdProducto;
                    END
                    ELSE
                        THROW 50002, 'No hay stock suficiente.', 1;
                END
                ELSE
                BEGIN
                    IF EXISTS(
                        SELECT 1 FROM PRODUCTO
                        WHERE IdProducto = @IdProducto
                        AND Stock >= @Cantidad
                    )
                BEGIN
                    INSERT INTO ITEMCARRITO
                    (IdCarrito, IdProducto, Cantidad, PrecioUnitario)
                    VALUES
                    (@IdCarrito, @IdProducto, @Cantidad, @PrecioUnitario);
                END
                ELSE
                    THROW 50002, 'No hay stock suficiente.', 1;
                END
                ");
                //datos.setearConsulta("INSERT INTO ITEMCARRITO (IdCarrito, IdProducto, Cantidad, PrecioUnitario) VALUES (@IdCarrito, @IdProducto, @Cantidad, @PrecioUnitario)");
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
                datos.setearConsulta("UPDATE ITEMCARRITO SET Cantidad = @Cantidad WHERE IdItemCarrito = @IdItemCarrito");
                datos.setearParametro("@IdItemCarrito", IdCarrito);
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
                datos.setearConsulta("DELETE FROM ITEMCARRITO WHERE IdItemCarrito = @IdItemCarrito");
                datos.setearParametro("@IdItemCarrito", IdCarrito);
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

            try
            {
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
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }
    }
}
