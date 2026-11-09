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
    }
}