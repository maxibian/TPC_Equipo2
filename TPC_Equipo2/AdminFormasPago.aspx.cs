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
                FormaPagoNegocio formaPago = new FormaPagoNegocio();
                gvFormasPago.DataSource = formaPago.listarFormasPago();
                gvFormasPago.DataBind();
            }
            
        }

        protected void btnAgregarFormaPago_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreFormaPago.Text.Trim();

            if (nombre == "")
            {
                //Mostrar mensaje de error
                return;
            }
            

            
        }
    }
}