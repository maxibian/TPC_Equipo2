using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {
        AccesoDatos datos = new AccesoDatos();

        public List<Usuario> listarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                datos.setearConsulta("SELECT IdUsuario, NombreUsuario, Contrasena, IdRol, Estado FROM USUARIO");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.IdUsuario = (int)datos.Lector["IdUsuario"];
                    aux.NombreUsuario = (string)datos.Lector["NombreUsuario"];
                    aux.Contrasena = (string)datos.Lector["Contrasena"];
                    aux.IdRol = (int)datos.Lector["IdRol"];
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
    public void modificarUsuario(Usuario aux)
        {
            try
            {
                datos.setearConsulta("UPDATE USUARIO SET Contrasena = @Contrasena WHERE IdUsuario = @IdUsuario");
                datos.setearParametro("@Contrasena", aux.Contrasena);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

    }
}
