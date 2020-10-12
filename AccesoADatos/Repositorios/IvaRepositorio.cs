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
   public class IvaRepositorio : RepositorioMaestro, IIvaRepositorio
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public IvaRepositorio()
        {
            selectAll = "select * from IVA";
            insert = "insert into IVA values(@valor)";
            update = "update IVA set valor=@valor where idIva=@idIva";
            delete = "delete from IVA where idgrupo=@idGrupo";
        }
        
        public int Add(Iva entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@valor", entity.valor));

            return ExecuteNonQuery(insert);
        }

        public int Edit(Iva entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idIva", entity.id));
            parametros.Add(new SqlParameter("@valor", entity.valor));

            return ExecuteNonQuery(update);
        }

        public IEnumerable<Iva> GetAll()
        {
            {
                var tableResult = ExecuteReader(selectAll);
                var listaIvas = new List<Iva>();
                foreach (DataRow item in tableResult.Rows)
                {
                    listaIvas.Add(new Iva
                    {
                        id = Convert.ToInt32(item[0]),
                        valor = Convert.ToDouble(item[1])

                    });
                }
                return listaIvas;
            }
        }

        public int Remove(int id)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idIva", id));
            return ExecuteNonQuery(delete);
        }
    }
}