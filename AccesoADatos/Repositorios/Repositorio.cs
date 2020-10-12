using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace AccesoADatos.Repositorios
{
    public abstract class Repositorio
    {
        private readonly string cadenaConexion;
        public Repositorio()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["Practica"].ToString();
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(cadenaConexion);
        }


    }
}
