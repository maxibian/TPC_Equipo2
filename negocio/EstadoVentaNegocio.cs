using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EstadoVentaNegocio
    {
        public List<EstadoVenta> listar()
        {
            AccesoDatos datos = new AccesoDatos();

            List<EstadoVenta> lista = new List<EstadoVenta>();

            try
            {
                datos.setearConsulta("SELECT IdEstadoVenta, Nombre FROM ESTADOVENTA");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    EstadoVenta aux = new EstadoVenta();
                    aux.IdEstadoVenta = (int)datos.Lector["IdEstadoVenta"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

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
