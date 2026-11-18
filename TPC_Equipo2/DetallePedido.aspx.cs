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

                        txtObservaciones.Text = venta.Observaciones ?? "";

                        EstadoVentaNegocio negocioEstados = new EstadoVentaNegocio();

                        ddlEstado.DataSource = negocioEstados.listar();
                        ddlEstado.DataTextField = "Nombre";
                        ddlEstado.DataValueField = "IdEstadoVenta";
                        ddlEstado.DataBind();
                        ddlEstado.SelectedValue = venta.EstadoVenta.IdEstadoVenta.ToString();

                        if (venta.EstadoVenta.Nombre == "Entregado" || venta.EstadoVenta.Nombre == "Cancelado")
                        {
                            ddlEstado.Enabled = false;
                        }
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

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            bool valido = int.TryParse(id, out int numero);

            if (!valido || numero <= 0)
            {
                Response.Redirect("AdminVentas.aspx");
                return;
            }

            string observaciones = txtObservaciones.Text.Trim();

            if (observaciones.Length > 500)
            {
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Text = "Las observaciones no pueden superar los 500 caracteres.";
                return;
            }

            int idEstadoSeleccionado;

            if (!int.TryParse(ddlEstado.SelectedValue, out idEstadoSeleccionado)
                || idEstadoSeleccionado <= 0)
            {
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Text = "Seleccioná un estado válido.";
                return;
            }

            VentaNegocio negocio = new VentaNegocio();

            Venta ventaActual = negocio.obtenerVenta(numero);

            if (ventaActual == null)
            {
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Text = "No se encontró la venta.";
                return;
            }

            try
            {
                if (ventaActual.EstadoVenta.IdEstadoVenta != idEstadoSeleccionado)
                {
                    negocio.cambiarEstado(numero, idEstadoSeleccionado);
                }

                negocio.actualizarObservaciones(numero, observaciones);

                lblMensaje.CssClass = "text-success";
                lblMensaje.Text = "Cambios guardados correctamente.";
                lblEstado.Text = ddlEstado.SelectedItem.Text;

                if (lblEstado.Text == "Entregado" || lblEstado.Text == "Cancelado")
                {
                    ddlEstado.Enabled = false;
                }
            }
            catch (InvalidOperationException ex)
            {
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Text = ex.Message;
            }

        }
    }
}