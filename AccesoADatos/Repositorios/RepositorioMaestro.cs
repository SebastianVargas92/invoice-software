using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AccesoADatos.Repositorios
{
    public abstract class RepositorioMaestro:Repositorio
    {
        protected List<SqlParameter> parametros;

        protected int ExecuteNonQuery(string transaccionSQL) 
        { 
            using(var conexion = GetConnection())
            {
                conexion.Open();
                using(var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = transaccionSQL;
                    comando.CommandType = CommandType.Text;
                    foreach(SqlParameter item in parametros)
                    {
                        comando.Parameters.Add(item);
                    }
                    int resultado = comando.ExecuteNonQuery();
                    parametros.Clear();
                    return resultado;
                }
            }
        }
        protected DataTable ExecuteReader(string transaccionSQL) 
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = transaccionSQL;
                    comando.CommandType = CommandType.Text;
                    SqlDataReader reader = comando.ExecuteReader();
                    using(var tabla = new DataTable())
                    {
                        tabla.Load(reader);
                        reader.Dispose();
                        return tabla;
                    }
                }
            }
        }
    }
}
