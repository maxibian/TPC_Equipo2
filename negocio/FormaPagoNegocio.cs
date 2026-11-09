using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class FormaPagoNegocio
    {       
        public List<FormaPago> listarFormasPago()
        {
            AccesoDatos datos = new AccesoDatos();

            List<FormaPago> lista = new List<FormaPago>();
            try
            {
                datos.setearConsulta("SELECT IdFormaPago, Nombre, Estado FROM FORMAPAGO");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    FormaPago aux = new FormaPago();
                    aux.IdFormaPago = (int)datos.Lector["IdFormaPago"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Estado = (bool)datos.Lector["Estado"];

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

        public bool agregar(FormaPago nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if(nueva == null)
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
                    datos.setearConsulta("INSERT INTO FORMAPAGO (Nombre) values (@nombre)");
                    datos.setearParametro("@nombre", nueva.Nombre);
                    datos.ejecutarAccion();

                    return true;
                }

                return false;
                
            }
            catch (Exception ex)
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
            List<FormaPago> lista = listarFormasPago();

            foreach (FormaPago forma in lista)
            {
                if(forma.Nombre.ToUpper() == nombre.ToUpper())
                {
                    return true;
                }

            }

            return false;
        }

        public void cambiarEstado(int idFormaPago, bool estado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE FORMAPAGO SET Estado = @estado WHERE IdFormaPago = @id");
                datos.setearParametro("@estado", estado);
                datos.setearParametro("@id", idFormaPago);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public FormaPago buscarPorId(int idFormaPago)
        {
            AccesoDatos datos = new AccesoDatos();
            FormaPago aux = null;

            try
            {
                datos.setearConsulta("SELECT IdFormaPago, Nombre, Estado FROM FORMAPAGO WHERE IdFormaPago = @id");
                datos.setearParametro("@id", idFormaPago);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    aux = new FormaPago();
                    aux.IdFormaPago = (int)datos.Lector["IdFormaPago"];
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
    }
}
