using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace TPC_Equipo2
{
    public partial class AdminFormasPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarFormasPago();
            }
            
        }

        protected void btnAgregarFormaPago_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreFormaPago.Text.Trim();

            if (nombre == "")
            {
                lblMensaje.CssClass = "d-block mt-2 text-danger";
                lblMensaje.Text = "Debe ingresar un nombre para la forma de pago.";
                return;
            }

            if (nombre.Length > 50)
            {
                lblMensaje.CssClass = "d-block mt-2 text-danger";
                lblMensaje.Text = "El nombre no puede superar los 50 caracteres.";
                return;
            }

            FormaPago nuevaFormaPago = new FormaPago();

            nuevaFormaPago.Nombre = nombre;

            FormaPagoNegocio negocio = new FormaPagoNegocio();

            try
            {
                bool agregado = negocio.agregar(nuevaFormaPago);

                if (agregado)
                {
                    lblMensaje.CssClass = "d-block mt-2 text-success";
                    lblMensaje.Text = "Forma de pago agregada correctamente";                   
                    txtNombreFormaPago.Text = "";
                    cargarFormasPago();
                }
                else
                {
                    lblMensaje.CssClass = "d-block mt-2 text-warning";
                    lblMensaje.Text = "Ya existe una forma de pago con ese nombre";
                }

            }
            catch (Exception)
            {
                lblMensaje.CssClass = "d-block mt-2 text-danger";
                lblMensaje.Text = "Ocurrió un error al agregar la forma de pago.";
            }       

        }

        private void cargarFormasPago()
        {
            FormaPagoNegocio negocio = new FormaPagoNegocio();

            gvFormasPago.DataSource = negocio.listarFormasPago();
            gvFormasPago.DataBind();
        }

        protected void gvFormasPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvFormasPago.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioFormaPago.aspx?id=" + id);
        }
    }
}