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
    public partial class AdministrarUsuarios : System.Web.UI.Page
    {
        List<Rol> listaRoles = new List<Rol>();
        protected void Page_Load(object sender, EventArgs e)
        {
            RolNegocio negocio = new RolNegocio();
            listaRoles = negocio.ListarRoles();

            ddlRol.DataSource = listaRoles;
            ddlRol.DataTextField = "Nombre";
            ddlRol.DataValueField = "IdRol";
            ddlRol.DataBind();


        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

    }
}