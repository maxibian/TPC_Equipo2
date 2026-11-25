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
    public partial class DetalleCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] == null)
            {
                Response.Redirect("Inicio.aspx", false);
                return;
            }



            VentaNegocio negocio = new VentaNegocio();

            int idventa = Convert.ToInt32(Request.QueryString["IdVenta"]);

            List<DetalleVenta> lista = negocio.listarDetallesPorVenta(idventa);

            dgvDetalle.DataSource = lista;

            dgvDetalle.DataBind();

            hlComprobante.NavigateUrl = "~/Comprobante.aspx?id=" + idventa;
        }
    }
}