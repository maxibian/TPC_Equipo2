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
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];

                bool valido = int.TryParse(id, out int numero);

                if (!valido || numero <= 0)
                {
                    lblMensaje.Text = "ID inválido";
                    return;
                }

                FormaPagoNegocio negocio = new FormaPagoNegocio();
                FormaPago forma = negocio.buscarPorId(numero);

                if (forma == null)
                {
                    lblMensaje.Text = "No se encontró la forma de pago.";
                    return;
                }

                lblMensaje.Text = "Forma de pago encontrada: " + forma.Nombre;

                txtNombreFormaPago.Text = forma.Nombre;
                chkEstado.Checked = forma.Estado;
                
            }

        }
    }
}