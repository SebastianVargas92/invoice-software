using System;
using System.Collections.Generic;
using AccesoADatos.Contratos;
using AccesoADatos.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace AccesoADatos.Repositorios
{
    public class FormaDePagoRepositorio: RepositorioMaestro, IFormaDePagoRepositorio
    {

        private readonly string selectAll;
        private readonly string insert;
        private readonly string update;
        private readonly string delete;

        public FormaDePagoRepositorio()
        {
            selectAll = "select * from FORMA_DE_PAGO";
            insert = "insert into FORMA_DE_PAGO values(@tipo)";
            update = "update FORMA_DE_PAGO set tipo=@tipo where id=@id";
            delete = "delete from FORMA_DE_PAGO where id=@id";
        }

        public int Add(FormaDePago entity)
        {
            parametros = new List<SqlParameter>
            {
                new SqlParameter("@tipo", entity.Tipo)
            };

            return ExecuteNonQuery(insert);
        }

        public int Edit(FormaDePago entity)
        {
            parametros = new List<SqlParameter>
            {
                new SqlParameter("@id", entity.Id),
                new SqlParameter("@tipo", entity.Tipo)
            };

            return ExecuteNonQuery(update);
        }

        public IEnumerable<FormaDePago> GetAll()
        {
            {
                var tableResult = ExecuteReader(selectAll);
                var listaMarcas = new List<FormaDePago>();
                foreach (DataRow item in tableResult.Rows)
                {
                    listaMarcas.Add(new FormaDePago
                    {
                        Id = Convert.ToInt32(item[0]),
                        Tipo = item[1].ToString()

                    });
                }
                return listaMarcas;
            }
        }

        public int Remove(int id)
        {
            parametros = new List<SqlParameter>
            {
                new SqlParameter("@id", id)
            };
            return ExecuteNonQuery(delete);
        }
    }
}

