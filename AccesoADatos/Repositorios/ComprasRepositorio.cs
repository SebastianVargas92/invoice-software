using AccesoADatos.Contratos;
using System;
using System.Collections.Generic;
using AccesoADatos.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace AccesoADatos.Repositorios
{
    public class ComprasRepositorio : RepositorioMaestro, IComprasRepositorio
    {
        private readonly string selectAll;
        private readonly string insert;
        //private readonly string update;
        //private readonly string delete;



        public ComprasRepositorio()
        {
            selectAll = "select COMPRAS.id, puntoDeVenta, numero,TIPO_FACTURA.id, TIPO_FACTURA.tipo, fecha, PROVEEDOR.idProveedor, PROVEEDOR.razonSocial, USUARIOS.idUsuario,USUARIOS.nombre, neto,iva,total,descuento,FORMA_DE_PAGO.id,FORMA_DE_PAGO.tipo,cancelada" +
                " from COMPRAS" +
                " inner join TIPO_FACTURA on COMPRAS.idTipoFactura = TIPO_FACTURA.id" +
                " inner join PROVEEDOR on COMPRAS.idProveedor = PROVEEDOR.idProveedor" +
                " inner join USUARIOS on COMPRAS.idUsuario = USUARIOS.idUsuario" +
                " inner join FORMA_DE_PAGO on COMPRAS.idFormaDePago = FORMA_DE_PAGO.id";

            insert = "insert into COMPRAS values(@puntoDeVenta,@numero,@idTipoFactura,@fecha,@idProveedor,@idUsuario,@neto,@iva,@total,@descuento,@idFormaDePago,@cancelada)";
            // update = "update FACTURAS set codigo=@codigo,descripcion=@descripcion,costo=@costo,rentabilidad=@rentabilidad,precio=@precio,lista2=@lista2,lista3=@lista3,iva=@iva,puntoPedido=@puntoPedido,cantMax=@cantMax,stock=@stock,grup=@grup,marc=@marc,prov=@prov,ultimaModificacion=@ultimaModificacion,baja=@baja,impInterno=@impInterno where idArticulo=@idArticulo";
            //  delete = "update FACTURAS set codigo=-(idArticulo),baja=1 where idArticulo=@idArticulo";


        }

        //Metodos

        public int Add(Compras entity)
        {
            parametros = new List<SqlParameter>
            {
                new SqlParameter("@puntoDeVenta", entity.PuntoDeVenta),
                new SqlParameter("@numero", entity.Numero),
                new SqlParameter("@idTipoFactura", entity.TipoFactura.Id),
                new SqlParameter("@fecha", entity.Fecha),
                new SqlParameter("@idProveedor", entity.Proveedor.Id),
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

        public int Edit(Compras entity) { return 0; }
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

        public IEnumerable<Compras> GetAll()
        {
            var tableResult = ExecuteReader(selectAll);
            var listaCompras = new List<Compras>();



            foreach (DataRow item in tableResult.Rows)
            {
                var tipoFacTemp = new TipoFactura();
                var provTemp = new Proveedor();
                var usuTemp = new Usuario();
                var formaPagoTemp = new FormaDePago();

                tipoFacTemp.Id = Convert.ToInt32(item[3]);
                tipoFacTemp.Tipo = item[4].ToString();
                provTemp.Id = Convert.ToInt32(item[6].ToString());
                provTemp.RazonSocial = item[7].ToString();
                usuTemp.Id = Convert.ToInt32(item[8].ToString());
                usuTemp.Nombre = item[9].ToString();
                formaPagoTemp.Id = Convert.ToInt32(item[14].ToString());
                formaPagoTemp.Tipo = item[15].ToString();

                listaCompras.Add(new Compras
                {
                    Id = Convert.ToInt32(item[0]),
                    PuntoDeVenta = Convert.ToInt32(item[1]),
                    Numero = Convert.ToInt32(item[2]),
                    TipoFactura = tipoFacTemp,
                    Fecha = Convert.ToDateTime(item[5]),
                    Proveedor = provTemp,
                    Usuario = usuTemp,
                    Neto = Convert.ToDouble(item[10]),
                    Iva = Convert.ToDouble(item[11]),
                    Total = Convert.ToDouble(item[12]),
                    Descuento = Convert.ToInt32(item[13]),
                    FormaDePago = formaPagoTemp,
                    Cancelada = Convert.ToBoolean(item[16])


                });
            }
            return listaCompras;
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