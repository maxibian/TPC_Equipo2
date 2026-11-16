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

                    CalcularTotales(carrito);
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

            CalcularTotales(carrito);
        }
        private void CalcularTotales(List<ItemCarrito> carrito)
        {
            decimal subtotal = carrito.Sum(x => x.PrecioUnitario * x.Cantidad);
            decimal envio = 5000;
            decimal total = subtotal + envio;
            lblSubtotal.Text = "Subtotal: $" + subtotal.ToString("N2");
            lblEnvio.Text = "Envío: $" + envio.ToString("N2");
            lblTotal.Text = "Total: $" + total.ToString("N2");

            if(carrito.Count == 0)
            {
                lblVacio.Text = "Carrito vacío";
                btnRealizarCompra.Visible = false;
                lblSubtotal.Visible = false;
                lblEnvio.Visible = false;
                lblTotal.Visible = false;
            }
        }

        protected void btnRealizarCompra_Click(object sender, EventArgs e)
        {
            List<ItemCarrito> carrito = Session["Carrito"] as List<ItemCarrito>;

            if (carrito == null || carrito.Count == 0)
            {
                lblVacio.Text = "No hay productos en el carrito.";
                return;
            }

            Response.Redirect("ConfirmarCompra.aspx");
        }
    }
}