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
    public partial class AdministrarUsuarios : System.Web.UI.Page
    {
        List<Usuario> listaUsuarios = new List<Usuario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null && ((dominio.Usuario)Session["usuario"]).Rol.IdRol == 1))
            {
                Session.Add("error", "No tenes permisos para entrar a esta pantalla. Necesitas ser Administrador.");
                Response.Redirect("Error.aspx", false);
            }
        }
        protected void btnAlta_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();

            string email = txtEmailUsuario.Text;

            listaUsuarios = negocio.listarUsuarios(email);

            if (listaUsuarios.Count == 0)
            {
                Usuario usuario = new Usuario();

                usuario.NombreUsuario = txtEmailUsuario.Text;
                usuario.Contrasena = txtPassword.Text;
                usuario.Estado = true;
                negocio.agregarAdministrador(usuario);

                if (negocio.isExist(email))
                {
                    lblRespuesta.Text = "USUARIO CREADO CON EXITO";
                }
                else
                {
                    lblRespuesta.Text = "NO SE PUDO CREAR EL USUARIO";
                }

            }

            else
            {
                if (listaUsuarios[0].Estado == false)
                {
                    negocio.altaAdministrador(listaUsuarios[0].IdUsuario);
                    lblRespuesta.Text = "USUARIO AGREGADO";
                }

                else
                {
                    lblRespuesta.Text = "EL USUARIO YA EXISTE";
                }
            }

        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();

            string email = txtEmailUsuario.Text;

            listaUsuarios = negocio.listarUsuarios(email);

            if (listaUsuarios.Count != 0)
            {
                int id = listaUsuarios[0].IdUsuario;

                negocio.bajaAdministrador(id);

                lblRespuesta.Text = "USUARIO ELIMINADO";
            }
            else
            {
                lblRespuesta.Text = "EL USUARIO NO EXISTE";
            }
        }
    }
}