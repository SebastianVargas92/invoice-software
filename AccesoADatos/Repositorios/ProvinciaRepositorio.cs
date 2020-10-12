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
    public class ProvinciaRepositorio : RepositorioMaestro, IProvinciaRepositorio
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public ProvinciaRepositorio()
        {
            selectAll = "select * from PROVINCIA";
            insert = "insert into PROVINCIA values(@provincia)";
            update = "update PROVINCIA set provincia=@provincia where idProvincia=@idProvincia";
            delete = "delete from PROVINCIA where idProvincia=@idProvincia";
        }
       
        public int Add(Provincia entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@provincia", entity.Nombre));

            return ExecuteNonQuery(insert);
        }

        public int Edit(Provincia entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idProvincia", entity.Id));
            parametros.Add(new SqlParameter("@provincia", entity.Nombre));

            return ExecuteNonQuery(update);
        }

        public IEnumerable<Provincia> GetAll()
        {
            {
                var tableResult = ExecuteReader(selectAll);
                var listaProvincias = new List<Provincia>();
                foreach (DataRow item in tableResult.Rows)
                {
                    listaProvincias.Add(new Provincia
                    {
                        Id = Convert.ToInt32(item[0]),
                        Nombre = item[1].ToString()

                    });
                }
                return listaProvincias;
            }
        }

        public int Remove(int id)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idProvincia", id));
            return ExecuteNonQuery(delete);
        }
    }
}
