using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoADatos.Entidades;
using System.Data;
using System.Data.SqlClient;
using AccesoADatos.Contratos;

namespace AccesoADatos.Repositorios
{
    public class CompraDetalleRepositorio : RepositorioMaestro, ICompraDetalleRepositorio
    {
        private readonly string selectAll;
        private readonly string insert;
        //private readonly string update;
        //private readonly string delete;



        public CompraDetalleRepositorio()
        {
            selectAll = "select COMPRAS.id, COMPRAS.numero,ARTICULOS.idArticulo, ARTICULOS.codigo, ARTICULOS.descripcion, ARTICULOS.precio, cantidad, subTotal " +
                "from COMPRA_DETALLE " +
                "inner join COMPRAS on COMPRAS.id = COMPRA_DETALLE.id " +
                "inner join ARTICULOS on ARTICULOS.idArticulo = COMPRA_DETALLE.idArticulo ";

            insert = "Begin " +
                "insert into COMPRA_DETALLE values(@idCompra,@idArticulo,@precioVenta,@cantidad,@subTotal) " +
                "Begin " +
                "update ARTICULOS set stock = stock + @cantidad where @idArticulo = ARTICULOS.idArticulo " +
                "End " +
                "End";


            //////////COREEGIR INGRESO DE idFactura 
            ///




            // update = "update FACTURAS set codigo=@codigo,descripcion=@descripcion,costo=@costo,rentabilidad=@rentabilidad,precio=@precio,lista2=@lista2,lista3=@lista3,iva=@iva,puntoPedido=@puntoPedido,cantMax=@cantMax,stock=@stock,grup=@grup,marc=@marc,prov=@prov,ultimaModificacion=@ultimaModificacion,baja=@baja,impInterno=@impInterno where idArticulo=@idArticulo";
            //  delete = "update FACTURAS set codigo=-(idArticulo),baja=1 where idArticulo=@idArticulo";


        }
        public int Add(CompraDetalle entity)
        {
            parametros = new List<SqlParameter>
            {
                new SqlParameter("@idCompra", entity.Compras.Id),
                new SqlParameter("@idArticulo", entity.Articulo.Id),
                new SqlParameter("@precioVenta", entity.PrecioVenta),
                new SqlParameter("@cantidad", entity.Cantidad),
                new SqlParameter("@subTotal", entity.Subtotal)


            };

            return ExecuteNonQuery(insert);

        }

        public int Edit(CompraDetalle entity)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<CompraDetalle> GetAll()
        {
            var tableResult = ExecuteReader(selectAll);
            var listaCompraDetalles = new List<CompraDetalle>();


            foreach (DataRow item in tableResult.Rows)
            {

                var factTemp = new Compras
                {
                    Id = Convert.ToInt32(item[0]),
                    Numero = Convert.ToInt32(item[1])
                };
                var artTemp = new Articulo
                {
                    Id = Convert.ToInt32(item[2]),
                    Codigo = item[3].ToString(),
                    Descripcion = item[4].ToString(),
                    Precio = Convert.ToDouble(item[5])
                };


                listaCompraDetalles.Add(new CompraDetalle
                {
                    //Id = Convert.ToInt32(item[0]),
                    Compras = factTemp,
                    Articulo = artTemp,
                    PrecioVenta = artTemp.Precio,
                    Cantidad = Convert.ToDouble(item[6]),
                    Subtotal = Convert.ToDouble(item[7])



                });
            }
            return listaCompraDetalles;
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
