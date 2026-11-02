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

            ddlCategoria.Items.Insert(0, new ListItem("Seleccione una categoría...", ""));
            }
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            id = int.Parse(ddlCategoria.SelectedValue);
            if(id != 0)
            {
                Response.Redirect("Categoria.aspx?id=" + id);
            }
        }
    }
}