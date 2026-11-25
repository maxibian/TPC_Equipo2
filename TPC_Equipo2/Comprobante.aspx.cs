using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPC_Equipo2
{
    public partial class Comprobante : System.Web.UI.Page
    {
        List<DetalleVenta> listaDetalle = new List<DetalleVenta>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Inicio.aspx", false);
                return;
            }
            int idVenta;

            if (!int.TryParse(Request.QueryString["id"], out idVenta) || idVenta <= 0)
            {
                Response.Redirect("Inicio.aspx", false);
                return;
            }


            if (!IsPostBack)
            {
                Venta venta = new Venta();
                VentaNegocio negocio = new VentaNegocio();

                venta = negocio.obtenerVenta(idVenta);
                listaDetalle = negocio.listarDetallesPorVenta(idVenta);

                if (venta == null)
                {
                    Response.Redirect("Inicio.aspx", false);
                    return;
                }

                lblIdVenta.Text = venta.IdVenta.ToString();

                lblFecha.Text = venta.Fecha.ToString("dd/MM/yyyy HH:mm");

                lblCliente.Text = venta.Cliente.Nombre + " " +
                                  venta.Cliente.Apellido;

                // Productos
                dgvComprobante.DataSource = listaDetalle;
                dgvComprobante.DataBind();

                // Total de la venta
                lblTotal.Text = venta.VentaTotal.ToString("C2",
                    new System.Globalization.CultureInfo("es-AR"));


            }
        }
    }
}