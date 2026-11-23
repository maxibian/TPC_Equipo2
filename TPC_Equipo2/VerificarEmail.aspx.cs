using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo2
{
    public partial class VerificarEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string token = Request.QueryString["token"];
            UsuarioNegocio negocio = new UsuarioNegocio();

            if (token != null && negocio.activarCuenta(token))
            {
                lblMensaje.Text = "¡Tu cuenta fue activada! Ya podés iniciar sesión.";
            }
            else
            {
                lblMensaje.Text = "El link no es válido o la cuenta ya fue activada.";
            }
        }
    }
}