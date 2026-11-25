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
            Usuario usuario = Session["usuario"] as Usuario;

            if (usuario == null)
            {
                Response.Redirect("Login.aspx", false);
                return;
            }

            if (!IsPostBack)
            {
                List<ItemCarrito> carrito = obtenerItemsCarrito(usuario);

                if (carrito == null || carrito.Count == 0)
                {
                    lblCarrito.Text = "El carrito está vacío.";
                    btnConfirmarCompra.Enabled = false;
                    return;
                }

                if (!prepararDetallesCarrito(carrito, out List<DetalleVenta> detallesCarrito, out string mensaje))
                {
                    lblCarrito.Text = mensaje;
                    btnConfirmarCompra.Enabled = false;
                    return;
                }

                gvResumen.DataSource = detallesCarrito;
                gvResumen.DataBind();

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

                actualizarResumenCompra();

            }

            if (IsPostBack)
            {
                pnlDireccion.Visible = requiereDireccionSeleccionada();
                pnlNuevaDireccion.Visible = pnlDireccion.Visible && ddlDireccion.SelectedValue == "nueva";
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

            if (!int.TryParse(ddlFormaPago.SelectedValue, out int idFormaPago) || !int.TryParse(ddlFormaEntrega.SelectedValue, out int idFormaEntrega))
            {
                lblMensaje.Text = "Seleccioná una forma de pago y una forma de entrega válidas.";
                return;
            }

            FormaEntregaNegocio negocioEntrega = new FormaEntregaNegocio();

            FormaEntrega formaEntrega = negocioEntrega.buscarPorId(idFormaEntrega);

            if (formaEntrega == null || !formaEntrega.Estado)
            {
                lblMensaje.Text = "La forma de entrega seleccionada ya no está disponible.";
                return;
            }

            FormaPagoNegocio negocioPago = new FormaPagoNegocio();

            FormaPago formaPago = negocioPago.buscarPorId(idFormaPago);

            if (formaPago == null || !formaPago.Estado)
            {
                lblMensaje.Text = "La forma de pago seleccionada ya no está disponible.";
                return;
            }

            Venta venta = new Venta();

            venta.Cliente = new Cliente();
            venta.Cliente.IdCliente = idCliente;

            venta.FormaPago = formaPago;
            venta.FormaEntrega = formaEntrega;

            if (formaEntrega.RequiereDireccion)
            {
                if (string.IsNullOrEmpty(ddlDireccion.SelectedValue))
                {
                    lblMensaje.Text = "Debés seleccionar una dirección de entrega.";
                    return;
                }

                if (ddlDireccion.SelectedValue == "nueva")
                {
                    string calle = txtCalle.Text.Trim();
                    string localidad = txtLocalidad.Text.Trim();
                    string provincia = txtProvincia.Text.Trim();
                    string codigoPostal = txtCodigoPostal.Text.Trim();
                    string observacion = txtObservacion.Text.Trim();

                    if (!int.TryParse(txtNumero.Text, out int numero) || numero <= 0)
                    {
                        lblMensaje.Text = "Ingresá un número de dirección válido.";
                        return;
                    }

                    Direccion nuevaDireccion = new Direccion();

                    nuevaDireccion.IdCliente = idCliente;
                    nuevaDireccion.Calle = calle;
                    nuevaDireccion.Numero = numero;
                    nuevaDireccion.Localidad = localidad;
                    nuevaDireccion.Provincia = provincia;
                    nuevaDireccion.CodigoPostal = codigoPostal;
                    nuevaDireccion.Observacion = observacion;

                    if (!validarDireccion(nuevaDireccion, out string mensaje))
                    {
                        lblMensaje.Text = mensaje;
                        return;
                    }

                    venta.Direccion = nuevaDireccion;
                }
                else
                {
                    if (!int.TryParse(ddlDireccion.SelectedValue, out int idDireccion))
                    {
                        lblMensaje.Text = "La dirección seleccionada no es válida.";
                        return;
                    }

                    DireccionNegocio negocioDireccion = new DireccionNegocio();

                    List<Direccion> direcciones = negocioDireccion.listarDireccionesPorCliente(idCliente);

                    Direccion direccionSeleccionada = null;

                    foreach (Direccion direccion in direcciones)
                    {
                        if (direccion.IdDireccion == idDireccion)
                        {
                            direccionSeleccionada = direccion;
                            break;
                        }
                    }

                    if (direccionSeleccionada == null)
                    {
                        lblMensaje.Text = "La dirección seleccionada no pertenece al cliente o está inactiva.";
                        return;
                    }

                    venta.Direccion = direccionSeleccionada;
                }
            }

            if (!prepararDetallesCarrito(carrito, out List<DetalleVenta> detallesCarrito, out string mensajeCarrito))
            {
                lblMensaje.Text = mensajeCarrito;
                return;
            }

            foreach (DetalleVenta detalle in detallesCarrito)
            {
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

            bool ventaRegistrada = false;

            try
            {
                if (formaEntrega.RequiereDireccion && ddlDireccion.SelectedValue == "nueva")
                {
                    DireccionNegocio negocioDireccion = new DireccionNegocio();

                    venta.Direccion.IdDireccion =
                        negocioDireccion.agregarDireccionYObtenerId(venta.Direccion);
                }

                VentaNegocio negocioVenta = new VentaNegocio();
                negocioVenta.agregar(venta);

                ventaRegistrada = true;

                dominio.Carrito carritoDb = negocioCarrito.obtenerCarrito(idCliente);

                if (carritoDb != null)
                {
                    ItemCarritoNegocio negocioItems = new ItemCarritoNegocio();
                    negocioItems.vaciarCarrito(carritoDb.IdCarrito);
                }

                try
                {
                    Venta ventaGuardada = negocioVenta.obtenerVenta(venta.IdVenta);

                    NotificacionNegocio notificacion = new NotificacionNegocio();
                    notificacion.enviarCorreoConfirmacion(ventaGuardada);
                }
                catch (Exception)
                {

                }

                Response.Redirect("~/CompraExitosa.aspx?id=" + venta.IdVenta, false);
                return;

            }
            catch (Exception)
            {
                if (ventaRegistrada)
                {
                    lblMensaje.Text = "La compra se registró, pero no se pudo vaciar el carrito.";
                }
                else
                {
                    lblMensaje.Text = "Ocurrió un error al registrar la compra. Verificá el pedido antes de volver a intentarlo.";
                }
            }

            btnConfirmarCompra.Enabled = false;
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
            actualizarResumenCompra();

            pnlDireccion.Visible = false;

            if (!int.TryParse(ddlFormaEntrega.SelectedValue, out int idFormaEntrega))
            {
                return;
            }

            FormaEntregaNegocio negocioEntrega = new FormaEntregaNegocio();

            FormaEntrega formaSeleccionada = negocioEntrega.buscarPorId(idFormaEntrega);

            if (formaSeleccionada != null && formaSeleccionada.Estado && formaSeleccionada.RequiereDireccion)
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

                cargarDirecciones(idCliente);

                pnlDireccion.Visible = true;
            }
        }

        private void cargarDirecciones(int idCliente)
        {
            DireccionNegocio negocioDireccion = new DireccionNegocio();

            List<Direccion> direcciones = negocioDireccion.listarDireccionesPorCliente(idCliente);

            ddlDireccion.Items.Clear();

            ddlDireccion.Items.Add(new ListItem("Seleccione una dirección", ""));

            foreach (Direccion direccion in direcciones)
            {
                string texto = direccion.Calle + " " + direccion.Numero + " - " + direccion.Localidad;

                ddlDireccion.Items.Add(new ListItem(texto, direccion.IdDireccion.ToString()));
            }

            ddlDireccion.Items.Add(new ListItem("Ingresar una nueva dirección", "nueva"));
        }

        private bool requiereDireccionSeleccionada()
        {
            if (!int.TryParse(ddlFormaEntrega.SelectedValue, out int idFormaEntrega))
            {
                return false;
            }

            FormaEntregaNegocio negocioEntrega = new FormaEntregaNegocio();

            FormaEntrega forma = negocioEntrega.buscarPorId(idFormaEntrega);

            return forma != null && forma.Estado && forma.RequiereDireccion;
        }

        protected void ddlDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlNuevaDireccion.Visible = pnlDireccion.Visible && ddlDireccion.SelectedValue == "nueva";
        }

        private bool validarDireccion(Direccion direccion, out string mensaje)
        {
            mensaje = "";

            if (string.IsNullOrWhiteSpace(direccion.Calle))
            {
                mensaje = "La calle es obligatoria.";
                return false;
            }

            if (direccion.Numero <= 0)
            {
                mensaje = "El número debe ser mayor a cero.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(direccion.Localidad))
            {
                mensaje = "La localidad es obligatoria.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(direccion.Provincia))
            {
                mensaje = "La provincia es obligatoria.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(direccion.CodigoPostal))
            {
                mensaje = "El código postal es obligatorio.";
                return false;
            }

            if (direccion.Calle.Length > 100 || direccion.Localidad.Length > 50 || direccion.Provincia.Length > 50 || direccion.CodigoPostal.Length > 10 || (direccion.Observacion != null && direccion.Observacion.Length > 200))
            {
                mensaje = "Uno de los campos supera la longitud permitida.";
                return false;
            }

            return true;
        }

        private bool prepararDetallesCarrito(List<ItemCarrito> carrito, out List<DetalleVenta> detalles, out string mensaje)
        {
            detalles = new List<DetalleVenta>();
            mensaje = "";

            if (carrito == null || carrito.Count == 0)
            {
                mensaje = "El carrito está vacío.";
                return false;
            }

            ProductoNegocio negocioProductos = new ProductoNegocio();

            List<Producto> productos = negocioProductos.listarProductos();

            foreach (ItemCarrito item in carrito)
            {
                if (item == null || item.Producto == null || item.Producto.IdProducto <= 0 || item.Cantidad <= 0)
                {
                    mensaje = "El carrito contiene productos inválidos.";
                    return false;
                }

                Producto productoEncontrado = null;

                foreach (Producto producto in productos)
                {
                    if (producto.IdProducto == item.Producto.IdProducto)
                    {
                        productoEncontrado = producto;
                        break;
                    }
                }

                if (productoEncontrado == null)
                {
                    mensaje = "Uno de los productos del carrito ya no está disponible.";
                    return false;
                }

                if (item.Cantidad > productoEncontrado.Stock)
                {
                    mensaje = "No hay stock suficiente para " + productoEncontrado.Nombre + ". Cantidad solicitada: " + item.Cantidad + ". Stock disponible: " + productoEncontrado.Stock;
                    return false;
                }

                DetalleVenta detalle = new DetalleVenta();

                detalle.Producto = productoEncontrado;
                detalle.Cantidad = item.Cantidad;
                detalle.PrecioUnitario = productoEncontrado.Precio;

                detalles.Add(detalle);
            }

            return true;
        }

        private void actualizarResumenCompra()
        {
            Usuario usuario = Session["usuario"] as Usuario;

            if (usuario == null) return;

            List<ItemCarrito> carrito = obtenerItemsCarrito(usuario);

            if (!prepararDetallesCarrito(carrito, out List<DetalleVenta> detalles, out string mensaje))
            {
                lblMensaje.Text = mensaje;
                btnConfirmarCompra.Enabled = false;
                return;
            }

            decimal subtotal = 0;

            foreach (DetalleVenta detalle in detalles)
            {
                subtotal += detalle.Subtotal;
            }

            lblSubtotal.Text = subtotal.ToString("N2");

            if (!int.TryParse(ddlFormaEntrega.SelectedValue, out int idFormaEntrega))
            {
                lblCostoEntrega.Text = "A definir";
                lblTotal.Text = "—";
                return;
            }

            FormaEntregaNegocio negocio = new FormaEntregaNegocio();
            FormaEntrega forma = negocio.buscarPorId(idFormaEntrega);

            if (forma == null || !forma.Estado)
            {
                lblCostoEntrega.Text = "No disponible";
                lblTotal.Text = "—";
                return;
            }

            decimal costoEntrega = forma.CostoEntrega;
            decimal total = subtotal + costoEntrega;

            lblCostoEntrega.Text = costoEntrega == 0 ? "Gratis" : "$" + costoEntrega.ToString("N2");

            lblTotal.Text = "$" + total.ToString("N2");
        }

    }
}