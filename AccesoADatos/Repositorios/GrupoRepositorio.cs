using AccesoADatos.Contratos;
using AccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AccesoADatos.Repositorios
{
    public class GrupoRepositorio : RepositorioMaestro, IGrupoRepositorio

    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public GrupoRepositorio()
        {
            selectAll = "select * from GRUPOS";
            insert = "insert into GRUPOS values(@nombre)";
            update = "update GRUPOS set nombre=@nombre where idgrupo=@idGrupo";
            delete = "delete from GRUPOS where idgrupo=@idGrupo";
        }
       
        public int Add(Grupo entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", entity.grupo));

            return ExecuteNonQuery(insert);
        }

        public int Edit(Grupo entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idGrupo", entity.id));
            parametros.Add(new SqlParameter("@nombre", entity.grupo));

            return ExecuteNonQuery(update);
        }

        public IEnumerable<Grupo> GetAll()
        {
            {
                var tableResult = ExecuteReader(selectAll);
                var listaGrupos = new List<Grupo>();
                foreach (DataRow item in tableResult.Rows)
                {
                    listaGrupos.Add(new Grupo
                    {
                        id = Convert.ToInt32(item[0]),
                        grupo = item[1].ToString()

                    });
                }
                return listaGrupos;
            }
        }

        public int Remove(int id)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idGrupo", id));
            return ExecuteNonQuery(delete);
        }
    }
}