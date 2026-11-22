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

                Usuario usuario = Session["usuario"] as Usuario;

                if (usuario == null)
                {
                    Response.Redirect("Login.aspx", false);
                    return;
                }

                List<ItemCarrito> carrito = obtenerItemsCarrito(usuario);

                if (carrito == null || carrito.Count == 0)
                {
                    lblCarrito.Text = "El carrito está vacío.";
                    btnConfirmarCompra.Enabled = false;
                    return;
                }

                List<DetalleVenta> detallesCarrito = new List<DetalleVenta>();

                foreach (ItemCarrito item in carrito)
                {

                    if (item == null || item.Producto == null || item.Producto.IdProducto <= 0 || item.Cantidad <= 0)
                    {
                        lblCarrito.Text = "El carrito contiene productos inválidos.";
                        btnConfirmarCompra.Enabled = false;
                        return;
                    }

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

            Usuario usuario = Session["usuario"] as Usuario;

            if (usuario == null)
            {
                Response.Redirect("Login.aspx", false);
                return;
            }

            CarritoNegocio negocioCarrito = new CarritoNegocio();

            int idCliente = negocioCarrito.obtenerIdCliente(usuario.IdUsuario);

            if (idCliente <= 0)
            {
                lblMensaje.Text = "No se encontró un cliente asociado al usuario.";
                return;
            }

            List<ItemCarrito> carrito = obtenerItemsCarrito(usuario);

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

            int idFormaPago = int.Parse(ddlFormaPago.SelectedValue);
            int idFormaEntrega = int.Parse(ddlFormaEntrega.SelectedValue);

            Venta venta = new Venta();

            venta.Cliente = new Cliente();
            venta.Cliente.IdCliente = idCliente;

            venta.FormaPago = new FormaPago();
            venta.FormaPago.IdFormaPago = idFormaPago;

            venta.FormaEntrega = new FormaEntrega();
            venta.FormaEntrega.IdFormaEntrega = idFormaEntrega;

            foreach (ItemCarrito item in carrito)
            {
                if (item == null || item.Producto == null || item.Producto.IdProducto <= 0 || item.Cantidad <= 0)
                {
                    lblMensaje.Text = "El carrito contiene productos inválidos.";
                    return;
                }

                DetalleVenta detalle = new DetalleVenta();

                detalle.Producto = new Producto();

                detalle.Producto.IdProducto = item.Producto.IdProducto;

                detalle.Cantidad = item.Cantidad;

                venta.Detalles.Add(detalle);
            }

            EstadoVentaNegocio negocioEstados = new EstadoVentaNegocio();

            List<EstadoVenta> estados = negocioEstados.listar();

            EstadoVenta estadoInicial = null;

            foreach (EstadoVenta estado in estados)
            {
                if (estado.Nombre == "Pendiente")
                {
                    estadoInicial = estado;
                    break;
                }
            }

            if (estadoInicial == null)
            {
                lblMensaje.Text = "No se encontró el estado inicial de la venta.";
                return;
            }

            venta.EstadoVenta = estadoInicial;

            lblMensaje.Text = "Venta preparada correctamente.";
        }

        private List<ItemCarrito> obtenerItemsCarrito(Usuario usuario)
        {
            CarritoNegocio negocioCarrito = new CarritoNegocio();

            dominio.Carrito carritoDb = negocioCarrito.obtenerOCrearCarrito(usuario.IdUsuario);

            if (carritoDb == null)
            {
                return new List<ItemCarrito>();
            }

            ItemCarritoNegocio negocioItems = new ItemCarritoNegocio();

            return negocioItems.listar(carritoDb.IdCarrito);
        }

        protected void ddlFormaEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlDireccion.Visible = false;

            if (!int.TryParse(ddlFormaEntrega.SelectedValue, out int idFormaEntrega))
            {
                return;
            }

            FormaEntregaNegocio negocioEntrega = new FormaEntregaNegocio();

            FormaEntrega formaSeleccionada = negocioEntrega.buscarPorId(idFormaEntrega);

            if (formaSeleccionada != null && formaSeleccionada.Estado && formaSeleccionada.RequiereDireccion)
            {
                pnlDireccion.Visible = true;
            }
        }
    }
}