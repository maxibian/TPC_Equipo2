using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class TarjetaNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Tarjeta> listarTarjetas(int idUsuario)
        {
            List<Tarjeta> historialTarjetas = new List<Tarjeta>();
            try
            {
                datos.setearConsulta("SELECT T.IdTarjeta, T.NumeroTarjeta, MT.NombreMarcaTarjeta, TT.NombreTipoTarjeta, T.FechaVencimiento as FechaVencimiento, T.NombreYApellidoTitular FROM TARJETA T INNER JOIN MARCATARJETA MT ON MT.IdMarcaTarjeta = T.IdMarcaTarjeta INNER JOIN TIPOTARJETA TT ON TT.IdTipoTarjeta = T.IdTipoTarjeta INNER JOIN CLIENTE C ON C.IdCliente = T.IdCliente INNER JOIN USUARIO U ON U.IdUsuario = C.IdUsuario WHERE T.Estado = 1 AND U.IdUsuario = @IdUsuario ORDER BY T.FechaVencimiento ASC");
                datos.setearParametro("@IdUsuario", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Tarjeta tarjeta = new Tarjeta();
                    tarjeta.IdTarjeta = (int)datos.Lector["IdTarjeta"];
                    tarjeta.NumeroTarjeta = (string)datos.Lector["NumeroTarjeta"];
                    tarjeta.MarcaTarjeta = new MarcaTarjeta();
                    tarjeta.MarcaTarjeta.Nombre = (string)datos.Lector["NombreMarcaTarjeta"];
                    tarjeta.TipoTarjeta = new TipoTarjeta();
                    tarjeta.TipoTarjeta.NombreTipoTarjeta = (string)datos.Lector["NombreTipoTarjeta"];
                    tarjeta.FechaVencimiento = (DateTime)datos.Lector["FechaVencimiento"];
                    tarjeta.NombreYApellidoTitular = (string)datos.Lector["NombreYApellidoTitular"];

                    historialTarjetas.Add(tarjeta);
                }

                return historialTarjetas;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally { datos.cerrarConexion(); }
        }

        public void BajaLogicaTarjeta(int idTarjeta)
        {
            try
            {
                datos.setearConsulta("UPDATE TARJETA SET Estado = 0 Where IdTarjeta = @idTarjeta");
                datos.setearParametro("@IdTarjeta", idTarjeta);
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

        public bool isExist(int idTarjeta)
        {
            try
            {
                datos.setearConsulta("SELECT * FROM TARJETA WHERE IdTarjeta = @IdTarjeta AND Estado = 1");
                datos.setearParametro("@IdTarjeta", idTarjeta);
                datos.ejecutarLectura();

                return datos.Lector.Read();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally { datos.cerrarConexion(); }
            
        }
    }
}
