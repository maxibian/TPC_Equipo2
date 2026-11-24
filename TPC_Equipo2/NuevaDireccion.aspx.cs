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
    public partial class NuevaDireccion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Inicio.aspx", false);
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCalle.Text) ||
                string.IsNullOrWhiteSpace(txtNumero.Text) ||
                string.IsNullOrWhiteSpace(txtLocalidad.Text) ||
                string.IsNullOrWhiteSpace(txtProvincia.Text) ||
                string.IsNullOrWhiteSpace(txtCodigoPostal.Text))
            {
                lblRespuesta.Text = "Todos los campos son obligatorios. Excepto Observaciones.";
                return;
            }

            if (!int.TryParse(txtNumero.Text, out int numero) || numero <= 0)
            {
                lblRespuesta.Text = "Ingresa un numero de domicilio válido.";
                return;
            }

            Direccion direccion = new Direccion();
            DireccionNegocio negocio = new DireccionNegocio();
            int usuario = ((Usuario)Session["usuario"]).IdUsuario;

            int idCliente = negocio.isExistCliente(usuario);
            if (idCliente > 0)
            {
                direccion.IdCliente = idCliente;
                direccion.Calle = txtCalle.Text;
                direccion.Numero = int.Parse(txtNumero.Text);
                direccion.Localidad = txtLocalidad.Text;
                direccion.Provincia = txtProvincia.Text;
                direccion.CodigoPostal = txtCodigoPostal.Text;
                direccion.Observacion = txtObservacion.Text;


                int idDireccion = negocio.agregarDireccion(direccion);

                if (idDireccion > 0)
                {
                    lblRespuesta.Text = "Se agrego direccion con exito!";
                }
                else
                {
                    lblRespuesta.Text = "No se pudo agregar el registro.";
                }

            }

        }
    }
}