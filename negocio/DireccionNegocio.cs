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
                datos.setearConsulta("SELECT IdDireccion, IdCliente, Calle, Numero, Localidad, CodigoPostal, Observacion FROM DIRECCION");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Direccion aux = new Direccion();

                    aux.IdDireccion = (int)datos.Lector["IdDireccion"];
                    aux.IdCliente = (int)datos.Lector["IdCliente"];
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
        public void agregarDireccion(Direccion direccion)
        {
            try
            {
                datos.setearConsulta("INSERT INTO DIRECCION(IdCliente, Calle, Numero, Localidad, CodigoPostal, Observacion)values(@IdDireccion, @Calle, @Numero, @Localidad, @CodigoPostal, @Observacion)");
                datos.setearParametro("@IdCliente", direccion.IdCliente);
                datos.setearParametro("@Calle", direccion.Calle);
                datos.setearParametro("@Numero", direccion.Numero);
                datos.setearParametro("@Localidad", direccion.Localidad);
                datos.setearParametro("@CodigoPostal", direccion.CodigoPostal);
                datos.setearParametro("@Observacion", direccion.Observacion);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally { datos.cerrarConexion(); }
        }
        public void modificarDireccion(Direccion direccion)
        {
            try
            {
                datos.setearConsulta("UPDATE DIRECCION SET IdCliente = @IdCliente, Calle = @Calle, Numero = @Numero, Localidad = @Localidad, CodigoPostal = @CodigoPostal, Observacion = @Observacion WHERE IdDireccion = @IdDireccion");
                datos.setearParametro("@IdCliente", direccion.IdCliente);
                datos.setearParametro("@Calle", direccion.Calle);
                datos.setearParametro("@Numero", direccion.Numero);
                datos.setearParametro("@Localidad", direccion.Localidad);
                datos.setearParametro("@CodigoPostal", direccion.CodigoPostal);
                datos.setearParametro("@Observacion", direccion.Observacion);
                datos.setearParametro("@IdDireccion", direccion.IdDireccion);
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
        public void eliminarDireccion(int id)
        {
            try
            {
                datos.setearConsulta("DELETE FROM DIRECCION WHERE IdDireccion = @IdDireccion");
                datos.setearParametro("@IdDireccion", id);
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
