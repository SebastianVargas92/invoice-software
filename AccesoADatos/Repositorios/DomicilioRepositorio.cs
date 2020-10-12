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
    public class DomicilioRepositorio : RepositorioMaestro, IDomicilioRepositorio
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public DomicilioRepositorio()
        {
            selectAll = "select * from DOMICILIO";
            insert = "insert into DOMICILIO values(@calle,@idLocalidad)";
            update = "update DOMICILIO set calle=@calle, idLocalidad=@idLocalidad where idDomicilio=@idDomicilio";
            delete = "delete from DOMICILIO where idDomicilio=@idDomicilio";
        }

        public int Add(Domicilio entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@calle", entity.Calle));
            parametros.Add(new SqlParameter("@idLocalidad", entity.IdLocalidad));

            return ExecuteNonQuery(insert);
        }

        public int Edit(Domicilio entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idDomicilio", entity.Id));
            parametros.Add(new SqlParameter("@calle", entity.Calle));
            parametros.Add(new SqlParameter("@idLocalidad", entity.IdLocalidad));

            return ExecuteNonQuery(update);
        }

        public IEnumerable<Domicilio> GetAll()
        {
            {
                var tableResult = ExecuteReader(selectAll);
                var listaDomicilios = new List<Domicilio>();
                foreach (DataRow item in tableResult.Rows)
                {
                    listaDomicilios.Add(new Domicilio
                    {
                        Id = Convert.ToInt32(item[0]),
                        Calle = item[1].ToString(),
                        IdLocalidad = Convert.ToInt32(item[2])

                    });
                }
                return listaDomicilios;
            }
        }

        public int Remove(int id)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idDomicilio", id));
            return ExecuteNonQuery(delete);
        }
    }
}
