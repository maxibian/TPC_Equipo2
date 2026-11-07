using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class ClienteNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Cliente> listarClientes()
        {
            List<Cliente> listar = new List<Cliente>();
            datos.setearConsulta("SELECT IdCliente, Nombre, Apellido, Email, Telefono, IdUsuario, IdTarjeta FROM CLIENTE");
            datos.ejecutarLectura();
            try
            {
                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.IdUsuario = (int)datos.Lector["IdUsuario"];
                    aux.IdTarjeta = (int)datos.Lector["IdTarjeta"];
                    listar.Add(aux);
                }
                return listar;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public void modificarCliente(Cliente cliente)
        {
            try
            {
            datos.setearConsulta("UPDATE CLIENTE SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Telefono = @Telefono, IdUsuario = @IdUsuario, IdTarjeta = @IdTarjeta WHERE IdCliente = @IdCliente");
            datos.setearParametro("Nombre", cliente.Nombre);
            datos.setearParametro("Apellido", cliente.Apellido);
            datos.setearParametro("Email", cliente.Email);
            datos.setearParametro("Telefono", cliente.Telefono);
            datos.setearParametro("IdUsuario", cliente.IdUsuario);
            datos.setearParametro("IdTarjeta", cliente.IdTarjeta);
            datos.setearParametro("IdCliente", cliente.IdCliente);
            datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally{ datos.cerrarConexion();}
        }
    }
}
