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
                cargarEstados();
            }
        }

        private void cargarVentas()
        {
            VentaNegocio negocio = new VentaNegocio();

            gvVentas.DataSource = negocio.listarVentas();
            gvVentas.DataBind();
        }

        private void cargarEstados()
        {
            EstadoVentaNegocio negocio = new EstadoVentaNegocio();

            ddlFiltroEstado.DataSource = negocio.listar();
            ddlFiltroEstado.DataTextField = "Nombre";
            ddlFiltroEstado.DataValueField = "IdEstadoVenta";
            ddlFiltroEstado.DataBind();

            ddlFiltroEstado.Items.Insert(0, new ListItem("Todos los estados", "")
            );
        }

        protected void gvVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idVenta = Convert.ToInt32(gvVentas.SelectedDataKey.Value);
            Response.Redirect("DetallePedido.aspx?id=" + idVenta);
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscarVenta.Text = "";
            lblMensaje.Text = "";
            txtBuscarCliente.Text = "";
            ddlFiltroEstado.SelectedIndex = 0;

            txtFechaDesde.Text = "";
            txtFechaHasta.Text = "";

            cargarVentas();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            string textoNumero = txtBuscarVenta.Text.Trim();
            string textoCliente = txtBuscarCliente.Text.Trim().ToLower();
            string textoEstado = ddlFiltroEstado.SelectedValue;
            string textoFechaDesde = txtFechaDesde.Text.Trim();
            string textoFechaHasta = txtFechaHasta.Text.Trim();

            DateTime fechaDesde = new DateTime();
            DateTime fechaHasta = new DateTime();

            if (textoFechaDesde != "")
            {
                if (!DateTime.TryParse(textoFechaDesde, out fechaDesde))
                {
                    lblMensaje.Text = "La fecha desde no es válida.";
                    return;
                }
            }

            if (textoFechaHasta != "")
            {
                if (!DateTime.TryParse(textoFechaHasta, out fechaHasta))
                {
                    lblMensaje.Text = "La fecha hasta no es válida.";
                    return;
                }
            }

            if (textoFechaDesde != "" && textoFechaHasta != "")
            {
                if (fechaDesde > fechaHasta)
                {
                    lblMensaje.Text =
                        "La fecha desde no puede ser posterior a la fecha hasta.";
                    return;
                }
            }

            int idVenta = 0;

            if (textoNumero != "")
            {
                if (!int.TryParse(textoNumero, out idVenta) || idVenta <= 0)
                {
                    lblMensaje.Text = "Ingresá un número de venta válido.";
                    return;
                }
            }

            int idEstado = 0;

            if (textoEstado != "")
            {
                if (!int.TryParse(textoEstado, out idEstado) || idEstado <= 0)
                {
                    lblMensaje.Text = "El estado seleccionado no es válido.";
                    return;
                }
            }

            VentaNegocio negocio = new VentaNegocio();

            List<Venta> ventas = negocio.listarVentas();
            List<Venta> ventasFiltradas = new List<Venta>();

            foreach (Venta venta in ventas)
            {
                bool coincideNumero = textoNumero == "" || venta.IdVenta == idVenta;

                string nombre = venta.Cliente.Nombre.ToLower();
                string apellido = venta.Cliente.Apellido.ToLower();

                bool coincideCliente = textoCliente == "" || nombre.Contains(textoCliente) || apellido.Contains(textoCliente);

                bool coincideEstado = textoEstado == "" || venta.EstadoVenta.IdEstadoVenta == idEstado;

                bool coincideFechaDesde = textoFechaDesde == "" || venta.Fecha.Date >= fechaDesde.Date;

                bool coincideFechaHasta = textoFechaHasta == "" || venta.Fecha.Date <= fechaHasta.Date;

                if (coincideNumero && coincideCliente && coincideEstado && coincideFechaDesde && coincideFechaHasta)
                {
                    ventasFiltradas.Add(venta);
                }
            }

            gvVentas.DataSource = ventasFiltradas;
            gvVentas.DataBind();

        }
    }
}