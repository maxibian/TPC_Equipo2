using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    internal class VentaNegocio
    {
        AccesoDatos datos = new AccesoDatos();

        public List<Venta> listarVentas()
        {
            List<Venta> lista = new List<Venta>();
            try
            {
                datos.setearConsulta("SELECT IdVenta, IdCliente, Fecha, VentaTotal, IdFormaPago, IdFormaEntrega, IdDireccion FROM VENTA");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta aux = new Venta();
                    aux.IdVenta = (int)datos.Lector["IdVenta"];
                    aux.Cliente = new Cliente();
                    aux.Cliente.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.VentaTotal = (decimal)datos.Lector["VentaTotal"];
                    aux.FormaPago = new FormaPago();
                    aux.FormaPago.IdFormaPago = (int)datos.Lector["IdFormaPago"];
                    aux.FormaEntrega = new FormaEntrega();
                    aux.FormaEntrega.IdFormaEntrega = (int)datos.Lector["IdFormaEntrega"];
                    aux.Direccion = new Direccion();
                    aux.Direccion.IdDireccion = (int)datos.Lector["IdDireccion"];
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
