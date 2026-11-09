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
    }
}
