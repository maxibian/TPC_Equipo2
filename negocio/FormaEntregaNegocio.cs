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

        public bool agregar(FormaEntrega nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (nueva == null)
                {
                    throw new ArgumentNullException(nameof(nueva));
                }

                if (string.IsNullOrWhiteSpace(nueva.Nombre))
                {
                    throw new ArgumentException("El nombre es obligatorio.");
                }

                nueva.Nombre = nueva.Nombre.Trim();

                if (nueva.Nombre.Length > 50)
                {
                    throw new ArgumentException("El nombre no puede superar los 50 caracteres.");
                }

                if (!existeNombre(nueva.Nombre))
                {
                    datos.setearConsulta("INSERT INTO FORMAENTREGA (Nombre) values (@nombre)");
                    datos.setearParametro("@nombre", nueva.Nombre);
                    datos.ejecutarAccion();

                    return true;
                }

                return false;

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

        public bool existeNombre(string nombre)
        {
            List<FormaEntrega> lista = listarFormasEntrega();

            foreach (FormaEntrega forma in lista)
            {
                if (forma.Nombre.ToUpper() == nombre.ToUpper())
                {
                    return true;
                }

            }

            return false;
        }

        public bool existeNombreEnOtroRegistro(string nombre, int idFormaEntrega)
        {
            List<FormaEntrega> lista = listarFormasEntrega();

            foreach (FormaEntrega forma in lista)
            {
                if (forma.Nombre.ToUpper() == nombre.ToUpper() && forma.IdFormaEntrega != idFormaEntrega)
                {
                    return true;
                }

            }

            return false;
        }

        public void cambiarEstado(int idFormaEntrega, bool estado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE FORMAENTREGA SET Estado = @estado WHERE idFormaEntrega = @id");
                datos.setearParametro("@estado", estado);
                datos.setearParametro("@id", idFormaEntrega);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public FormaEntrega buscarPorId(int idFormaEntrega)
        {
            AccesoDatos datos = new AccesoDatos();
            FormaEntrega aux = null;

            try
            {
                datos.setearConsulta("SELECT idFormaEntrega, Nombre, Estado FROM FORMAENTREGA WHERE idFormaEntrega = @id");
                datos.setearParametro("@id", idFormaEntrega);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    aux = new FormaEntrega();
                    aux.IdFormaEntrega = (int)datos.Lector["idFormaEntrega"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Estado = (bool)datos.Lector["Estado"];
                }

                return aux;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool modificar(FormaEntrega forma)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (forma == null)
                {
                    throw new ArgumentNullException(nameof(forma));
                }

                if (string.IsNullOrWhiteSpace(forma.Nombre))
                {
                    throw new ArgumentException("El nombre es obligatorio.");
                }

                forma.Nombre = forma.Nombre.Trim();

                if (forma.Nombre.Length > 50)
                {
                    throw new ArgumentException("El nombre no puede superar los 50 caracteres.");
                }

                if (!existeNombreEnOtroRegistro(forma.Nombre, forma.IdFormaEntrega))
                {
                    datos.setearConsulta("UPDATE FORMAENTREGA SET Nombre = @nombre WHERE idFormaEntrega = @id");
                    datos.setearParametro("@nombre", forma.Nombre);
                    datos.setearParametro("@id", forma.IdFormaEntrega);
                    datos.ejecutarAccion();

                    return true;
                }

                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
