using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoADatos.Contratos;
using AccesoADatos.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace AccesoADatos.Repositorios
{
    public class ArticuloRepositorio : RepositorioMaestro, IArticuloRepositorio
    {
        private readonly string selectAll;
        private readonly string insert;
        private readonly string update;
        private readonly string delete;
      



        public ArticuloRepositorio()
        {
            selectAll = "select idArticulo, codigo, descripcion,costo,rentabilidad,precio,lista2, lista3, IVA.idIVA, IVa.valor, puntoPedido,cantMax, stock, GRUPOS.idGrupo, GRUPOS.nombre, MARCAS.idMarca, MARCAS.nombre, PROVEEDOR.idProveedor, PROVEEDOR.razonSocial, ultimaModificacion, baja , impInterno from ARTICULOS" +
                " inner join GRUPOS on ARTICULOS.grup = GRUPOS.idGrupo" +
                " inner join MARCAS on ARTICULOS.marc = MARCAS.idMarca" +
                " inner join PROVEEDOR on ARTICULOS.prov = PROVEEDOR.idProveedor" +
                " inner join IVA on ARTICULOS.iva = IVA.idIva where baja = 0";
            insert = "insert into Articulos values(@codigo,@descripcion,@costo,@rentabilidad,@precio,@lista2,@lista3,@iva,@puntoPedido,@cantMax,@stock,@grup,@marc,@prov,@ultimaModificacion,@baja,@impInterno)";
            update = "update Articulos set codigo=@codigo,descripcion=@descripcion,costo=@costo,rentabilidad=@rentabilidad,precio=@precio,lista2=@lista2,lista3=@lista3,iva=@iva,puntoPedido=@puntoPedido,cantMax=@cantMax,stock=@stock,grup=@grup,marc=@marc,prov=@prov,ultimaModificacion=@ultimaModificacion,baja=@baja,impInterno=@impInterno where idArticulo=@idArticulo";
            delete = "update Articulos set codigo=-(idArticulo),baja=1 where idArticulo=@idArticulo";
            
          
        }

        //Metodos
         
           public int Add(Articulo entity)
        {
            parametros = new List<SqlParameter>
            {
                new SqlParameter("@codigo", entity.Codigo),
                new SqlParameter("@descripcion", entity.Descripcion),
                new SqlParameter("@costo", entity.Costo),
                new SqlParameter("@rentabilidad", entity.Rentabilidad),
                new SqlParameter("@precio", entity.Precio),
                new SqlParameter("@lista2", entity.Lista2),
                new SqlParameter("@lista3", entity.Lista3),
                new SqlParameter("@iva", entity.IvaEntity.id),
                new SqlParameter("@puntoPedido", entity.PuntoDePedido),
                new SqlParameter("@cantMax", entity.CantMax),
                new SqlParameter("@stock", entity.Stock),
                new SqlParameter("@grup", entity.Grupo.id),
                new SqlParameter("@marc", entity.Marca.id),
                new SqlParameter("@prov", entity.Proveedor.Id),
                new SqlParameter("@ultimaModificacion", entity.UltimaModificacion),
                new SqlParameter("@baja", entity.Baja),
                new SqlParameter("@impInterno", entity.ImpInterno)
            };

            return ExecuteNonQuery(insert);

        }

        public int Edit(Articulo entity)
        {
            parametros = new List<SqlParameter>
            {
                new SqlParameter("@idArticulo", entity.Id),
                new SqlParameter("@codigo", entity.Codigo),
                new SqlParameter("@descripcion", entity.Descripcion),
                new SqlParameter("@costo", entity.Costo),
                new SqlParameter("@rentabilidad", entity.Rentabilidad),
                new SqlParameter("@precio", entity.Precio),
                new SqlParameter("@lista2", entity.Lista2),
                new SqlParameter("@lista3", entity.Lista3),
                new SqlParameter("@iva", entity.IvaEntity.id),
                new SqlParameter("@puntoPedido", entity.PuntoDePedido),
                new SqlParameter("@cantMax", entity.CantMax),
                new SqlParameter("@stock", entity.Stock),
                new SqlParameter("@grup", entity.Grupo.id),
                new SqlParameter("@marc", entity.Marca.id),
                new SqlParameter("@prov", entity.Proveedor.Id),
                new SqlParameter("@ultimaModificacion", entity.UltimaModificacion),
                new SqlParameter("@baja", entity.Baja),
                new SqlParameter("@impInterno", entity.ImpInterno)
            };

            return ExecuteNonQuery(update);
        }

        public IEnumerable<Articulo> GetAll()
        {
            var tableResult = ExecuteReader(selectAll);
            var listaArticulos = new List<Articulo>();
            
            

            foreach (DataRow item in tableResult.Rows)
            {
                var ivaTemp = new Iva();
                var grupTemp = new Grupo();
                var proveTemp = new Proveedor();
                var marcaTemp = new Marca();

                ivaTemp.id = Convert.ToInt32(item[8]);
                ivaTemp.valor = Convert.ToDouble(item[9].ToString());
                grupTemp.id = Convert.ToInt32(item[13].ToString());
                grupTemp.grupo = item[14].ToString();
                marcaTemp.id = Convert.ToInt32(item[15].ToString());
                marcaTemp.marca = item[16].ToString();
                proveTemp.Id = Convert.ToInt32(item[17].ToString());
                proveTemp.RazonSocial = item[18].ToString();

                listaArticulos.Add(new Articulo
                {
                    Id = Convert.ToInt32(item[0]),
                    Codigo = item[1].ToString(),
                    Descripcion = item[2].ToString(),
                    Costo = Convert.ToDouble(item[3]),
                    Rentabilidad = Convert.ToDouble(item[4]),
                    Precio = Convert.ToDouble(item[5]),
                    Lista2 = Convert.ToDouble(item[6]),
                    Lista3 = Convert.ToDouble(item[7]),
                    IvaEntity = ivaTemp,
                    PuntoDePedido = Convert.ToInt32(item[10]),
                    CantMax = Convert.ToDouble(item[11]),
                    Stock = Convert.ToDouble(item[12]),
                    Grupo = grupTemp,
                    Marca = marcaTemp,
                    Proveedor = proveTemp,
                    UltimaModificacion =  Convert.ToDateTime(item[19].ToString()),
                    Baja = Convert.ToBoolean(item[20]),
                    ImpInterno = Convert.ToDouble(item[21])

                });
            }
            return listaArticulos;
        }

    

        public int Remove(int id)
        {
            parametros = new List<SqlParameter>
            {
                new SqlParameter("@idArticulo", id)
            };
            return ExecuteNonQuery(delete);
        }

    
    }
}
