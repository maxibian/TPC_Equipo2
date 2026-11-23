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
    public partial class FormularioFormaEntrega : System.Web.UI.Page
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
                    txtNombreFormaEntrega.Enabled = false;
                    chkRequiereDireccion.Enabled = false;
                    return;
                }

                FormaEntregaNegocio negocio = new FormaEntregaNegocio();
                FormaEntrega forma = negocio.buscarPorId(numero);

                if (forma == null)
                {
                    lblMensaje.CssClass = "d-block mt-2 text-danger";
                    lblMensaje.Text = "No se encontró la forma de entrega.";
                    btnGuardar.Enabled = false;
                    btnCambiarEstado.Enabled = false;
                    txtNombreFormaEntrega.Enabled = false;
                    chkRequiereDireccion.Enabled = false;
                    return;
                }

                txtNombreFormaEntrega.Text = forma.Nombre;
                chkEstado.Checked = forma.Estado;
                chkRequiereDireccion.Checked = forma.RequiereDireccion;

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
                Response.Redirect("Inicio.aspx");
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

            FormaEntrega forma = new FormaEntrega();

            forma.IdFormaEntrega = numero;
            forma.Nombre = txtNombreFormaEntrega.Text;
            forma.RequiereDireccion = chkRequiereDireccion.Checked;

            FormaEntregaNegocio negocio = new FormaEntregaNegocio();

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
                    lblMensaje.Text = "Ya existe otra forma de entrega con ese nombre.";
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
                lblMensaje.Text = "Ocurrió un error al modificar la forma de entrega.";
            }
        }

        protected void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (!esAdministrador())
            {
                Response.Redirect("Inicio.aspx");
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
                FormaEntregaNegocio negocio = new FormaEntregaNegocio();
                FormaEntrega forma = negocio.buscarPorId(numero);

                if (forma == null)
                {
                    lblMensaje.CssClass = "d-block mt-2 text-danger";
                    lblMensaje.Text = "No se encontró la forma de entrega.";
                    return;
                }

                bool nuevoEstado = !forma.Estado;

                negocio.cambiarEstado(forma.IdFormaEntrega, nuevoEstado);
                lblMensaje.CssClass = "d-block mt-2 text-success";

                chkEstado.Checked = nuevoEstado;

                if (nuevoEstado)
                {
                    lblMensaje.Text = "Forma de entrega activada correctamente.";
                    btnCambiarEstado.Text = "Desactivar";

                }
                else
                {
                    lblMensaje.Text = "Forma de entrega desactivada correctamente.";
                    btnCambiarEstado.Text = "Activar";

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