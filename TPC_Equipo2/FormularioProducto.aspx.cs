using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo2
{
    public partial class FormularioProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ddlCategoria.DataSource = new CategoriaNegocio().listarCategorias();
                ddlCategoria.DataValueField = "IdCategoria";
                ddlCategoria.DataTextField = "Nombre";
                ddlCategoria.DataBind();
                ddlCategoria.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Seleccioná --", "0"));
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                lblMensaje.Text = "Ingresá el nombre.";
                return;
            }

            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out precio) || precio < 0)
            {
                lblMensaje.Text = "El precio no es válido.";
                return;
            }

            int stock;
            if (!int.TryParse(txtStock.Text, out stock) || stock < 0)
            {
                lblMensaje.Text = "El stock no es válido.";
                return;
            }

            if (ddlCategoria.SelectedValue == "0")
            {
                lblMensaje.Text = "Seleccioná una categoría.";
                return;
            }

            try
            {
                Producto nuevo = new Producto();
                nuevo.Nombre = txtNombre.Text.Trim();
                nuevo.Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim();
                nuevo.Precio = precio;
                nuevo.Stock = stock;

                nuevo.Categoria = new dominio.Categoria();
                nuevo.Categoria.IdCategoria = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Categoria.Nombre = ddlCategoria.SelectedItem.Text;

                if (!string.IsNullOrWhiteSpace(txtImagenUrl.Text))
                {
                    nuevo.Imagen = new Imagen();
                    nuevo.Imagen.ImagenUrl = txtImagenUrl.Text.Trim();
                }

                new ProductoNegocio().agregar(nuevo);

                lblMensaje.Text = "Producto guardado.";
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                // Si el nombre ya existe, el UNIQUE tira error
                lblMensaje.Text = "No se pudo guardar: " + ex.Message;
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtImagenUrl.Text = "";
            ddlCategoria.SelectedIndex = 0;
        }
    }
}
