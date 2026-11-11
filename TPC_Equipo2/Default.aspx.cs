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
    public partial class _Default : Page
    {
        public List<Producto> listaProducto {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();

            listaProducto = negocio.listarProductos();

            foreach (dominio.Producto producto in listaProducto)
                if (producto.Imagen == null || string.IsNullOrWhiteSpace(producto.Imagen.ImagenUrl))
                    producto.Imagen = new Imagen() { ImagenUrl = "https://www.svgrepo.com/show/508699/landscape-placeholder.svg" };

            repRepeater.DataSource = listaProducto;
            repRepeater.DataBind();

        }
        protected void btnProducto_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;

            int idProducto = Convert.ToInt32(btn.CommandArgument);

            Response.Redirect("ProductoDetalle.aspx?id=" + idProducto);
        }
    }

}