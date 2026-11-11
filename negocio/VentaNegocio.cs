using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class VentaNegocio
    {
        AccesoDatos datos = new AccesoDatos();

        public List<Venta> listarVentas()
        {
            List<Venta> lista = new List<Venta>();
            try
            {
                datos.setearConsulta("SELECT V.IdVenta, V.IdCliente, C.Nombre AS NombreCliente, C.Apellido AS ApellidoCliente, V.Fecha, V.VentaTotal, V.IdFormaPago, FP.Nombre AS NombreFormaPago, V.IdFormaEntrega, FE.Nombre AS NombreFormaEntrega, V.IdDireccion, V.IdEstadoVenta, EV.Nombre AS NombreEstado, V.Observaciones FROM VENTA V INNER JOIN CLIENTE C ON V.IdCliente = C.IdCliente INNER JOIN FORMAPAGO FP ON V.IdFormaPago = FP.IdFormaPago INNER JOIN FORMAENTREGA FE ON V.IdFormaEntrega = FE.IdFormaEntrega INNER JOIN ESTADOVENTA EV  ON V.IdEstadoVenta = EV.IdEstadoVenta;");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta aux = new Venta();
                    aux.IdVenta = (int)datos.Lector["IdVenta"]; 
                    aux.Cliente = new Cliente();
                    aux.Cliente.IdCliente = (int)datos.Lector["IdCliente"]; 
                    aux.Cliente.Nombre = (string)datos.Lector["NombreCliente"]; 
                    aux.Cliente.Apellido = (string)datos.Lector["ApellidoCliente"]; 
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.VentaTotal = (decimal)datos.Lector["VentaTotal"]; 
                    aux.FormaPago = new FormaPago();
                    aux.FormaPago.IdFormaPago = (int)datos.Lector["IdFormaPago"]; 
                    aux.FormaPago.Nombre = (string)datos.Lector["NombreFormaPago"]; 
                    aux.FormaEntrega = new FormaEntrega();
                    aux.FormaEntrega.IdFormaEntrega = (int)datos.Lector["IdFormaEntrega"]; 
                    aux.FormaEntrega.Nombre = (string)datos.Lector["NombreFormaEntrega"]; 

                    if (datos.Lector["IdDireccion"] != DBNull.Value) 
                    {
                        aux.Direccion = new Direccion();
                        aux.Direccion.IdDireccion = (int)datos.Lector["IdDireccion"];
                    }

                    aux.EstadoVenta = new EstadoVenta();
                    aux.EstadoVenta.IdEstadoVenta = (int)datos.Lector["IdEstadoVenta"];
                    aux.EstadoVenta.Nombre = (string)datos.Lector["NombreEstado"];

                    if (datos.Lector["Observaciones"] != DBNull.Value) 
                    {
                        aux.Observaciones = (string)datos.Lector["Observaciones"]; 
                    }

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
        public Venta obtenerVenta(int idVenta)
        {
            Venta venta = new Venta();
            //
            return venta;
        }
        public void agregar(Venta venta)
        {

        }



    }
}
