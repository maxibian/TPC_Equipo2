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
    public partial class CompraExitosa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarComprobante();
            }
        }

        private void cargarComprobante()
        {
            Usuario usuario = Session["usuario"] as Usuario;

            if (usuario == null)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            if (!int.TryParse(Request.QueryString["id"], out int idVenta)
                || idVenta <= 0)
            {
                Response.Redirect("~/Inicio.aspx");
                return;
            }

            VentaNegocio negocio = new VentaNegocio();
            Venta venta = negocio.obtenerVenta(idVenta);

            if (venta == null)
            {
                lblMensaje.Text = "No se encontró el pedido.";
                return;
            }

            CarritoNegocio negocioCarrito = new CarritoNegocio();
            int idCliente = negocioCarrito.obtenerIdCliente(usuario.IdUsuario);

            if (idCliente <= 0 || venta.Cliente == null
                || venta.Cliente.IdCliente != idCliente)
            {
                Response.Redirect("~/Inicio.aspx");
                return;
            }

            lblIdVenta.Text = venta.IdVenta.ToString();
            lblFecha.Text = venta.Fecha.ToString("dd/MM/yyyy HH:mm");
            lblEstado.Text = venta.EstadoVenta.Nombre;
            lblFormaPago.Text = venta.FormaPago.Nombre;
            lblFormaEntrega.Text = venta.FormaEntrega.Nombre;
            lblTotal.Text = venta.VentaTotal.ToString("N2");

            List<DetalleVenta> detalles = negocio.listarDetallesPorVenta(idVenta);

            gvDetalles.DataSource = detalles;
            gvDetalles.DataBind();

            pnlComprobante.Visible = true;
        }
    }
}