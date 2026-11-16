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

                    if (detalle.Producto == null || detalle.Cantidad <= 0)
                    {
                        lblCarrito.Text = "Hay un producto inválido en el carrito.";
                        return;
                    }

                    bool encontrado = false;

                    foreach (Producto producto in productos)
                    {
                        if (detalle.Producto.IdProducto == producto.IdProducto)
                        {
                            encontrado = true;

                            if (detalle.Cantidad > producto.Stock)
                            {
                                lblCarrito.Text = "No hay stock suficiente para " + producto.Nombre + ". Cantidad solicitada: " + detalle.Cantidad + ". Stock disponible: " + producto.Stock;
                                return;
                            }

                            detalle.Producto = producto;
                            detalle.PrecioUnitario = producto.Precio;
                            break;
                        }
                    }

                    if (!encontrado)
                    {
                        lblCarrito.Text = "Uno de los productos del carrito ya no está disponible.";
                        return;
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

                ddlFormaPago.Items.Insert(0, new ListItem("Seleccione una forma de pago", ""));

                FormaEntregaNegocio negocioEntrega = new FormaEntregaNegocio();

                List<FormaEntrega> formasEntrega = negocioEntrega.listarFormasEntrega();

                List<FormaEntrega> entregasActivas = new List<FormaEntrega>();

                foreach (FormaEntrega entrega in formasEntrega)
                {
                    if (entrega.Estado)
                    {
                        entregasActivas.Add(entrega);
                    }
                }

                ddlFormaEntrega.DataSource = entregasActivas;
                ddlFormaEntrega.DataTextField = "Nombre";
                ddlFormaEntrega.DataValueField = "IdFormaEntrega";
                ddlFormaEntrega.DataBind();

                ddlFormaEntrega.Items.Insert(0, new ListItem("Seleccione una forma de entrega", ""));

                btnConfirmarCompra.Enabled = true;

            }
        }

        protected void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            List<ItemCarrito> carrito = Session["Carrito"] as List<ItemCarrito>;

            if (carrito == null || carrito.Count == 0)
            {
                lblMensaje.Text = "El carrito está vacío.";
                return;
            }

            if (ddlFormaPago.SelectedValue == "" || ddlFormaEntrega.SelectedValue == "")
            {
                lblMensaje.Text =
                    "Debés seleccionar una forma de pago y una forma de entrega.";
                return;
            }

            lblMensaje.Text =
                "Datos seleccionados correctamente.";
        }
    }
}