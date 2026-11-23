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

        public Categoria buscarPorId(int idCategoria)
        {
            if (idCategoria <= 0)
            {
                throw new ArgumentException("El identificador de la categoría no es válido.");
            }

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdCategoria, Nombre, Estado FROM CATEGORIA WHERE IdCategoria = @IdCategoria");
                datos.setearParametro("@IdCategoria", idCategoria);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Categoria categoria = new Categoria();

                    categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                    categoria.Nombre = (string)datos.Lector["Nombre"];
                    categoria.Estado = (bool)datos.Lector["Estado"];

                    return categoria;

                }

                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool existeNombreEnOtraCategoria(string nombre, int idCategoria)
        {
            List<Categoria> categorias = ListarCategorias();

            foreach (Categoria categoria in categorias)
            {
                if (categoria.IdCategoria != idCategoria && categoria.Nombre.Trim().ToUpper() == nombre.Trim().ToUpper())
                {
                    return true;
                }
            }

            return false;
        }

        public bool modificar(Categoria categoria)
        {
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }

            if (categoria.IdCategoria <= 0)
            {
                throw new ArgumentException("El identificador no es válido.");
            }

            if (buscarPorId(categoria.IdCategoria) == null)
            {
                throw new ArgumentException("La categoría no existe.");
            }

            if (string.IsNullOrWhiteSpace(categoria.Nombre))
            {
                throw new ArgumentException("El nombre es obligatorio.");
            }

            string nombre = categoria.Nombre.Trim();

            if (nombre.Length > 50)
            {
                throw new ArgumentException("El nombre no puede superar los 50 caracteres.");
            }

            if (existeNombreEnOtraCategoria(nombre, categoria.IdCategoria))
            {
                return false;
            }

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE CATEGORIA SET Nombre = @Nombre WHERE IdCategoria = @IdCategoria");

                datos.setearParametro("@Nombre", nombre);
                datos.setearParametro("@IdCategoria", categoria.IdCategoria);

                datos.ejecutarAccion();

                return true;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


    }
}
