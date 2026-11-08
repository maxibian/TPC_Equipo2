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
        AccesoDatos datos = new AccesoDatos();

        public List<FormaPago> listarFormasPago()
        {
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
    }
}
