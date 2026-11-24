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
            if (!esAdministrador())
            {
                Response.Redirect("Inicio.aspx");
                return;
            }

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

                        txtCodigoSeguimiento.Text = venta.CodigoSeguimiento ?? "";

                        cargarEstadosDisponibles(venta);
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
            if (!esAdministrador())
            {
                return;
            }

            string id = Request.QueryString["id"];

            bool valido = int.TryParse(id, out int numero);

            if (!valido || numero <= 0)
            {
                Response.Redirect("AdminVentas.aspx");
                return;
            }

            string observaciones = txtObservaciones.Text.Trim();
            string codigoSeguimiento = txtCodigoSeguimiento.Text.Trim();

            if (codigoSeguimiento.Length > 100)
            {
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Text = "El código de seguimiento no puede superar los 100 caracteres.";
                return;
            }

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

            bool pasaAEnviado = ventaActual.EstadoVenta.Nombre == "En preparación" && ddlEstado.SelectedItem.Text == "Enviado";

            string codigoFinal = codigoSeguimiento;

            if (string.IsNullOrWhiteSpace(codigoFinal))
            {
                codigoFinal = ventaActual.CodigoSeguimiento;
            }

            if (pasaAEnviado && string.IsNullOrWhiteSpace(codigoFinal))
            {
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Text = "Debés ingresar un código de seguimiento antes de enviar el pedido.";
                return;
            }

            try
            {
                if (!string.IsNullOrWhiteSpace(codigoSeguimiento) && codigoSeguimiento != ventaActual.CodigoSeguimiento)
                {
                    negocio.actualizarCodigoSeguimiento(numero, codigoSeguimiento);
                }

                if (ventaActual.EstadoVenta.IdEstadoVenta != idEstadoSeleccionado)
                {
                    negocio.cambiarEstado(numero, idEstadoSeleccionado);
                }

                negocio.actualizarObservaciones(numero, observaciones);

                Venta ventaActualizada = negocio.obtenerVenta(numero);

                if (ventaActualizada == null)
                {
                    lblMensaje.CssClass = "text-danger";
                    lblMensaje.Text = "No se pudo recuperar la venta actualizada.";
                    return;
                }

                lblEstado.Text = ventaActualizada.EstadoVenta.Nombre;

                txtCodigoSeguimiento.Text = ventaActualizada.CodigoSeguimiento ?? "";

                cargarEstadosDisponibles(ventaActualizada);

                lblMensaje.CssClass = "text-success";
                lblMensaje.Text = "Cambios guardados correctamente.";

                if (pasaAEnviado)
                {
                    try
                    {
                        NotificacionNegocio notificacion = new NotificacionNegocio();
                        notificacion.enviarCorreoSeguimiento(ventaActualizada);
                    }
                    catch (Exception)
                    {
                        lblMensaje.CssClass = "text-warning";
                        lblMensaje.Text = "Los cambios se guardaron, pero no se pudo enviar el correo.";
                    }
                }
            }
            catch (Exception)
            {
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Text = "No se pudieron guardar todos los cambios del pedido. Verificá los datos antes de volver a intentarlo.";
            }

        }

        private void cargarEstadosDisponibles(Venta venta)
        {
            VentaNegocio negocio = new VentaNegocio();

            ddlEstado.DataSource = negocio.listarEstadosDisponibles(venta);
            ddlEstado.DataTextField = "Nombre";
            ddlEstado.DataValueField = "IdEstadoVenta";
            ddlEstado.DataBind();

            ddlEstado.SelectedValue =
                venta.EstadoVenta.IdEstadoVenta.ToString();

            ddlEstado.Enabled = ddlEstado.Items.Count > 1;
        }

        private bool esAdministrador()
        {
            Usuario usuario = Session["usuario"] as Usuario;

            if (usuario == null || usuario.Rol == null)
            {
                return false;
            }

            return usuario.Rol.IdRol == 1 && usuario.Estado;
        }
    }
}