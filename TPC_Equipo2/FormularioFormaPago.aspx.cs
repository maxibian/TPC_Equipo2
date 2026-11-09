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
    public partial class FormularioFormaPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];

                bool valido = int.TryParse(id, out int numero);

                if (!valido || numero <= 0)
                {
                    lblMensaje.Text = "ID inválido";
                    return;
                }

                FormaPagoNegocio negocio = new FormaPagoNegocio();
                FormaPago forma = negocio.buscarPorId(numero);

                if (forma == null)
                {
                    lblMensaje.Text = "No se encontró la forma de pago.";
                    btnGuardar.Enabled = false;
                    btnCambiarEstado.Enabled = false;
                    return;
                }

                txtNombreFormaPago.Text = forma.Nombre;
                chkEstado.Checked = forma.Estado;

                if (forma.Estado)
                {
                    btnCambiarEstado.Text = "Desactivar";
                }
                else
                {
                    btnCambiarEstado.Text = "Activar";
                }

            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            bool valido = int.TryParse(id, out int numero);

            if (!valido || numero <= 0)
            {
                lblMensaje.Text = "ID inválido";
                return;
            }

            FormaPago forma = new FormaPago();

            forma.IdFormaPago = numero;
            forma.Nombre = txtNombreFormaPago.Text;

            FormaPagoNegocio negocio = new FormaPagoNegocio();

            try
            {
                bool modificado = negocio.modificar(forma);

                if (modificado)
                {
                    lblMensaje.Text = "Modificado correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Ya existe otra forma de pago con ese nombre.";
                }
            }
            catch (ArgumentException ex)
            {
                lblMensaje.Text = ex.Message;
            }
            catch (Exception)
            {
                lblMensaje.Text = "Ocurrió un error al modificar la forma de pago.";
            }
    
        }

        protected void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            bool valido = int.TryParse(id, out int numero);

            if (!valido || numero <= 0)
            {
                lblMensaje.Text = "ID inválido";
                return;
            }

            try
            {
                FormaPagoNegocio negocio = new FormaPagoNegocio();
                FormaPago forma = negocio.buscarPorId(numero);

                if (forma == null)
                {
                    lblMensaje.Text = "No se encontró la forma de pago.";
                    return;
                }

                bool nuevoEstado = !forma.Estado;

                negocio.cambiarEstado(forma.IdFormaPago, nuevoEstado);

                chkEstado.Checked = nuevoEstado;

                if (nuevoEstado)
                {
                    lblMensaje.Text = "Forma de pago activada correctamente.";
                    btnCambiarEstado.Text = "Desactivar";

                }
                else
                {
                    lblMensaje.Text = "Forma de pago desactivada correctamente.";
                    btnCambiarEstado.Text = "Activar";

                }
            }
            catch (Exception)
            {
                lblMensaje.Text = "Ocurrió un error al cambiar el estado.";
            }

        }
    }
}