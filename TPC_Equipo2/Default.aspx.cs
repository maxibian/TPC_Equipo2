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
    public partial class _Default : Page
    {

        public List<Producto> listaProducto {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();

            listaProducto = negocio.listarProductos();

            foreach (dominio.Producto producto in listaProducto)
                if (producto.Imagen == null || string.IsNullOrWhiteSpace(producto.Imagen.ImagenUrl))
                    producto.Imagen = new Imagen() { ImagenUrl = "https://www.svgrepo.com/show/508699/landscape-placeholder.svg" };

            repRepeater.DataSource = listaProducto;
            repRepeater.DataBind();

        }
        protected void btnProducto_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;

            int idProducto = Convert.ToInt32(btn.CommandArgument);

            Response.Redirect("ProductoDetalle.aspx?id=" + idProducto);
        }

        protected void btnAgregarAlCarrito_Click(object sender, EventArgs e)
        {
            LinkButton productoSeleccionado = (LinkButton)sender;
            int id = int.Parse(productoSeleccionado.CommandArgument);

            ItemCarritoNegocio itemNegocio = new ItemCarritoNegocio();
            try
            {
                if (Session["cliente"] != null)
                {
                    // El cliente está logueado, se puede agregar al carrito
                    Cliente cliente = (Cliente)Session["cliente"];
                    CarritoNegocio carritoNegocio = new CarritoNegocio();
                    dominio.Carrito carrito = carritoNegocio.obtenerOCrearCarrito(cliente.IdCliente);

                    Producto producto = new ProductoNegocio().obtenerProducto(id);
                    itemNegocio.agregarItemCarrito(carrito.IdCarrito, id, 1, producto.Precio);
                }
                else
                {
                    // El cliente no está logueado, se puede agregar al carrito de sesión
                    List<ItemCarrito> lista = (List<ItemCarrito>)Session["Carrito"];
                    if (lista == null)
                        lista = new List<ItemCarrito>();

                    itemNegocio.agregarItemSession(lista, id, 1);
                    Session["Carrito"] = lista;
                }
            }
            catch (Exception ex)
            {

                lblMensaje.Text = ex.Message;
            }
            
        }
    }
}