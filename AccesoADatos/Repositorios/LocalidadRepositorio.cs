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
    public class LocalidadRepositorio : RepositorioMaestro, ILocalidadRepositorio
    {
        private readonly string selectAll;
        private readonly string insert;
        private readonly string update;
        private readonly string delete;

        public LocalidadRepositorio()
        {
            selectAll = "select * from LOCALIDAD";
            insert = "insert into LOCALIDAD values(@localidad,@idProvincia)";
            update = "update LOCALIDAD set localidad=@localidad, idProvincia=@idProvincia where id=@id";
            delete = "delete from LOCALIDAD where id=@id";
        }
       
        public int Add(Localidad entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@localidad", entity.Nombre));
            parametros.Add(new SqlParameter("@idProvincia", entity.IdProv));

            return ExecuteNonQuery(insert);
        }

        public int Edit(Localidad entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idLocalidad", entity.Id));
            parametros.Add(new SqlParameter("@localidad", entity.Nombre));
            parametros.Add(new SqlParameter("@idProvincia", entity.IdProv));

            return ExecuteNonQuery(update);
        }

        public IEnumerable<Localidad> GetAll()
        {
            {
                var tableResult = ExecuteReader(selectAll);
                var listaLocalidades = new List<Localidad>();
                foreach (DataRow item in tableResult.Rows)
                {

                    listaLocalidades.Add(new Localidad
                    {
                        Id = Convert.ToInt32(item[0]),
                        Nombre = item[1].ToString(),
                        IdProv = Convert.ToInt32(item[2]),
                      

                    });
                }
                return listaLocalidades;
            }
        }

        public int Remove(int id)
        {
            parametros = new List<SqlParameter>
            {
                new SqlParameter("@idLocalidad", id)
            };
            return ExecuteNonQuery(delete);
        }
    }
}
