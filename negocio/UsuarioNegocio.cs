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

        public List<Usuario> listarUsuarios(string nombre="")
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                string consulta = "SELECT U.IdUsuario, U.NombreUsuario, U.Contrasena, R.IdRol, U.Estado FROM USUARIO U INNER JOIN ROL R ON U.IdRol = R.IdRol WHERE U.Estado = 1";
                if(nombre != "")
                {
                    consulta += " AND U.NombreUsuario = @nombre";
                }

                datos.setearConsulta(consulta);

                if(nombre != "")
                {
                    datos.setearParametro("@nombre", nombre);
                }

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.IdUsuario = (int)datos.Lector["IdUsuario"];
                    aux.NombreUsuario = (string)datos.Lector["NombreUsuario"];
                    aux.Contrasena = (string)datos.Lector["Contrasena"];

                    aux.Rol = new Rol();
                    aux.Rol.IdRol = (int)datos.Lector["IdRol"];
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


    public int agregarUsuario(Usuario usuario)
        {
            try
            {
                datos.setearConsulta("INSERT INTO USUARIO (NombreUsuario, Contrasena, IdRol, Estado)VALUES(@NombreUsuario, @Contrasena, @IdRol, @Estado) SELECT CAST(SCOPE_IDENTITY() AS INT)");
                datos.setearParametro("@NombreUsuario", usuario.NombreUsuario);
                datos.setearParametro("@Contrasena", usuario.Contrasena);
                datos.setearParametro("@IdRol", 2);
                datos.setearParametro("@Estado", 1);


                return datos.ejecutarEscalar();

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
