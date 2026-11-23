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
    public partial class FormularioFormaPago : System.Web.UI.Page
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

                if (!valido || numero <= 0)
                {
                    lblMensaje.CssClass = "d-block mt-2 text-danger";
                    lblMensaje.Text = "ID inválido";
                    btnGuardar.Enabled = false;
                    btnCambiarEstado.Enabled = false;
                    txtNombreFormaPago.Enabled = false;
                    return;
                }

                FormaPagoNegocio negocio = new FormaPagoNegocio();
                FormaPago forma = negocio.buscarPorId(numero);

                if (forma == null)
                {
                    lblMensaje.CssClass = "d-block mt-2 text-danger";
                    lblMensaje.Text = "No se encontró la forma de pago.";
                    btnGuardar.Enabled = false;
                    btnCambiarEstado.Enabled = false;
                    txtNombreFormaPago.Enabled = false;
                    return;
                }

                txtNombreFormaPago.Text = forma.Nombre;
                chkEstado.Checked = forma.Estado;

                if (forma.Estado)
                {
                    btnCambiarEstado.Text = "Desactivar";
                }
                else
                {
                    btnCambiarEstado.Text = "Activar";
                }

            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!esAdministrador())
            {
                return;
            }

            string id = Request.QueryString["id"];

            bool valido = int.TryParse(id, out int numero);

            if (!valido || numero <= 0)
            {
                lblMensaje.CssClass = "d-block mt-2 text-danger";
                lblMensaje.Text = "ID inválido";
                return;
            }

            FormaPago forma = new FormaPago();

            forma.IdFormaPago = numero;
            forma.Nombre = txtNombreFormaPago.Text;

            FormaPagoNegocio negocio = new FormaPagoNegocio();

            try
            {
                bool modificado = negocio.modificar(forma);

                if (modificado)
                {
                    lblMensaje.CssClass = "d-block mt-2 text-success";
                    lblMensaje.Text = "Modificado correctamente.";
                }
                else
                {
                    lblMensaje.CssClass = "d-block mt-2 text-danger";
                    lblMensaje.Text = "Ya existe otra forma de pago con ese nombre.";
                }
            }
            catch (ArgumentException ex)
            {
                lblMensaje.CssClass = "d-block mt-2 text-danger";
                lblMensaje.Text = ex.Message;
            }
            catch (Exception)
            {
                lblMensaje.CssClass = "d-block mt-2 text-danger";
                lblMensaje.Text = "Ocurrió un error al modificar la forma de pago.";
            }
    
        }

        protected void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (!esAdministrador())
            {
                return;
            }

            string id = Request.QueryString["id"];

            bool valido = int.TryParse(id, out int numero);

            if (!valido || numero <= 0)
            {
                lblMensaje.CssClass = "d-block mt-2 text-danger";
                lblMensaje.Text = "ID inválido";
                return;
            }

            try
            {
                FormaPagoNegocio negocio = new FormaPagoNegocio();
                FormaPago forma = negocio.buscarPorId(numero);

                if (forma == null)
                {
                    lblMensaje.CssClass = "d-block mt-2 text-danger";
                    lblMensaje.Text = "No se encontró la forma de pago.";
                    return;
                }

                bool nuevoEstado = !forma.Estado;

                negocio.cambiarEstado(forma.IdFormaPago, nuevoEstado);
                lblMensaje.CssClass = "d-block mt-2 text-success";

                chkEstado.Checked = nuevoEstado;

                if (nuevoEstado)
                {
                    btnCambiarEstado.Text = "Desactivar categoría";
                    btnCambiarEstado.CssClass = "btn btn-danger";
                    lblMensaje.Text = "Forma de pago activada correctamente.";
                }
                else
                {
                    btnCambiarEstado.Text = "Activar categoría";
                    btnCambiarEstado.CssClass = "btn btn-success";
                    lblMensaje.Text = "Forma de pago desactivada correctamente.";
                }
            }
            catch (Exception)
            {
                lblMensaje.CssClass = "d-block mt-2 text-danger";
                lblMensaje.Text = "Ocurrió un error al cambiar el estado.";
            }

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