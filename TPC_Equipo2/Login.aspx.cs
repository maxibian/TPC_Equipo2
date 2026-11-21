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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();

            usuario.NombreUsuario = txtEmail.Text;
            usuario.Contrasena = txtPassword.Text;

            if (negocio.Loguear(usuario))
            {
                Session.Add("usuario", usuario);
                Response.Redirect("Inicio.aspx", false);

            }
            else
            {
                Session.Add("error", "Usuario o contraseña incorrecta");
                Response.Redirect("Error.aspx", false);
            }

        }
    }
}