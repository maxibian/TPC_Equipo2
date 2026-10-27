using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace TPC_Equipo2
{
    public partial class Prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DireccionNegocio negocio = new DireccionNegocio();
            dgvPrueba.DataSource = negocio.listarDireccion();
            dgvPrueba.DataBind();
        }
    }
}