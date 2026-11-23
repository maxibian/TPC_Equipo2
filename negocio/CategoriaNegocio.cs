using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        AccesoDatos datos = new AccesoDatos();

        public List<Categoria> ListarCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            try
            {
                datos.setearConsulta("SELECT IdCategoria, Nombre, Estado FROM CATEGORIA");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Estado = (bool)datos.Lector["Estado"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally{

                datos.cerrarConexion();
            }
        }

        public bool agregar(Categoria nueva)
        {
            if (nueva == null)
            {
                throw new ArgumentNullException(nameof(nueva));
            }

            if (string.IsNullOrWhiteSpace(nueva.Nombre))
            {
                throw new ArgumentException("El nombre es obligatorio.");
            }

            string nombre = nueva.Nombre.Trim();

            if (nombre.Length > 50)
            {
                throw new ArgumentException(
                    "El nombre no puede superar los 50 caracteres.");
            }

            if (existeNombre(nombre))
            {
                return false;
            }

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO CATEGORIA (Nombre) VALUES (@Nombre)");
                datos.setearParametro("@Nombre", nombre);
                datos.ejecutarAccion();

                return true;
            }
            finally
            {
                datos.cerrarConexion();
            }        
        }

        public bool existeNombre(string nombre)
        {
            List<Categoria> categorias = ListarCategorias();

            foreach (Categoria categoria in categorias)
            {
                if (categoria.Nombre.Trim().ToUpper() == nombre.Trim().ToUpper())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
