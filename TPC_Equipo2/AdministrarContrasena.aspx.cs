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
    public partial class AdministrarContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("Error", "No esta logueado, tiene que loguearse para cambiar la contraseña.");
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();

            usuario = (Usuario)Session["usuario"];
            string contrasena = txtPassword.Text;

            if (!(string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtPasswordNuevo.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmacionPassword.Text)))
            {

                if (usuario.Contrasena == contrasena && txtPasswordNuevo.Text == txtConfirmacionPassword.Text)
                {
                    usuario.Contrasena = txtPasswordNuevo.Text;
                    negocio.modificarUsuarioContrasena(usuario);
                    lblRespuesta.Text = "Contraseña modificada correctamente!";
                }
                else
                {
                    if (usuario.Contrasena != contrasena)
                    {
                        lblRespuesta.Text = "La contraseña ingresada en la verificación de identidad es incorrecta!";
                        return;
                    }

                    if (txtPasswordNuevo.Text != txtConfirmacionPassword.Text)
                    {
                        lblRespuesta.Text = "La contraseña nueva no coincide con la contraseña de confirmación!";
                    }
                }
            }
            else
            {
                lblRespuesta.Text = "Todos los campos son obligatorios de llenar!";
            }
        }
    }
}