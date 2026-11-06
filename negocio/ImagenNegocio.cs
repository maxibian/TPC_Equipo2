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
                datos.setearConsulta("SELECT IdImagen, ImagenUrl FROM IMAGEN");
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.IdImagen = (int)datos.Lector["IdImagen"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
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
        public void agregar(Imagen imagen)
        {

        }
        public void modificar(Imagen imagen)
        {

        }
        public void eliminar(Imagen imagen)
        {

        }
    }
}
