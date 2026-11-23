using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo2
{
    public partial class FormularioCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idTexto = Request.QueryString["id"];

                if (!int.TryParse(idTexto, out int idCategoria) || idCategoria <= 0)
                {
                    lblMensaje.Text = "El identificador de la categoría no es válido.";
                    btnGuardar.Enabled = false;
                    return;
                }

                CategoriaNegocio negocio = new CategoriaNegocio();

                dominio.Categoria categoria = negocio.buscarPorId(idCategoria);

                if (categoria == null)
                {
                    lblMensaje.Text = "La categoría no existe.";
                    btnGuardar.Enabled = false;
                    return;
                }

                txtNombre.Text = categoria.Nombre;
                chkEstado.Checked = categoria.Estado;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string idTexto = Request.QueryString["id"];

            if (!int.TryParse(idTexto, out int idCategoria) || idCategoria <= 0)
            {
                lblMensaje.Text = "El identificador de la categoría no es válido.";
                return;
            }

            dominio.Categoria categoria = new dominio.Categoria();

            categoria.IdCategoria = idCategoria;
            categoria.Nombre = txtNombre.Text.Trim();

            try
            {
                CategoriaNegocio negocio = new CategoriaNegocio();

                bool modificada = negocio.modificar(categoria);


                if (modificada)
                {
                    lblMensaje.Text = "Categoría modificada correctamente.";
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
    }
}