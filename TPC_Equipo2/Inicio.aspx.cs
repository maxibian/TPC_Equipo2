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
            try
            {
                Helper.AgregarAlCarrito(id);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }

        }
    }
}