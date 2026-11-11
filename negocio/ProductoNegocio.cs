using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ProductoNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Producto> listarProductos()
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                datos.setearConsulta("SELECT P.IdProducto, P.Nombre, P.Descripcion, P.Precio, P.Estado AS EstadoProducto, P.Stock,  C.IdCategoria, C.Nombre as NombreCategoria, C.Estado AS EstadoCategoria, I.IdImagen, I.ImagenUrl as Imagen, I.Estado AS EstadoImagen FROM PRODUCTO P INNER JOIN CATEGORIA C ON P.IdCategoria = C.IdCategoria LEFT JOIN IMAGEN I ON P.IdProducto = I.IdProducto AND I.Estado = 1 WHERE P.Estado = 1");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.IdProducto = (int)datos.Lector["IdProducto"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    if (datos.Lector["Descripcion"] != DBNull.Value)
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Estado = (bool)datos.Lector["EstadoProducto"];
                    aux.Stock = (int)datos.Lector["Stock"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Nombre = (string)datos.Lector["NombreCategoria"];
                    aux.Categoria.Estado = (bool)datos.Lector["EstadoCategoria"];

                    if (datos.Lector["IdImagen"] != DBNull.Value)
                    {
                        aux.Imagen = new Imagen();
                        aux.Imagen.IdImagen = (int)datos.Lector["IdImagen"];
                        aux.Imagen.ImagenUrl = (string)datos.Lector["Imagen"];
                        aux.Imagen.Estado = (bool)datos.Lector["EstadoImagen"];
                    }
                    
                    lista.Add(aux);
                }
                return lista;
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
        public void agregar(Producto producto)
        {

            try
            {
                datos.setearConsulta(
                    "INSERT INTO PRODUCTO (Nombre, Descripcion, Precio, IdCategoria, Estado, Stock) VALUES (@Nombre, @Descripcion, @Precio, @IdCategoria, @Estado, @Stock);SELECT SCOPE_IDENTITY()");
                datos.setearParametro("@Nombre", producto.Nombre);
                if (producto.Descripcion != null)
                {
                    datos.setearParametro("@Descripcion", producto.Descripcion);
                }
                else
                {
                    datos.setearParametro("@Descripcion", DBNull.Value);
                }
                datos.setearParametro("@Precio", producto.Precio);
                datos.setearParametro("@IdCategoria", producto.Categoria.IdCategoria);
                datos.setearParametro("@Estado", 1);
                datos.setearParametro("@Stock", producto.Stock);

                producto.IdProducto = datos.ejecutarEscalar();
            }
            finally
            {
                datos.cerrarConexion();
            }
            if (producto.Imagen != null && !string.IsNullOrWhiteSpace(producto.Imagen.ImagenUrl))
            {
                producto.Imagen.IdProducto = producto.IdProducto;
                new ImagenNegocio().agregarImagen(producto.Imagen);
            }
        }
        public void modificar(Producto producto)
        {
            try
            {
                datos.setearConsulta(
                    "UPDATE PRODUCTO SET Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, IdCategoria = @IdCategoria, Stock = @Stock WHERE IdProducto = @IdProducto");
                datos.setearParametro("@Nombre", producto.Nombre);
                if (producto.Descripcion != null)
                {
                    datos.setearParametro("@Descripcion", producto.Descripcion);
                }
                else
                {
                    datos.setearParametro("@Descripcion", DBNull.Value);
                }
                datos.setearParametro("@Precio", producto.Precio);
                datos.setearParametro("@IdCategoria", producto.Categoria.IdCategoria);
                datos.setearParametro("@Stock", producto.Stock);
                datos.setearParametro("@IdProducto", producto.IdProducto);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminar(Producto producto) // baja logica
        {
            try
            {
                datos.setearConsulta("UPDATE PRODUCTO SET Estado = 0 WHERE IdProducto = @IdProducto");
                datos.setearParametro("@IdProducto", producto.IdProducto);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Producto> listarCategoria(int id)
        {
            List<Producto> lista = new List<Producto>();
            
            try
            {
                datos.setearConsulta("SELECT P.IdProducto, P.Nombre, P.Descripcion, P.Precio, P.Stock, P.Estado as EstadoProducto, I.ImagenUrl FROM PRODUCTO P INNER JOIN CATEGORIA C ON P.IdCategoria = C.IdCategoria INNER JOIN IMAGEN I ON P.IdProducto = I.IdProducto WHERE P.IdCategoria = @id;");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.IdProducto = (int)datos.Lector["IdProducto"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    if (datos.Lector["Descripcion"] != DBNull.Value)
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Estado = (bool)datos.Lector["EstadoProducto"];
                    aux.Stock = (int)datos.Lector["Stock"];
                    
                    aux.Imagen = new Imagen();
                    aux.Imagen.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);

                }

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally { datos.cerrarConexion(); }
        }
        public Producto obtenerProducto(int idProducto)
        {
            try
            {
                datos.setearConsulta("SELECT P.IdProducto, P.Nombre, P.Descripcion, P.Precio, P.Stock, P.Estado as EstadoProducto, I.ImagenUrl FROM PRODUCTO P INNER JOIN CATEGORIA C ON P.IdCategoria = C.IdCategoria INNER JOIN IMAGEN I ON P.IdProducto = I.IdProducto WHERE P.IdProducto = @id;");
                datos.setearParametro("@id", idProducto);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.IdProducto = (int)datos.Lector["IdProducto"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    if (datos.Lector["Descripcion"] != DBNull.Value)
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Estado = (bool)datos.Lector["EstadoProducto"];
                    aux.Stock = (int)datos.Lector["Stock"];
                    aux.Imagen = new Imagen();
                    aux.Imagen.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    return aux;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}

