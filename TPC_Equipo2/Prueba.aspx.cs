using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace TPC_Equipo2
{
    public partial class Prueba : System.Web.UI.Page
    {
        public List<Producto> listaProducto {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            listaProducto = negocio.listarProductos();
            repRepeater.DataSource = listaProducto;
            repRepeater.DataBind();
        }
    }
}