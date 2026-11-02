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
    public partial class SiteMaster : MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            if (!IsPostBack) 
            {
            ddlCategoria.DataSource = negocio.ListarCategorias();
            ddlCategoria.DataValueField = "idCategoria";
            ddlCategoria.DataTextField = "Nombre";
            ddlCategoria.DataBind();
            }
        }
    }
}