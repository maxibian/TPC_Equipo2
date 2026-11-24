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
                datos.setearConsulta("SELECT IdDireccion, IdCliente, Calle, Numero, Localidad, Provincia, CodigoPostal, Observacion, Estado FROM DIRECCION");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Direccion aux = new Direccion();

                    aux.IdDireccion = (int)datos.Lector["IdDireccion"];
                    aux.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.Calle = (string)datos.Lector["Calle"];
                    aux.Numero = (int)datos.Lector["Numero"];
                    aux.Localidad = (string)datos.Lector["Localidad"];
                    aux.Provincia = (string)datos.Lector["Provincia"];
                    aux.CodigoPostal = (string)datos.Lector["CodigoPostal"];
                    if (!(datos.Lector["Observacion"] is DBNull))
                        aux.Observacion = (string)datos.Lector["Observacion"];
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
        public void agregarDireccion(Direccion direccion)
        {
            try
            {
                datos.setearConsulta("INSERT INTO DIRECCION(IdCliente, Calle, Numero, Localidad, Provincia, CodigoPostal, Observacion)values(@IdCliente, @Calle, @Numero, @Localidad, @Provincia, @CodigoPostal, @Observacion)");
                datos.setearParametro("@IdCliente", direccion.IdCliente);
                datos.setearParametro("@Calle", direccion.Calle);
                datos.setearParametro("@Numero", direccion.Numero);
                datos.setearParametro("@Localidad", direccion.Localidad);
                datos.setearParametro("@Provincia", direccion.Provincia);
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
                datos.setearConsulta("UPDATE DIRECCION SET IdCliente = @IdCliente, Calle = @Calle, Numero = @Numero, Localidad = @Localidad, Provincia = @Provincia, CodigoPostal = @CodigoPostal, Observacion = @Observacion WHERE IdDireccion = @IdDireccion");
                datos.setearParametro("@IdCliente", direccion.IdCliente);
                datos.setearParametro("@Calle", direccion.Calle);
                datos.setearParametro("@Numero", direccion.Numero);
                datos.setearParametro("@Localidad", direccion.Localidad);
                datos.setearParametro("@Provincia", direccion.Provincia);
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
                datos.setearConsulta("UPDATE DIRECCION SET Estado = 0 WHERE IdDireccion = @IdDireccion"); 
                datos.setearParametro("@IdDireccion", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally { datos.cerrarConexion(); }
        }

        public List<Direccion> listarDireccionesPorCliente(int idCliente)
        {
            if (idCliente <= 0)
            {
                throw new ArgumentException(
                    "El identificador del cliente no es válido."
                );
            }

            List<Direccion> direcciones = new List<Direccion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdDireccion, IdCliente, Calle, Numero, Localidad, Provincia, CodigoPostal, Observacion, Estado FROM DIRECCION WHERE IdCliente = @IdCliente AND Estado = 1");
                datos.setearParametro("@IdCliente", idCliente);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Direccion direccion = new Direccion();

                    direccion.IdDireccion = (int)datos.Lector["IdDireccion"];
                    direccion.IdCliente = (int)datos.Lector["IdCliente"];
                    direccion.Calle = (string)datos.Lector["Calle"];
                    direccion.Numero = (int)datos.Lector["Numero"];
                    direccion.Localidad = (string)datos.Lector["Localidad"];
                    direccion.Provincia = (string)datos.Lector["Provincia"];
                    direccion.CodigoPostal = (string)datos.Lector["CodigoPostal"];

                    if (datos.Lector["Observacion"] != DBNull.Value)
                    {
                        direccion.Observacion = (string)datos.Lector["Observacion"];
                    }

                    direccion.Estado = (bool)datos.Lector["Estado"];

                    direcciones.Add(direccion);

                }

                return direcciones;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int agregarDireccionYObtenerId(Direccion direccion)
        {

            if (direccion == null)
            {
                throw new ArgumentNullException(nameof(direccion));
            }

            if (direccion.IdCliente <= 0)
            {
                throw new ArgumentException(
                    "El identificador del cliente no es válido."
                );
            }

            if (string.IsNullOrWhiteSpace(direccion.Calle))
            {
                throw new ArgumentException("La calle es obligatoria.");
            }

            if (direccion.Numero <= 0)
            {
                throw new ArgumentException("El número de la dirección debe ser positivo.");
            }

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO DIRECCION(IdCliente, Calle, Numero, Localidad, Provincia, CodigoPostal, Observacion)values(@IdCliente, @Calle, @Numero, @Localidad, @Provincia, @CodigoPostal, @Observacion); SELECT CAST(SCOPE_IDENTITY() AS INT)");
                datos.setearParametro("@IdCliente", direccion.IdCliente);
                datos.setearParametro("@Calle", direccion.Calle);
                datos.setearParametro("@Numero", direccion.Numero);
                datos.setearParametro("@Localidad", direccion.Localidad);
                datos.setearParametro("@Provincia", direccion.Provincia);
                datos.setearParametro("@CodigoPostal", direccion.CodigoPostal);
                datos.setearParametro("@Observacion", (object)direccion.Observacion ?? DBNull.Value);

                int idDireccion = (int)datos.ejecutarEscalar();

                return idDireccion;

            }
            finally
            {
                datos.cerrarConexion();
            }
        }



    }
}
