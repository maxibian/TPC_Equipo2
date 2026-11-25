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

                string id = Request.QueryString["id"];
                if (int.TryParse(id, out int idresultado))
                {
                    productosLista = negocio.listarCategoria(idresultado);
                    foreach (Producto producto in productosLista)
                        if (producto.Imagen == null || string.IsNullOrWhiteSpace(producto.Imagen.ImagenUrl))
                            producto.Imagen = new Imagen() { ImagenUrl = "https://www.svgrepo.com/show/508699/landscape-placeholder.svg" };
                    repRepeater.DataSource = productosLista;
                    repRepeater.DataBind();
                }
                else
                {
                    Response.Redirect("Inicio.aspx", false);
                }
            }
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

        protected void btnProducto_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int idProducto = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect("ProductoDetalle.aspx?id=" + idProducto);
        }
    }
}