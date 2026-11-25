using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
using System.Data.SqlClient;
using System.Globalization;

namespace TPC_Equipo2
{
    public partial class NuevaTarjeta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Inicio.aspx", false);
                return;
            }

            if (!IsPostBack)
            {
                TarjetaNegocio negocio = new TarjetaNegocio();

                ddlTipo.DataSource = negocio.listarTiposTarjeta();
                ddlTipo.DataValueField = "IdTipoTarjeta";
                ddlTipo.DataTextField = "NombreTipoTarjeta";
                ddlTipo.DataBind();

                ddlMarca.DataSource = negocio.listarMarcasTarjeta();
                ddlMarca.DataValueField = "IdMarcaTarjeta";
                ddlMarca.DataTextField = "Nombre";
                ddlMarca.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Inicio.aspx", false);
                return;
            }

            if (!Page.IsValid)
                return;

            
            if (string.IsNullOrWhiteSpace(txtNumero.Text) ||
                string.IsNullOrWhiteSpace(txtTitular.Text) ||
                string.IsNullOrWhiteSpace(txtVencimiento.Text))
            {
                lblRespuesta.Text = "Todos los campos son obligatorios.";
                return;
            }

            
            DateTime mesVencimiento;
            if (!DateTime.TryParseExact(txtVencimiento.Text, "yyyy-MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out mesVencimiento))
            {
                lblRespuesta.Text = "El vencimiento no es válido. Usá el formato año-mes, por ejemplo 2027-05.";
                return;
            }

            
            DateTime vencimiento = new DateTime(mesVencimiento.Year, mesVencimiento.Month,
                DateTime.DaysInMonth(mesVencimiento.Year, mesVencimiento.Month));

            if (vencimiento < DateTime.Today)
            {
                lblRespuesta.Text = "La tarjeta está vencida.";
                return;
            }

            
            int idUsuario = ((Usuario)Session["usuario"]).IdUsuario;
            int idCliente = new CarritoNegocio().obtenerIdCliente(idUsuario);
            if (idCliente <= 0)
            {
                lblRespuesta.Text = "No se encontró un cliente asociado a tu usuario.";
                return;
            }

            
            Tarjeta tarjeta = new Tarjeta();
            tarjeta.IdCliente = idCliente;
            tarjeta.NumeroTarjeta = txtNumero.Text.Trim();
            tarjeta.NombreYApellidoTitular = txtTitular.Text.Trim();
            tarjeta.FechaVencimiento = vencimiento;
            tarjeta.TipoTarjeta = new TipoTarjeta();
            tarjeta.TipoTarjeta.IdTipoTarjeta = int.Parse(ddlTipo.SelectedValue);
            tarjeta.MarcaTarjeta = new MarcaTarjeta();
            tarjeta.MarcaTarjeta.IdMarcaTarjeta = int.Parse(ddlMarca.SelectedValue);

            try
            {
                new TarjetaNegocio().agregarTarjeta(tarjeta);

                lblRespuesta.CssClass = "text-success d-block mb-3";
                lblRespuesta.Text = "¡Tarjeta agregada con éxito!";
                btnGuardar.Enabled = false;
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                lblRespuesta.Text = "Esa tarjeta ya está registrada.";
            }
            catch (Exception)
            {
                lblRespuesta.Text = "No se pudo guardar la tarjeta.";
            }
        }
    }
}