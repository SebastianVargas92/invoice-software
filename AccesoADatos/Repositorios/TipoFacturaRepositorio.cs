using AccesoADatos.Contratos;
using AccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace AccesoADatos.Repositorios
{
    public class TipoFacturaRepositorio: RepositorioMaestro, ITipoFacturaRepositorio
    {

        private readonly string selectAll;
        private readonly string insert;
        private readonly string update;
        private readonly string delete;

        public TipoFacturaRepositorio()
        {
            selectAll = "select * from TIPO_FACTURA";
            insert = "insert into TIPO_FACTURA values(@tipo)";
            update = "update TIPO_FACTURA set tipo=@tipo where id=@id";
            delete = "delete from TIPO_FACTURA where id=@id";
        }

        public int Add(TipoFactura entity)
        {
            parametros = new List<SqlParameter>
            {
                new SqlParameter("@tipo", entity.Tipo)
            };

            return ExecuteNonQuery(insert);
        }

        public int Edit(TipoFactura entity)
        {
            parametros = new List<SqlParameter>
            {
                new SqlParameter("@id", entity.Id),
                new SqlParameter("@tipo", entity.Tipo)
            };

            return ExecuteNonQuery(update);
        }

        public IEnumerable<TipoFactura> GetAll()
        {
            {
                var tableResult = ExecuteReader(selectAll);
                var listaMarcas = new List<TipoFactura>();
                foreach (DataRow item in tableResult.Rows)
                {
                    listaMarcas.Add(new TipoFactura
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
