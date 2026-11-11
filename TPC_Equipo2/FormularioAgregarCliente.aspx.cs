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
    public partial class FormularioAgregarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            ClienteNegocio negocio = new ClienteNegocio();
            UsuarioNegocio unegocio = new UsuarioNegocio();
            List<Usuario> lista = new List<Usuario>();
            Usuario usuario = new Usuario();
            if (txtEmail.Text == txtEmailUsuario.Text)
            {
                string email = txtEmailUsuario.Text;

                lista = unegocio.listarUsuarios(email);

                if (lista.Count == 0)
                {

                    //crear usuario 
                    usuario.NombreUsuario = txtEmailUsuario.Text;
                    usuario.Contrasena = txtPasswordConfirmacion.Text;

                    // Recuperar el ID generado por SQL Server
                    int id = unegocio.agregarUsuario(usuario);

                    // Crear cliente
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellido.Text;
                    cliente.Email = txtEmail.Text;
                    cliente.Telefono = txtTelefono.Text;
                    cliente.Usuario = new Usuario();
                    cliente.Usuario.IdUsuario = id;

                    negocio.agregarCliente(cliente);

                    lblRespuesta.Text = "Te registraste con exito!";
                }
                else
                {
                    lblRespuesta.Text = "No te pudiste registrar!";
                }

            }

        }
    }
}