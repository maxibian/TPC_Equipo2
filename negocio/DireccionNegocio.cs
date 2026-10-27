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
        AccesoDatos datos = new AccesoDatos();
         public List<Direccion> listarDireccion()
         {
            List<Direccion> lista = new List<Direccion>();
            try
            {
            datos.setearConsulta("SELECT IdDireccion, Calle, Numero, Localidad, CodigoPostal, Observacion FROM DIRECCION");
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                Direccion aux = new Direccion(); 
                

                aux.IdDireccion = (int)datos.Lector["IdDireccion"];
                aux.Calle = (string)datos.Lector["Calle"];
                aux.Numero = (int)datos.Lector["Numero"];
                aux.Localidad = (string)datos.Lector["Localidad"];
                aux.CodigoPostal = (string)datos.Lector["CodigoPostal"];
                if (!(datos.Lector["Observacion"] is DBNull))
                    aux.Observacion = (string)datos.Lector["Observacion"];


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
