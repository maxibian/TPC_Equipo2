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
            Tarjeta tarjeta = new Tarjeta();
            List<Tarjeta> historialTarjetas = new List<Tarjeta>();
            try
            {
                datos.setearConsulta("SELECT T.NumeroTarjeta, MT.NombreMarcaTarjeta as Tarjeta, TT.NombreTipoTarjeta as TipoTarjeta, T.FechaVencimiento as FechaVencimiento FROM TARJETA T INNER JOIN MARCATARJETA MT ON MT.IdMarcaTarjeta = T.IdMarcaTarjeta INNER JOIN TIPOTARJETA TT ON TT.IdTipoTarjeta = T.IdTipoTarjeta INNER JOIN CLIENTE C ON C.IdCliente = T.IdCliente INNER JOIN USUARIO U ON U.IdUsuario = C.IdUsuario WHERE U.IdUsuario = @IdUsuario ORDER BY T.FechaVencimiento ASC");
                datos.setearParametro("@IdUsuario", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    tarjeta.NumeroTarjeta = (string)datos.Lector["NumeroTarjeta"];
                    tarjeta.MarcaTarjeta = new MarcaTarjeta();
                    tarjeta.MarcaTarjeta.Nombre = (string)datos.Lector["NombreMarcaTarjeta"];
                    tarjeta.TipoTarjeta = new TipoTarjeta();
                    tarjeta.TipoTarjeta.NombreTipoTarjeta = (string)datos.Lector["NombreTipoTarjeta"];
                    tarjeta.FechaVencimiento = (DateTime)datos.Lector["FechaVencimiento"];

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
    }
}
