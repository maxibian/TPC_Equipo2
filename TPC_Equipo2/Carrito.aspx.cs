using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo2
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Carrito"] != null)
                {
                    List<ItemCarrito> carrito = (List<ItemCarrito>)Session["Carrito"];

                    dgvCarrito.DataSource = carrito;
                    dgvCarrito.DataBind();
                }
                else
                {
                    lblVacio.Text = "Carrito vacio";
                }
            }
        }
        protected void dgvCarrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<ItemCarrito> carrito = (List<ItemCarrito>)Session["Carrito"];

            ItemCarrito item = carrito[e.RowIndex];

            if (item.Cantidad > 1)
            {
                item.Cantidad--;
            }
            else
            {
                carrito.RemoveAt(e.RowIndex);
            }
            Session["Carrito"] = carrito;

            dgvCarrito.DataSource = carrito;
            dgvCarrito.DataBind();
        }
    }
}