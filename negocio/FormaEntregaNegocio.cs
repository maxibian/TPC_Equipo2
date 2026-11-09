using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class FormaEntregaNegocio
    {
        public List<FormaEntrega> listarFormasEntrega()
        {
            AccesoDatos datos = new AccesoDatos();

            List<FormaEntrega> lista = new List<FormaEntrega>();
            try
            {
                datos.setearConsulta("SELECT IdFormaEntrega, Nombre, Estado FROM FORMAENTREGA");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    FormaEntrega aux = new FormaEntrega();
                    aux.IdFormaEntrega = (int)datos.Lector["IdFormaEntrega"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Estado = (bool)datos.Lector["Estado"];

                    lista.Add(aux);
                }
                return lista;
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
    }
}
