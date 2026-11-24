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
    public partial class HistorialPedidos : System.Web.UI.Page
    {
        List<Venta> listaVenta = new List<Venta>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Inicio.aspx", false);
                return;
            }

            Venta venta = new Venta();
            VentaNegocio negocio = new VentaNegocio();


            int usuario = ((Usuario)Session["usuario"]).IdUsuario;

            listaVenta = negocio.listarVentasPorCliente(usuario);
            dgvHistorial.DataSource = listaVenta;
            dgvHistorial.DataBind();
        }
 

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int IdVenta = Convert.ToInt32(btn.CommandArgument);

            Response.Redirect("DetalleCompra.aspx?IdVenta=" + IdVenta);

        }
    }
}