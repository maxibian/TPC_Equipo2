using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPC_Equipo2
{
    public partial class Inicio : Page
    {

        public List<Producto> listaProducto {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductoNegocio negocio = new ProductoNegocio();

                listaProducto = negocio.listarProductos();

                string busqueda = (string)Session["busquedaProducto"];

                Session.Remove("busquedaProducto");

                if (!string.IsNullOrWhiteSpace(busqueda))
                {
                    List<Producto> productosFiltrados = new List<Producto>();

                    foreach (Producto producto in listaProducto)
                    {
                        if (producto.Nombre.ToLower().Contains(busqueda.ToLower()))
                        {
                            productosFiltrados.Add(producto);
                        }
                    }

                    listaProducto = productosFiltrados;
                }

                foreach (dominio.Producto producto in listaProducto)
                    if (producto.Imagen == null || string.IsNullOrWhiteSpace(producto.Imagen.ImagenUrl))
                        producto.Imagen = new Imagen() { ImagenUrl = "https://www.svgrepo.com/show/508699/landscape-placeholder.svg" };

                repRepeater.DataSource = listaProducto;
                repRepeater.DataBind();
            }

        }
        protected void btnProducto_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;

            int idProducto = Convert.ToInt32(btn.CommandArgument);

            Response.Redirect("ProductoDetalle.aspx?id=" + idProducto);
        }

        protected void btnAgregarAlCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(((LinkButton)sender).CommandArgument);
                Helper.AgregarAlCarrito(id);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
    }
}