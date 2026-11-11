using dominio;
using Microsoft.Ajax.Utilities;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo2
{
    public partial class Categoria : System.Web.UI.Page
    {
        public List<Producto> productosLista = new List<Producto>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductoNegocio negocio = new ProductoNegocio();

                string id = Request.QueryString["id"].ToString();
                if (int.TryParse(id, out int idresultado)) { 
                productosLista = negocio.listarCategoria(idresultado);
                repRepeater.DataSource = productosLista;
                repRepeater.DataBind();       
                }





            }
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