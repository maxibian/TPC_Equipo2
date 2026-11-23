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
    public partial class AdministrarDireccion : System.Web.UI.Page
    {
        List<Direccion> direccionList;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] == null)
            {
                Response.Redirect("Inicio.aspx", false);

            }

            if (!IsPostBack)
            {
                int usuario = ((Usuario)Session["usuario"]).IdUsuario;
                
                DireccionNegocio negocio = new DireccionNegocio();

                direccionList = negocio.listarDireccionesPorCliente(usuario);
                
                dgvDireccion.DataSource = direccionList;
                dgvDireccion.DataBind();

            }


        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}