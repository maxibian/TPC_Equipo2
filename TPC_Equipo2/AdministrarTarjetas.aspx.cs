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
    public partial class AdministrarTarjetas : System.Web.UI.Page
    {
        List<Tarjeta> listaTarjetas = new List<Tarjeta>();
        protected void Page_Load(object sender, EventArgs e)
        {
            TarjetaNegocio negocio = new TarjetaNegocio();
            try
            {
                if (Session["usuario"] == null)
                {
                    Session.Add("Error", "Debes loguearte!");
                    Response.Redirect("Error.aspx", false);
                }

                else
                {
                
                int usuario = ((Usuario)Session["usuario"]).IdUsuario;
                listaTarjetas = negocio.listarTarjetas(usuario);      
                rptTarjetas.DataSource = listaTarjetas;
                rptTarjetas.DataBind();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}