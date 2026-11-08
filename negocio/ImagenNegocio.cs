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
        public List<Imagen> listarImagenes()
        {
            List<Imagen> lista = new List<Imagen>();
            try
            {
                datos.setearConsulta("SELECT IdImagen, ImagenUrl, Estado FROM IMAGEN");
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.IdImagen = (int)datos.Lector["IdImagen"];
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
                datos.setearConsulta("INSERT INTO IMAGEN (ImagenUrl) VALUES (@ImagenUrl)");
                datos.setearParametro("@ImagenUrl", imagen.ImagenUrl);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void modificar(Imagen imagen)
        {

        }
        public void eliminar(Imagen imagen)
        {

        }
    }
}
