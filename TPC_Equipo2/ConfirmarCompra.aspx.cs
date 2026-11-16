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
                List<int> carritoIds = Session["CarritoIds"] as List<int>;

                if (carritoIds == null || carritoIds.Count == 0)
                {
                    lblCarrito.Text = "No hay productos en el carrito.";
                    return;
                }

                List<int> productosUnicos = new List<int>();

                foreach (int id in carritoIds)
                {
                    if (!productosUnicos.Contains(id))
                    {
                        productosUnicos.Add(id);
                    }
                }

                List<DetalleVenta> detallesCarrito = new List<DetalleVenta>();

                foreach (int idProducto in productosUnicos)
                {
                    int cantidad = 0;

                    foreach (int id in carritoIds)
                    {
                        if (id == idProducto)
                        {
                            cantidad++;
                        }
                    }

                    DetalleVenta detalle = new DetalleVenta();

                    detalle.Producto = new Producto();

                    detalle.Producto.IdProducto = idProducto;
                    detalle.Cantidad = cantidad;

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