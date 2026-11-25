using dominio;
using negocio;
using System;
using System.Collections;
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
            if (!esAdministrador())
            {
                Response.Redirect("Inicio.aspx");
                return;
            }

            if (!IsPostBack)
            {
                ddlCategoria.DataSource = new CategoriaNegocio().ListarCategoriasNuevoProducto();
                ddlCategoria.DataValueField = "IdCategoria";
                ddlCategoria.DataTextField = "Nombre";
                ddlCategoria.DataBind();

                if (Request.QueryString["id"] != null)
                {
                    lblTitulo.Text = "Modificar producto";
                    btnGuardar.Visible = false;
                    int idProducto;
                    if (int.TryParse(Request.QueryString["id"], out idProducto))
                    {
                        Producto producto = new ProductoNegocio().obtenerProducto(idProducto);
                        if (producto != null)
                        {
                            txtNombre.Text = producto.Nombre;
                            txtDescripcion.Text = producto.Descripcion;
                            txtPrecio.Text = producto.Precio.ToString();
                            txtStock.Text = producto.Stock.ToString();
                            ddlCategoria.SelectedValue = producto.Categoria.IdCategoria.ToString();
                            if (producto.Imagen != null)
                            {
                                txtImagenUrl.Text = producto.Imagen.ImagenUrl;
                            }
                        }
                        else
                        {
                            MostrarMensaje("Producto no encontrado.", true);
                        }
                    }
                    else
                    {
                        MostrarMensaje("ID de producto inválido.", true);
                    }
                }
                else
                {
                    btnModificar.Visible = false;
                    btnEliminar.Visible = false;
                }  
            }
        }
        private void MostrarMensaje(string texto, bool esError)
        {
            lblMensaje.CssClass = "d-block mt-3 " + (esError ? "text-danger" : "text-success");
            lblMensaje.Text = texto;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!esAdministrador())
            {
                return;
            }

            // Validaciones
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MostrarMensaje("Ingresá el nombre.", true);
                return;
            }

            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out precio) || precio <= 0)
            {
                MostrarMensaje("El precio no es válido.", true);
                return;
            }

            int stock;
            if (!int.TryParse(txtStock.Text, out stock) || stock <= 0)
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
            catch (Exception)
            {
                MostrarMensaje("Ya existe un producto con ese nombre.", true);
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
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!esAdministrador())
            {
                return;
            }

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
                int idProducto = int.Parse(Request.QueryString["id"]);

                Producto modificar = new Producto();

                modificar.IdProducto = idProducto;
                modificar.Nombre = txtNombre.Text.Trim();
                modificar.Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim();
                modificar.Precio = precio;
                modificar.Stock = stock;

                modificar.Categoria = new dominio.Categoria();
                modificar.Categoria.IdCategoria = int.Parse(ddlCategoria.SelectedValue);

                if (!string.IsNullOrWhiteSpace(txtImagenUrl.Text))
                {
                    modificar.Imagen = new Imagen();
                    modificar.Imagen.ImagenUrl = txtImagenUrl.Text.Trim();
                }

                new ProductoNegocio().modificar(modificar);



                MostrarMensaje("Producto modificado correctamente.", false);
            }
            catch (Exception)
            {
                MostrarMensaje("No se pudo modificar el producto.", true);
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!esAdministrador())
            {
                return;
            }

            try
            {
                int idProducto = int.Parse(Request.QueryString["id"]);

                Producto producto = new Producto();

                producto.IdProducto = idProducto;
                producto.Estado = false;

                new ProductoNegocio().eliminar(producto);

                MostrarMensaje("Producto dado de baja correctamente.", false);
            }
            catch (Exception)
            {
                MostrarMensaje("No se pudo dar de baja el producto.", true);
            }
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


    }
}
