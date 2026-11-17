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
    public partial class AdminVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarVentas();
            }
        }

        private void cargarVentas()
        {
            VentaNegocio negocio = new VentaNegocio();

            gvVentas.DataSource = negocio.listarVentas();
            gvVentas.DataBind();
        }

        protected void gvVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idVenta = Convert.ToInt32(gvVentas.SelectedDataKey.Value);
            Response.Redirect("DetallePedido.aspx?id=" + idVenta);
        }

        protected void btnBuscarVenta_Click(object sender, EventArgs e)
        {
            int idVenta;

            bool valido = int.TryParse(txtBuscarVenta.Text, out idVenta);

            lblMensaje.Text = "";

            if (!valido || idVenta <= 0)
            {
                lblMensaje.Text = "Ingresá un número de venta válido.";
                return;
            }

            VentaNegocio negocio = new VentaNegocio();

            Venta venta = negocio.obtenerVenta(idVenta);

            List<Venta> ventasEncontradas = new List<Venta>();

            if (venta != null)
            {
                ventasEncontradas.Add(venta);
            }
            else
            {
                lblMensaje.Text = "No se encontró una venta con ese número.";
            }

            gvVentas.DataSource = ventasEncontradas;
            gvVentas.DataBind();

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscarVenta.Text = "";
            lblMensaje.Text = "";
            txtBuscarCliente.Text = "";
            cargarVentas();
        }

        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string texto = txtBuscarCliente.Text.Trim().ToLower();

            lblMensaje.Text = "";

            if (texto == "")
            {
                lblMensaje.Text = "Ingresá un nombre o apellido.";
                return;
            }

            VentaNegocio negocio = new VentaNegocio();

            List<Venta> ventas = negocio.listarVentas();

            List<Venta> ventasEncontradas = new List<Venta>();

            foreach (Venta venta in ventas)
            {
                string nombre = venta.Cliente.Nombre.ToLower();
                string apellido = venta.Cliente.Apellido.ToLower();

                if (nombre.Contains(texto) || apellido.Contains(texto))
                {
                    ventasEncontradas.Add(venta);
                }
            }

            gvVentas.DataSource = ventasEncontradas;
            gvVentas.DataBind();

        }
    }
}