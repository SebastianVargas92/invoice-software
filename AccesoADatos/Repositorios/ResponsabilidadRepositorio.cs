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
    public class ResponsabilidadRepositorio : RepositorioMaestro, IResponsabilidadRepositorio
    {

        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public ResponsabilidadRepositorio()
        {
            selectAll = "select * from RESPONSABILIDAD";
            insert = "insert into RESPONSABILIDAD values(@nombre)";
            update = "update RESPONSABILIDAD set nombre=@nombre where idResp=@idResp";
            delete = "delete from RESPONSABILIDAD where idResp=@idResp";
        }
       
        public int Add(Responsabilidad entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", entity.nombre));

            return ExecuteNonQuery(insert);
        }

        public int Edit(Responsabilidad entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idResp", entity.id));
            parametros.Add(new SqlParameter("@nombre", entity.nombre));

            return ExecuteNonQuery(update);
        }

        public IEnumerable<Responsabilidad> GetAll()
        {
            {
                var tableResult = ExecuteReader(selectAll);
                var listaResp = new List<Responsabilidad>();
                foreach (DataRow item in tableResult.Rows)
                {
                    listaResp.Add(new Responsabilidad
                    {
                        id = Convert.ToInt32(item[0]),
                        nombre = item[1].ToString()

                    });
                }
                return listaResp;
            }
        }

        public int Remove(int id)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idResp", id));
            return ExecuteNonQuery(delete);
        }
    }
}