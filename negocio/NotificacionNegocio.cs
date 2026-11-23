using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using dominio;
using System.Net;

namespace negocio
{
    public class NotificacionNegocio
    {
        private SmtpClient servidor;

        public NotificacionNegocio()
        {
            servidor = new SmtpClient();

            //Cambiar credenciales

            servidor.Credentials = new NetworkCredential("USUARIO_MAILTRAP", "CONTRASENA_MAILTRAP");

            servidor.EnableSsl = true;
            servidor.Port = 2525;
            servidor.Host = "sandbox.smtp.mailtrap.io";
        }

        public void enviarCorreoConfirmacion(Venta venta)
        {
            MailMessage correo = crearCorreoConfirmacion(venta, "notificaciones@ejemplo.com");

            servidor.Send(correo);
        }



        public MailMessage crearCorreoConfirmacion(Venta venta, string remitente)
        {
            if (venta == null || venta.Cliente == null || string.IsNullOrWhiteSpace(venta.Cliente.Email))
            {
                throw new ArgumentException("La venta no tiene un correo de cliente válido.");
            }

            MailMessage correo = new MailMessage();

            correo.From = new MailAddress(remitente);
            correo.To.Add(venta.Cliente.Email);

            correo.Subject = "Confirmación de pedido N° " + venta.IdVenta;

            correo.Body =
                "¡Gracias por tu compra!\n\n" +
                "Hola " + venta.Cliente.Nombre + ",\n\n" +
                "Tu pedido fue registrado correctamente.\n\n" +
                "Número de pedido: " + venta.IdVenta + "\n" +
                "Fecha: " + venta.Fecha.ToString("dd/MM/yyyy HH:mm") + "\n" +
                "Total: $" + venta.VentaTotal.ToString("N2") + "\n" +
                "Forma de pago: " + venta.FormaPago.Nombre + "\n" +
                "Forma de entrega: " + venta.FormaEntrega.Nombre + "\n" +
                "Estado: " + venta.EstadoVenta.Nombre + "\n\n" +
                "Te notificaremos cuando haya novedades sobre tu pedido.";

            correo.IsBodyHtml = false;

            return correo;
        }

        public void enviarCorreoVerificacion(string email, string nombre, string link)
        {
            MailMessage correo = new MailMessage();

            correo.From = new MailAddress("notificaciones@ejemplo.com");
            correo.To.Add(email);
            correo.Subject = "Activá tu cuenta";

            correo.IsBodyHtml = true;
            correo.Body =
                "<h2>¡Hola " + nombre + "!</h2>" +
                "<p>Gracias por registrarte. Para activar tu cuenta hacé clic en el siguiente enlace:</p>" +
                "<p><a href='" + link + "'>Activar mi cuenta</a></p>";

            servidor.Send(correo);
        }
    }
}
