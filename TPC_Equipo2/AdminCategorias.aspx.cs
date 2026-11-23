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
    public partial class AdminCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!esAdministrador())
            {
                Response.Redirect("Inicio.aspx");
                return;
            }

            if (!IsPostBack)
            {
                cargarCategorias();
            }
        }

        private void cargarCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            gvCategorias.DataSource = negocio.ListarCategorias();
            gvCategorias.DataBind();
        }

        private bool esAdministrador()
        {
            Usuario usuario = Session["usuario"] as Usuario;

            if (usuario == null || usuario.Rol == null)
            {
                return false;
            }

            return usuario.Rol.IdRol == 1 && usuario.Estado;
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            if (!esAdministrador())
            {
                return;
            }

            string nombre = txtNombreCategoria.Text.Trim();

            dominio.Categoria nueva = new dominio.Categoria();

            nueva.Nombre = nombre;

            CategoriaNegocio negocio = new CategoriaNegocio();

            try
            {
                bool agregada = negocio.agregar(nueva);

                if (agregada)
                {
                    lblMensaje.Text = "Categoría agregada correctamente.";
                    txtNombreCategoria.Text = "";
                    cargarCategorias();
                }
                else
                {
                    lblMensaje.Text = "Ya existe una categoría con ese nombre.";
                }
            }
            catch (ArgumentException ex)
            {
                lblMensaje.Text = ex.Message;
            }

        }

        protected void gvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!esAdministrador())
            {
                return;
            }

            string id = gvCategorias.SelectedDataKey.Value.ToString();

            Response.Redirect("FormularioCategoria.aspx?id=" + id);
        }
    }
}