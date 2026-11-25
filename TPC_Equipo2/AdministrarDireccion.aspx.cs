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
                return;
            }

            if (!IsPostBack)
            {
                cargarDirecciones();

            }
        }
        void cargarDirecciones()
        {
            DireccionNegocio negocio = new DireccionNegocio();

            int usuario = ((Usuario)Session["usuario"]).IdUsuario;
            int idCliente = negocio.isExistCliente(usuario);

            direccionList = negocio.listarDireccionesPorCliente(idCliente);
            dgvDireccion.DataSource = direccionList;
            dgvDireccion.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            DireccionNegocio negocio = new DireccionNegocio();

            Button btn = (Button)sender;
            int id = int.Parse(btn.CommandArgument);

            negocio.eliminarDireccion(id);

            cargarDirecciones();

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevaDireccion.Aspx", false);
        }
    }
}