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
    public class ProveedorRepositorio : RepositorioMaestro, IProveedorRepositorio

    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public ProveedorRepositorio()
        {
            selectAll = "select idProveedor, razonSocial, cuit,DOMICILIO.idDomicilio, DOMICILIO.calle,LOCALIDAD.id, LOCALIDAD.localidad,PROVINCIA.idProvincia, PROVINCIA.provincia,RESPONSABILIDAD.idResp, RESPONSABILIDAD.nombre, email,telefono,contacto,saldo " +
                "from PROVEEDOR " +
                "inner join RESPONSABILIDAD on PROVEEDOR.respIva = RESPONSABILIDAD.idResp " +
                "inner join DOMICILIO on PROVEEDOR.idDomicilio = DOMICILIO.idDomicilio " +
                "inner join LOCALIDAD on LOCALIDAD.id = DOMICILIO.idLocalidad " +
                "inner join PROVINCIA on PROVINCIA.idProvincia = LOCALIDAD.idProvincia";
            insert = "insert into PROVEEDOR values(@razonSocial,@cuit,@direccion,@respIva,@telefono,@email,@contacto,@saldo)";
            update = "update PROVEEDOR set razonSocial=@razonSocial,cuit=@cuit, idDomicilio=@direccion, respIva=@respIva,telefono=@telefono, email=@email, contacto=@contacto,saldo=@saldo where idProveedor=@idProveedor";
            delete = "delete from PROVEEDOR where idProveedor=@idProveedor";
            //idProveedor, razonSocial, cuit, DOMICILIO.idDomicilio, DOMICILIO.calle,LOCALIDAD.id, LOCALIDAD.localidad, PROVINCIA.idProvincia, PROVINCIA.provincia,RESPONSABILIDAD.idResp, RESPONSABILIDAD.nombre, email,telefono,contacto from PROVEEDOR inner join RESPONSABILIDAD on PROVEEDOR.respIva = RESPONSABILIDAD.idResp inner join DOMICILIO on PROVEEDOR.idDomicilio = DOMICILIO.idDomicilio inner join PROVINCIA on PROVEEDOR.provincia = PROVINCIA.idProvincia";
        }

        public int Add(Proveedor entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@razonSocial", entity.RazonSocial));
            parametros.Add(new SqlParameter("@cuit", entity.Cuit));
            parametros.Add(new SqlParameter("@direccion", entity.Domicilio.Id));
            parametros.Add(new SqlParameter("@respIva", entity.Responsabilidad.id));
            parametros.Add(new SqlParameter("@telefono", entity.Telefono));
            parametros.Add(new SqlParameter("@email", entity.Email));
            parametros.Add(new SqlParameter("@contacto", entity.Contacto));
            parametros.Add(new SqlParameter("@saldo", entity.Saldo));

            return ExecuteNonQuery(insert);
        }

        public int Edit(Proveedor entity)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idProveedor", entity.Id));
            parametros.Add(new SqlParameter("@razonSocial", entity.RazonSocial));
            parametros.Add(new SqlParameter("@cuit", entity.Cuit));
            parametros.Add(new SqlParameter("@direccion", entity.Domicilio.Id));
            parametros.Add(new SqlParameter("@respIva", entity.Responsabilidad.id));
            parametros.Add(new SqlParameter("@telefono", entity.Telefono));
            parametros.Add(new SqlParameter("@email", entity.Email));
            parametros.Add(new SqlParameter("@contacto", entity.Contacto));
            parametros.Add(new SqlParameter("@saldo", entity.Saldo));

            return ExecuteNonQuery(update);
        }

        public IEnumerable<Proveedor> GetAll()
        {
            {
                var tableResult = ExecuteReader(selectAll);
                var listaProveedores = new List<Proveedor>();
                foreach (DataRow item in tableResult.Rows)
                {

                    var respTemp = new Responsabilidad();
                    var domicilioTemp = new Domicilio();
                    var locaTemp = new Localidad();
                    var provTemp = new Provincia();
                    

                    domicilioTemp.Id = Convert.ToInt32(item[3]);
                    domicilioTemp.Calle = item[4].ToString();
                    domicilioTemp.IdLocalidad = Convert.ToInt32(item[5]);
                    locaTemp.Id = Convert.ToInt32(item[5]);
                    locaTemp.Nombre = item[6].ToString();
                    locaTemp.IdProv = Convert.ToInt32(item[7]);
                    provTemp.Id = Convert.ToInt32(item[7]);
                    provTemp.Nombre = item[8].ToString();

                    

                    respTemp.id = Convert.ToInt32(item[9]);
                    respTemp.nombre = item[10].ToString();


                    domicilioTemp.Localidad = locaTemp;
                    domicilioTemp.Localidad.Provincia = provTemp;

                    listaProveedores.Add(new Proveedor
                    {
                        Id = Convert.ToInt32(item[0]),
                        RazonSocial = item[1].ToString(),
                        Cuit = item[2].ToString(),
                        Domicilio = domicilioTemp,
                        Responsabilidad = respTemp,
                        Email = item[11].ToString(),
                        Telefono = item[12].ToString(),
                        Contacto = item[13].ToString(),
                        Saldo = Convert.ToDouble(item[14])
                       


                    });
                }
                return listaProveedores;
            }
        }

        public int Remove(int id)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idProveedor", id));
            return ExecuteNonQuery(delete);
        }
    }
}