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
    public partial class AdminFormaEntrega : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarFormasPago();
            }
        }

        protected void gvFormasEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cargarFormasPago()
        {
            FormaEntregaNegocio negocio = new FormaEntregaNegocio();

            gvFormasEntrega.DataSource = negocio.listarFormasEntrega();
            gvFormasEntrega.DataBind();
        }

        protected void btnAgregarFormaEntrega_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreFormaEntrega.Text.Trim();

            if (nombre == "")
            {
                lblMensaje.Text = "Debe ingresar un nombre para la forma de entrega.";
                return;
            }

            if (nombre.Length > 50)
            {
                lblMensaje.Text = "El nombre no puede superar los 50 caracteres.";
                return;
            }

            FormaEntrega nuevaFormaEntrega = new FormaEntrega();

            nuevaFormaEntrega.Nombre = nombre;

            FormaEntregaNegocio negocio = new FormaEntregaNegocio();

            try
            {
                bool agregado = negocio.agregar(nuevaFormaEntrega);

                if (agregado)
                {
                    lblMensaje.Text = "Forma de entrega agregada correctamente";
                    txtNombreFormaEntrega.Text = "";
                    cargarFormasPago();
                }
                else
                {
                    lblMensaje.Text = "Ya existe una forma de entrega con ese nombre";
                }

            }
            catch (Exception)
            {
                lblMensaje.Text = "Ocurrió un error al agregar la forma de entrega.";
            }
        }
    }
}