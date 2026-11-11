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
    public partial class Inicio : System.Web.UI.Page
    {
        public List<Producto> ListaProducto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            ListaProducto = negocio.listarProductos();
            repRepeater .DataSource = ListaProducto;
            repRepeater.DataBind();
        }

        protected void btnCarrito_Click(object sender, EventArgs e)
        {
            LinkButton producto = (LinkButton)sender;
            int id = int.Parse(producto.CommandArgument);
            List<int> carritoIds;

            if (Session["CarritoIds"] != null)
            {
                carritoIds = (List<int>)Session["CarritoIds"];
            }
            else
            {
                carritoIds = new List<int>();
            }

            carritoIds.Add(id);

            Session["CarritoIds"] = carritoIds;

        }
    }
}