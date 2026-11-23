using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Net;
using System.Diagnostics.Eventing.Reader;

namespace negocio
{
    public class UsuarioNegocio
    {
        AccesoDatos datos = new AccesoDatos();

        public List<Usuario> listarUsuarios(string nombre = "")
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                string consulta = "SELECT U.IdUsuario, U.NombreUsuario, U.Contrasena, R.IdRol, U.Estado FROM USUARIO U INNER JOIN ROL R ON U.IdRol = R.IdRol";
                if (nombre != "")
                {
                    consulta += " AND U.NombreUsuario = @nombre";
                }

                datos.setearConsulta(consulta);

                if (nombre != "")
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
        public void modificarUsuarioContrasena(Usuario aux)
        {
            try
            {
                datos.setearConsulta("UPDATE USUARIO SET Contrasena = @Contrasena WHERE IdUsuario = @IdUsuario");
                datos.setearParametro("@IdUsuario", aux.IdUsuario);
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
                usuario.Token = Guid.NewGuid().ToString();

                datos.setearConsulta("INSERT INTO USUARIO (NombreUsuario, Contrasena, IdRol, Estado)VALUES(@NombreUsuario, @Contrasena, @IdRol, @Estado) SELECT CAST(SCOPE_IDENTITY() AS INT)");
                datos.setearParametro("@NombreUsuario", usuario.NombreUsuario);
                datos.setearParametro("@Contrasena", usuario.Contrasena);
                datos.setearParametro("@IdRol", 2);
                datos.setearParametro("@Estado", 0);
                datos.setearParametro("@Token", usuario.Token);
                //datos.ejecutarAccion();


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
        public void agregarAdministrador(Usuario usuario)
        {
            try
            {
                datos.setearConsulta("INSERT INTO USUARIO (NombreUsuario, Contrasena, IdRol, Estado)VALUES(@NombreUsuario, @Contrasena, @IdRol, @Estado)");
                datos.setearParametro("@NombreUsuario", usuario.NombreUsuario);
                datos.setearParametro("@Contrasena", usuario.Contrasena);
                datos.setearParametro("@IdRol", 1);
                datos.setearParametro("@Estado", usuario.Estado);
                datos.ejecutarAccion();
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
        public void altaAdministrador(int id)
        {
            try
            {
                datos.setearConsulta("UPDATE USUARIO SET Estado = @Estado WHERE IdUsuario = @id");
                datos.setearParametro("@id", id);
                datos.setearParametro("@Estado", 1);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public void bajaAdministrador(int id)
        {
            try
            {
                datos.setearConsulta("UPDATE USUARIO SET Estado = @Estado WHERE IdUsuario = @id");
                datos.setearParametro("@id", id);
                datos.setearParametro("@Estado", 0);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }


        public bool isExist(string nombre)
        {
            try
            {
                List<Usuario> veficiarLista = new List<Usuario>();
                veficiarLista = listarUsuarios(nombre);

                if (veficiarLista.Count == 0)
                {
                    return false;
                }

                return true;

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

        public bool Loguear(Usuario usuario)
        {
            try
            {
                datos.setearConsulta("SELECT IdUsuario, NombreUsuario, Contrasena, IdRol, Estado FROM USUARIO WHERE NombreUsuario = @NombreUsuario And Contrasena = @Contrasena And Estado = 1");
                datos.setearParametro("@NombreUsuario", usuario.NombreUsuario);
                datos.setearParametro("@Contrasena", usuario.Contrasena);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    usuario.IdUsuario = (int)datos.Lector["IdUsuario"];
                    usuario.Rol = new Rol();
                    usuario.Rol.IdRol = (int)datos.Lector["IdRol"];
                    usuario.Estado = (bool)datos.Lector["Estado"];
                    return true;
                }

                return false;
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

        public bool activarCuenta(string token)
        {
            try
            {
                datos.setearConsulta("UPDATE USUARIO SET Estado = 1, Token = NULL WHERE Token = @Token SELECT @@ROWCOUNT");
                datos.setearParametro("@Token", token);

                int filasActualizadas = datos.ejecutarEscalar();
                return filasActualizadas > 0;
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
