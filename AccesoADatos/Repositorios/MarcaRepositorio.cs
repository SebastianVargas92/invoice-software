using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AccesoADatos.Contratos;
using AccesoADatos.Entidades;

namespace AccesoADatos.Repositorios
{
    public class MarcaRepositorio : RepositorioMaestro, IMarcaRepositorio
    {
     
        private readonly string selectAll;
        private readonly string insert;
        private readonly string update;
        private readonly string delete;

        public MarcaRepositorio()
        {
            selectAll = "select * from MARCAS";
            insert = "insert into MARCAS values(@nombre)";
            update = "update MARCAS set nombre=@nombre where idMarca=@idMarca";
            delete = "delete from MARCAS where idMarca=@idMarca";
        }
       
        public int Add(Marca entity)
        {
            parametros = new List<SqlParameter>
            {
                new SqlParameter("@nombre", entity.marca)
            };

            return ExecuteNonQuery(insert);
        }

        public int Edit(Marca entity)
        {
            parametros = new List<SqlParameter>
            {
                new SqlParameter("@idMarca", entity.id),
                new SqlParameter("@nombre", entity.marca)
            };

            return ExecuteNonQuery(update);
        }

        public IEnumerable<Marca> GetAll()
        {
            {
                var tableResult = ExecuteReader(selectAll);
                var listaMarcas = new List<Marca>();
                foreach (DataRow item in tableResult.Rows)
                {
                    listaMarcas.Add(new Marca
                    {
                        id = Convert.ToInt32(item[0]),
                        marca = item[1].ToString()

                    });
                }
                return listaMarcas;
            }
        }

        public int Remove(int id)
        {
            parametros = new List<SqlParameter>
            {
                new SqlParameter("@idMarca", id)
            };
            return ExecuteNonQuery(delete);
        }
    }
}
