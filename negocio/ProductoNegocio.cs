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
                datos.setearConsulta("SELECT P.IdProducto, P.Nombre, P.Descripcion, P.Precio, C.IdCategoria as IdCategoria, C.Nombre as Categoria, P.Estado, P.Stock,I.IdImagen as IdImagen, I.ImagenUrl as Imagen FROM PRODUCTO P INNER JOIN CATEGORIA C ON P.IdCategoria = C.IdCategoria INNER JOIN IMAGEN I ON P.IdImagen = I.IdImagen");
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.IdProducto = (int)datos.Lector["IdProducto"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Nombre = (string)datos.Lector["Categoria"];
                    aux.Estado = (bool)datos.Lector["Estado"];
                    aux.Stock = (int)datos.Lector["Stock"];
                    aux.Imagen = new Imagen();
                    aux.Imagen.IdImagen = (int)datos.Lector["IdImagen"];
                    aux.Imagen.ImagenUrl = (string)datos.Lector["Imagen"];
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
