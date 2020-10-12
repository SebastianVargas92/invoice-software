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
    public class FacturaDetalleRepositorio : RepositorioMaestro, IFacturaDetalleRepositorio
    {
        private readonly string selectAll;
        private readonly string insert;
        //private readonly string update;
        //private readonly string delete;



        public FacturaDetalleRepositorio()
        {
            selectAll = "select FACTURAS.id, FACTURAS.numero,ARTICULOS.idArticulo, ARTICULOS.codigo, ARTICULOS.descripcion, ARTICULOS.precio, cantidad, subTotal " +
                "from FACTURA_DETALLE " +
                "inner join FACTURAS on FACTURAS.id = FACTURA_DETALLE.idFactura " +
                "inner join ARTICULOS on ARTICULOS.idArticulo = FACTURA_DETALLE.idArticulo ";

            insert = "Begin " +
                "insert into FACTURA_DETALLE values(@idFactura,@idArticulo,@precioVenta,@cantidad,@subTotal) " +
                "Begin " +
                "update ARTICULOS set stock = stock - @cantidad where @idArticulo = ARTICULOS.idArticulo " +
                "End " +
                "End";
           
            
            //////////COREEGIR INGRESO DE idFactura 
            ///




            // update = "update FACTURAS set codigo=@codigo,descripcion=@descripcion,costo=@costo,rentabilidad=@rentabilidad,precio=@precio,lista2=@lista2,lista3=@lista3,iva=@iva,puntoPedido=@puntoPedido,cantMax=@cantMax,stock=@stock,grup=@grup,marc=@marc,prov=@prov,ultimaModificacion=@ultimaModificacion,baja=@baja,impInterno=@impInterno where idArticulo=@idArticulo";
            //  delete = "update FACTURAS set codigo=-(idArticulo),baja=1 where idArticulo=@idArticulo";


        }
        public int Add(FacturaDetalle entity)
        {
            parametros = new List<SqlParameter>
            {
                new SqlParameter("@idFactura", entity.Factura.Id),
                new SqlParameter("@idArticulo", entity.Articulo.Id),
                new SqlParameter("@precioVenta", entity.PrecioVenta),
                new SqlParameter("@cantidad", entity.Cantidad),
                new SqlParameter("@subTotal", entity.Subtotal)
               

            };

            return ExecuteNonQuery(insert);

        }

        public int Edit(FacturaDetalle entity)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<FacturaDetalle> GetAll()
        {
            var tableResult = ExecuteReader(selectAll);
            var listaFactDetalles = new List<FacturaDetalle>();


            foreach (DataRow item in tableResult.Rows)
            {
                
                var factTemp = new Factura
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


                listaFactDetalles.Add(new FacturaDetalle
                {
                    //Id = Convert.ToInt32(item[0]),
                    Factura = factTemp,
                    Articulo = artTemp,
                    PrecioVenta = artTemp.Precio,
                    Cantidad = Convert.ToDouble(item[6]),
                    Subtotal = Convert.ToDouble(item[7])



                });
            }
            return listaFactDetalles;
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
