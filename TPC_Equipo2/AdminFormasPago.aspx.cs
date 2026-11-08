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
                lblMensaje.Text = "Debe ingresar un nombre para la forma de pago.";
                return;
            }

            if (nombre.Length > 50)
            {
                lblMensaje.Text = "El nombre no puede superar los 50 caracteres.";
                return;
            }

            FormaPago nuevaFormaPago = new FormaPago();

            nuevaFormaPago.Nombre = nombre;

            FormaPagoNegocio negocio = new FormaPagoNegocio();

            bool agregado = negocio.agregar(nuevaFormaPago);

            if (agregado)
            {
                lblMensaje.Text = "Forma de pago agregada correctamente";
                txtNombreFormaPago.Text = "";
                cargarFormasPago();
            }
            else{
                lblMensaje.Text = "Ya existe una forma de pago con ese nombre";
            }

        }

        private void cargarFormasPago()
        {
            FormaPagoNegocio negocio = new FormaPagoNegocio();

            gvFormasPago.DataSource = negocio.listarFormasPago();
            gvFormasPago.DataBind();
        }
    }
}