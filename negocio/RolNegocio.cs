using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
namespace negocio
{
    public class RolNegocio
    {
        AccesoDatos datos = new AccesoDatos();

        public List<Rol> ListarRoles()
        {
            List<Rol> lista = new List<Rol>();
            try
            {
                datos.setearConsulta("SELECT IdRol, Nombre FROM Rol");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Rol aux = new Rol();

                    aux.IdRol = (int)datos.Lector["IdRol"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

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

    }
}
