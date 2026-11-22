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
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<ItemCarrito> carrito = ObtenerItems();

                    dgvCarrito.DataSource = carrito;
                    dgvCarrito.DataBind();

                    CalcularTotales(carrito);
            }
        }
        protected void dgvCarrito_BorrarFila(object sender, GridViewDeleteEventArgs e)
        {
            List<ItemCarrito> carrito = ObtenerItems();

            ItemCarrito item = carrito[e.RowIndex];
            int idProducto = item.Producto.IdProducto;

            ItemCarritoNegocio itemNegocio = new ItemCarritoNegocio();

            if (Session["usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["usuario"];

                dominio.Carrito carritoDb = new CarritoNegocio().obtenerOCrearCarrito(usuario.IdUsuario);

                if (item.Cantidad > 1)
                    itemNegocio.modificarItemCarrito(carritoDb.IdCarrito, idProducto, item.Cantidad - 1);
                else
                    itemNegocio.eliminarItemCarrito(carritoDb.IdCarrito, idProducto);
            }
            
            else
            {
                if (item.Cantidad > 1)
                    itemNegocio.modificarItemSession(carrito, idProducto, item.Cantidad - 1);
                else
                    itemNegocio.eliminarItemSession(carrito, idProducto);

                Session["Carrito"] = carrito;
            }
            carrito = ObtenerItems();

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

        private List<ItemCarrito> ObtenerItems()
        {
            if (Session["usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["usuario"];
                CarritoNegocio carritoNegocio = new CarritoNegocio();
                dominio.Carrito carrito = carritoNegocio.obtenerOCrearCarrito(usuario.IdUsuario);

                if (carrito == null)
                    return new List<ItemCarrito>();

                ItemCarritoNegocio itemNegocio = new ItemCarritoNegocio();
                return itemNegocio.listar(carrito.IdCarrito);
            }
            else
            {
                List<ItemCarrito> lista = (List<ItemCarrito>)Session["Carrito"];
                if (lista == null)
                    lista = new List<ItemCarrito>();
                return lista;
            }
        }

        protected void btnRealizarCompra_Click(object sender, EventArgs e)
        {
            List<ItemCarrito> carrito = ObtenerItems();

            if (carrito == null || carrito.Count == 0)
            {
                lblVacio.Text = "No hay productos en el carrito.";
                return;
            }
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
                return;
            }

            Response.Redirect("ConfirmarCompra.aspx", false);
        }
    }
}