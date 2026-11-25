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
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["usuario"] == null)
                {
                    Session.Add("Error", "Debes loguearte!");
                    Response.Redirect("Error.aspx", false);
                }

                else
                {             
                    if (!IsPostBack)
                    {
                        cargarTarjetas();
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        void cargarTarjetas()
        {
            int usuario = ((Usuario)Session["usuario"]).IdUsuario;
            TarjetaNegocio negocio = new TarjetaNegocio();
            dgvTarjetas.DataSource = negocio.listarTarjetas(usuario);
            dgvTarjetas.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idTarjeta = int.Parse(btn.CommandArgument);

            TarjetaNegocio negocio = new TarjetaNegocio();

            negocio.BajaLogicaTarjeta(idTarjeta);

            if (!(negocio.isExist(idTarjeta))){

                lblRespuesta.Text = "Se elimino correctamente la tarjeta!";
                cargarTarjetas();
            }
            else
            {
                lblRespuesta.Text = "No se pudo eliminar la tarjeta";
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevaTarjeta.aspx", false);
        }
    }
}