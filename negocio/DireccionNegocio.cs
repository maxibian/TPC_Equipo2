using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class DireccionNegocio
    {
        AcessoDatos datos = new AcessoDatos();
         public List<Direccion> listarDireccion()
        {
            List<Direccion> lista = new List<Direccion>();

            datos.setearConsulta("SELECT IdDireccion, Calle, Numero, Localidad, CodigoPostal, Observacion FROM DIRECCION");
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                Direccion aux = new Direccion(); 
                
                try
                {

                aux.IdDireccion = (int)datos.Lector["IdDireccion"];
                aux.Calle = (string)datos.Lector["Calle"];
                aux.Numero = (int)datos.Lector["Numero"];
                aux.Localidad = (string)datos.Lector["Localidad"];
                aux.CodigoPostal = (string)datos.Lector["CodigoPostal"];
                if (!(datos.Lector["Observacion"] is DBNull))
                    aux.Observacion = (string)datos.Lector["Observacion"];
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    datos.cerrarConexion();
                }

                lista.Add(aux);
            }
         
            return lista;
        }
    }
}
