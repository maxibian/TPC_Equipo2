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
                ddlCategoria.DataSource = new CategoriaNegocio().ListarCategorias();
                ddlCategoria.DataValueField = "IdCategoria";
                ddlCategoria.DataTextField = "Nombre";
                ddlCategoria.DataBind(); 
            }
        }
        private void MostrarMensaje(string texto, bool esError)
        {
            lblMensaje.CssClass = "d-block mt-3 " + (esError ? "text-danger" : "text-success");
            lblMensaje.Text = texto;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MostrarMensaje("Ingresá el nombre.", true);
                return;
            }

            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out precio) || precio < 0)
            {
                MostrarMensaje("El precio no es válido.", true);
                return;
            }

            int stock;
            if (!int.TryParse(txtStock.Text, out stock) || stock < 0)
            {
                MostrarMensaje("El stock no es válido.", true);
                return;
            }

            if (ddlCategoria.SelectedValue == "0")
            {
                MostrarMensaje("Seleccioná una categoría.", true);
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

                MostrarMensaje("Producto guardado.", false);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                // Si el nombre ya existe, el UNIQUE tira error
                MostrarMensaje("No se pudo guardar: " + ex.Message, true);
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
