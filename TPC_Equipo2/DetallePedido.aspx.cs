using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo2
{
    public partial class DetallePedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];

                bool valido = int.TryParse(id, out int numero);

                if (valido && numero > 0)
                {
                    VentaNegocio negocio = new VentaNegocio();
                    Venta venta = negocio.obtenerVenta(numero);

                    if (venta != null)
                    {
                        lblIdVenta.Text = venta.IdVenta.ToString();
                        lblFecha.Text = venta.Fecha.ToString("dd/MM/yyyy");
                        lblCliente.Text = venta.Cliente.Nombre + " " + venta.Cliente.Apellido;
                        lblEstado.Text = venta.EstadoVenta.Nombre;
                        lblFormaPago.Text = venta.FormaPago.Nombre;
                        lblFormaEntrega.Text = venta.FormaEntrega.Nombre;

                        List<DetalleVenta> detalleVentas = negocio.listarDetallesPorVenta(numero);

                        gvDetalles.DataSource = detalleVentas;
                        gvDetalles.DataBind();

                        lblTotal.Text = venta.VentaTotal.ToString("N2");
                    }
                    else
                    {
                        Response.Redirect("AdminVentas.aspx");
                    }


                }
                else
                {
                    Response.Redirect("AdminVentas.aspx");
                }

            }

        }
    }
}