using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace negocio
{
    public class AcessoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AcessoDatos(){
            conexion = new SqlConnection("server=.\\SQLEXPRESS; Ecommerce_DB; integrated security=true");
            comando = new SqlCommand();
        }
        public void setearConsulta(string consulta) 
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();   
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}