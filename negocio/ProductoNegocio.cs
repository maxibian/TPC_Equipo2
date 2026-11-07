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
                datos.setearConsulta("SELECT P.IdProducto, P.Nombre, P.Descripcion, P.Precio, P.Estado AS EstadoProducto, P.Stock,  C.IdCategoria, C.Nombre as NombreCategoria, C.Estado AS EstadoCategoria, I.IdImagen as IdImagen, I.ImagenUrl as Imagen, I.Estado FROM PRODUCTO P INNER JOIN CATEGORIA C ON P.IdCategoria = C.IdCategoria INNER JOIN IMAGEN I ON P.IdImagen = I.IdImagen");
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.IdProducto = (int)datos.Lector["IdProducto"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    if (datos.Lector["Descripcion"] != DBNull.Value)
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Estado = (bool)datos.Lector["Estado"];
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
                        aux.Imagen.Estado = (bool)datos.Lector["Estado"];
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

        }
        public void modificar(Producto producto)
        {

        }
        public void eliminar(Producto producto) // baja logica
        {

        }
    }
}
