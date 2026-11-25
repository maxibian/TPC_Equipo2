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
    public partial class AdminFormasEntrega : System.Web.UI.Page
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
                cargarFormasEntrega();
            }
        }

        private void cargarFormasEntrega()
        {
            FormaEntregaNegocio negocio = new FormaEntregaNegocio();

            gvFormasEntrega.DataSource = negocio.listarFormasEntrega();
            gvFormasEntrega.DataBind();
        }

        protected void btnAgregarFormaEntrega_Click(object sender, EventArgs e)
        {
            if (!esAdministrador())
            {
                return;
            }

            string nombre = txtNombreFormaEntrega.Text.Trim();

            if (nombre == "")
            {
                lblMensaje.CssClass = "d-block mt-2 text-danger";
                lblMensaje.Text = "Debe ingresar un nombre para la forma de entrega.";
                return;
            }

            if (nombre.Length > 50)
            {
                lblMensaje.CssClass = "d-block mt-2 text-danger";
                lblMensaje.Text = "El nombre no puede superar los 50 caracteres.";
                return;
            }

            decimal costoEntrega;

            if (!decimal.TryParse(txtCostoEntrega.Text.Trim(), out costoEntrega))
            {
                lblMensaje.CssClass = "d-block mt-2 text-danger";
                lblMensaje.Text = "Ingresá un costo de entrega válido.";
                return;
            }

            if (costoEntrega < 0)
            {
                lblMensaje.CssClass = "d-block mt-2 text-danger";
                lblMensaje.Text = "El costo de entrega no puede ser negativo.";
                return;
            }


            FormaEntrega nuevaFormaEntrega = new FormaEntrega();

            nuevaFormaEntrega.Nombre = nombre;
            nuevaFormaEntrega.RequiereDireccion = chkRequiereDireccion.Checked;
            nuevaFormaEntrega.CostoEntrega = costoEntrega;

            FormaEntregaNegocio negocio = new FormaEntregaNegocio();

            try
            {
                bool agregado = negocio.agregar(nuevaFormaEntrega);

                if (agregado)
                {
                    lblMensaje.CssClass = "d-block mt-2 text-success";
                    lblMensaje.Text = "Forma de entrega agregada correctamente";
                    txtNombreFormaEntrega.Text = "";
                    chkRequiereDireccion.Checked = false;
                    txtCostoEntrega.Text = "";
                    cargarFormasEntrega();
                }
                else
                {
                    lblMensaje.CssClass = "d-block mt-2 text-danger";
                    lblMensaje.Text = "Ya existe una forma de entrega con ese nombre";
                }

            }
            catch (Exception)
            {
                lblMensaje.CssClass = "d-block mt-2 text-danger";
                lblMensaje.Text = "Ocurrió un error al agregar la forma de entrega.";
            }
        }

        protected void gvFormasEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!esAdministrador())
            {
                return;
            }

            string id = gvFormasEntrega.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioFormaEntrega.aspx?id=" + id);
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