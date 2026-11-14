using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo2
{
    public partial class AdminVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarVentas();
            }
        }

        private void cargarVentas()
        {
            VentaNegocio negocio = new VentaNegocio();

            gvVentas.DataSource = negocio.listarVentas();
            gvVentas.DataBind();
        }

        protected void gvVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idVenta = Convert.ToInt32(gvVentas.SelectedDataKey.Value);
            //Response.Redirect("DetalleVenta.aspx?id=" + idVenta);
        }
    }
}