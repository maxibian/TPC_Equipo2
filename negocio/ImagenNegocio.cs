using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace negocio
{
    public class ImagenNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Imagen> listarImagenesPorProducto(int idProducto)
        {
            List<Imagen> lista = new List<Imagen>();
            try
            {
                datos.setearConsulta("SELECT IdImagen, IdProducto ImagenUrl, Estado FROM IMAGEN WHERE IdProducto = @IdProducto AND Estado = 1");
                datos.setearParametro("@IdProducto", idProducto);
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.IdImagen = (int)datos.Lector["IdImagen"];
                    aux.IdProducto = (int)datos.Lector["IdProducto"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Estado = (bool)datos.Lector["Estado"];
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
        public void agregarImagen(Imagen imagen)
        {
            try
            {
                datos.setearConsulta("INSERT INTO IMAGEN (IdProducto, ImagenUrl, Estado) VALUES (@IdProducto, @ImagenUrl, @Estado)");
                datos.setearParametro("@IdProducto", imagen.IdProducto);
                datos.setearParametro("@ImagenUrl", imagen.ImagenUrl);
                datos.setearParametro("@Estado", 1);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void modificar(Imagen imagen)
        {
            try
            {
                datos.setearConsulta("UPDATE IMAGEN SET ImagenUrl = @ImagenUrl WHERE IdImagen = @IdImagen");
                datos.setearParametro("@ImagenUrl", imagen.ImagenUrl);
                datos.setearParametro("@IdImagen", imagen.IdImagen);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminar(Imagen imagen)
        {
            try
            {
                datos.setearConsulta("UPDATE IMAGEN SET Estado = 0 WHERE IdImagen = @IdImagen");
                datos.setearParametro("@IdImagen", imagen.IdImagen);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
