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
    public partial class ProductoDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idProducto;

                if (int.TryParse(Request.QueryString["id"], out idProducto))
                {
                    ProductoNegocio negocio = new ProductoNegocio();

                    dominio.Producto producto = negocio.obtenerProducto(idProducto);

                    if (producto != null)
                    {
                        lblNombre.Text = producto.Nombre;
                        lblDescripcion.Text = producto.Descripcion;
                        lblPrecio.Text = producto.Precio.ToString("N2");
                        lblStock.Text = producto.Stock.ToString();

                        if (producto.Imagen == null || string.IsNullOrEmpty(producto.Imagen.ImagenUrl))
                            imgProducto.ImageUrl = "https://www.svgrepo.com/show/508699/landscape-placeholder.svg";
                        else 
                            imgProducto.ImageUrl = producto.Imagen.ImagenUrl;
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
    }
}