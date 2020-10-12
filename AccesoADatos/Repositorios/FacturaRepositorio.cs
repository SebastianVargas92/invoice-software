using AccesoADatos.Contratos;
using System;
using System.Collections.Generic;
using AccesoADatos.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace AccesoADatos.Repositorios
{
    public class FacturaRepositorio: RepositorioMaestro, IFacturaRepositorio
    {
        private readonly string selectAll;
        private readonly string insert;
        //private readonly string update;
        //private readonly string delete;



        public FacturaRepositorio()
        {
            selectAll = "select FACTURAS.id,numero,TIPO_FACTURA.id, TIPO_FACTURA.tipo, fecha, CLIENTE.idCliente, CLIENTE.nombre, USUARIOS.idUsuario,USUARIOS.nombre, neto,iva,total,descuento,FORMA_DE_PAGO.id,FORMA_DE_PAGO.tipo,cancelada" +
                " from FACTURAS" +
                " inner join TIPO_FACTURA on FACTURAS.idTipoFactura = TIPO_FACTURA.id" +
                " inner join CLIENTE on FACTURAS.idCliente = CLIENTE.idCliente" +
                " inner join USUARIOS on FACTURAS.idUsuario = USUARIOS.idUsuario" +
                " inner join FORMA_DE_PAGO on FACTURAS.idFormaDePago = FORMA_DE_PAGO.id";

            insert = "insert into FACTURAS values(@numero,@idTipoFactura,@fecha,@idCliente,@idUsuario,@neto,@iva,@total,@descuento,@idFormaDePago,@cancelada)";
           // update = "update FACTURAS set codigo=@codigo,descripcion=@descripcion,costo=@costo,rentabilidad=@rentabilidad,precio=@precio,lista2=@lista2,lista3=@lista3,iva=@iva,puntoPedido=@puntoPedido,cantMax=@cantMax,stock=@stock,grup=@grup,marc=@marc,prov=@prov,ultimaModificacion=@ultimaModificacion,baja=@baja,impInterno=@impInterno where idArticulo=@idArticulo";
          //  delete = "update FACTURAS set codigo=-(idArticulo),baja=1 where idArticulo=@idArticulo";


        }

        //Metodos

        public int Add(Factura entity)
        {
            parametros = new List<SqlParameter>
            {
                new SqlParameter("@numero", entity.Numero),
                new SqlParameter("@idTipoFactura", entity.TipoFactura.Id),
                new SqlParameter("@fecha", entity.Fecha),
                new SqlParameter("@idCliente", entity.Cliente.Id),
                new SqlParameter("@idUsuario", entity.Usuario.Id),
                new SqlParameter("@neto", entity.Neto),
                new SqlParameter("@iva", entity.Iva),
                new SqlParameter("@total", entity.Total),
                new SqlParameter("@descuento", entity.Descuento),
                new SqlParameter("@idFormaDePago", entity.FormaDePago.Id),
                new SqlParameter("@cancelada", entity.Cancelada),
                
            };

            return ExecuteNonQuery(insert);

        }

        public int Edit(Factura entity) { return 0; }
        //{
        //    parametros = new List<SqlParameter>
        //    {
        //        new SqlParameter("@idArticulo", entity.Id),
        //        new SqlParameter("@codigo", entity.Codigo),
        //        new SqlParameter("@descripcion", entity.Descripcion),
        //        new SqlParameter("@costo", entity.Costo),
        //        new SqlParameter("@rentabilidad", entity.Rentabilidad),
        //        new SqlParameter("@precio", entity.Precio),
        //        new SqlParameter("@lista2", entity.Lista2),
        //        new SqlParameter("@lista3", entity.Lista3),
        //        new SqlParameter("@iva", entity.IvaEntity.id),
        //        new SqlParameter("@puntoPedido", entity.PuntoDePedido),
        //        new SqlParameter("@cantMax", entity.CantMax),
        //        new SqlParameter("@stock", entity.Stock),
        //        new SqlParameter("@grup", entity.Grupo.id),
        //        new SqlParameter("@marc", entity.Marca.id),
        //        new SqlParameter("@prov", entity.Proveedor.Id),
        //        new SqlParameter("@ultimaModificacion", entity.UltimaModificacion),
        //        new SqlParameter("@baja", entity.Baja),
        //        new SqlParameter("@impInterno", entity.ImpInterno)
        //    };

        //    return ExecuteNonQuery(update);
        //}

        public IEnumerable<Factura> GetAll()
        {
            var tableResult = ExecuteReader(selectAll);
            var listaArticulos = new List<Factura>();



            foreach (DataRow item in tableResult.Rows)
            {
                var tipoFacTemp = new TipoFactura();
                var cliTemp = new Cliente();
                var usuTemp = new Usuario();
                var formaPagoTemp = new FormaDePago();

                tipoFacTemp.Id = Convert.ToInt32(item[2]);
                tipoFacTemp.Tipo = item[3].ToString();
                cliTemp.Id = Convert.ToInt32(item[5].ToString());
                cliTemp.Nombre = item[6].ToString();
                usuTemp.Id = Convert.ToInt32(item[7].ToString());
                usuTemp.Nombre = item[8].ToString();
                formaPagoTemp.Id = Convert.ToInt32(item[13].ToString());
                formaPagoTemp.Tipo = item[14].ToString();

                listaArticulos.Add(new Factura
                {
                    Id = Convert.ToInt32(item[0]),
                    Numero = Convert.ToInt32(item[1]),
                    TipoFactura = tipoFacTemp,
                    Fecha = Convert.ToDateTime(item[4]),
                    Cliente = cliTemp,
                    Usuario = usuTemp,
                    Neto = Convert.ToDouble(item[9]),
                    Iva = Convert.ToDouble(item[10]),
                    Total = Convert.ToDouble(item[11]),
                    Descuento = Convert.ToInt32(item[12]),
                    FormaDePago =formaPagoTemp,
                    Cancelada = Convert.ToBoolean(item[15])
                    

                });
            }
            return listaArticulos;
        }



        public int Remove(int id) { return 0; }
        //{
        //    parametros = new List<SqlParameter>
        //    {
        //        new SqlParameter("@idArticulo", id)
        //    };
        //    return ExecuteNonQuery(delete);
        //}


    }
}