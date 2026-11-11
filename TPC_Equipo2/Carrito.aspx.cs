using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo2
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CarritoIds"] != null)
                {
                    List<int> idsGuardados = (List<int>)Session["CarritoIds"];
                }
                else
                {
                    lblVacio.Text = "Carrito vacio";
                }
                dgvCarrito.DataSource = Session["CarritoIds"];
                dgvCarrito.DataBind();


            }
        }
    }
}