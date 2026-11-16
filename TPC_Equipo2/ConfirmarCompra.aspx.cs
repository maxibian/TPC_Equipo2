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
    public partial class ConfirmarCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<ItemCarrito> carrito = Session["Carrito"] as List<ItemCarrito>;

                if (carrito == null || carrito.Count == 0)
                {
                    lblCarrito.Text = "No hay productos en el carrito.";
                    return;
                }

                List<DetalleVenta> detallesCarrito = new List<DetalleVenta>();

                foreach (ItemCarrito item in carrito)
                {
                    DetalleVenta detalle = new DetalleVenta();

                    detalle.Producto = item.Producto;
                    detalle.Cantidad = item.Cantidad;
                    detalle.PrecioUnitario = item.PrecioUnitario;

                    detallesCarrito.Add(detalle);
                }

                ProductoNegocio negocioProductos = new ProductoNegocio();

                List<Producto> productos = negocioProductos.listarProductos();


                foreach (DetalleVenta detalle in detallesCarrito)
                {
                    foreach (Producto producto in productos)
                    {
                        if (detalle.Producto.IdProducto == producto.IdProducto)
                        {
                            detalle.Producto = producto;
                            detalle.PrecioUnitario = producto.Precio;
                        }
                    }
                }

                gvResumen.DataSource = detallesCarrito;
                gvResumen.DataBind();

                decimal total = 0;

                foreach (DetalleVenta detalle in detallesCarrito)
                {
                    total += detalle.Subtotal;
                }

                lblTotal.Text = total.ToString("N2");

                FormaPagoNegocio negocioPago = new FormaPagoNegocio();

                List<FormaPago> formasPago = negocioPago.listarFormasPago();

                List<FormaPago> pagosActivos = new List<FormaPago>();

                foreach (FormaPago pago in formasPago)
                {
                    if (pago.Estado)
                    {
                        pagosActivos.Add(pago);
                    }
                }

                ddlFormaPago.DataSource = pagosActivos;
                ddlFormaPago.DataTextField = "Nombre";
                ddlFormaPago.DataValueField = "IdFormaPago";
                ddlFormaPago.DataBind();

                ddlFormaPago.Items.Insert(0, new ListItem("Seleccione una forma de pago"));

            }
        }
    }
}