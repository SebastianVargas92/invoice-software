using System;
using System.Collections.Generic;
using AccesoADatos.Contratos;
using AccesoADatos.Entidades;
using AccesoADatos.Repositorios;
using Dominio.Objetos;
using System.ComponentModel.DataAnnotations;


namespace Dominio.Modelos
{
    public class CompraDetalleModelo
    {
        private int id;
        //private  int idFactura;
        //private readonly int idArticulo;
        private double precioVenta;
        private double cantidad;
        private double subTotal;

        public ComprasModelo Compra { get; set; }
        public ArticuloModelo Articulo { get; set; }

        private readonly ICompraDetalleRepositorio compraDetaRepo;

        public EntityState State { private get; set; }

        public List<CompraDetalleModelo> listaCompraDetalles;

        //PROPIEDADES/MODELO DE VISTAS/ VALIDAR DATOS
        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "El Precio de venta no puede quedar vacio")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Solo se admiten numeros en Precio")]
        public double PrecioVenta { get => precioVenta; set => precioVenta = value; }
        [Required(ErrorMessage = "El campo Cantidad no puede quedar vacio")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Solo se admiten numeros en Precio")]
        public double Cantidad { get => cantidad; set => cantidad = value; }
        [Required(ErrorMessage = "El SubTotal no puede quedar vacio")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Solo se admiten numeros en Precio")]
        public double SubTotal { get => subTotal; set => subTotal = value; }


        public CompraDetalleModelo()
        {
            compraDetaRepo = new CompraDetalleRepositorio();
        }
        public List<CompraDetalleModelo> GetAll()
        {
            var marcaDataModel = compraDetaRepo.GetAll();
            listaCompraDetalles = new List<CompraDetalleModelo>();


            foreach (CompraDetalle item in marcaDataModel)
            {
                var facTemp = new ComprasModelo();
                var artTemp = new ArticuloModelo();

                facTemp.Id = item.Compras.Id;
                facTemp.Numero = item.Compras.Numero;
                artTemp.Id = item.Articulo.Id;
                artTemp.Codigo = item.Articulo.Codigo;
                artTemp.Descripcion = item.Articulo.Descripcion;
                artTemp.Precio = item.Articulo.Precio;


                listaCompraDetalles.Add(new CompraDetalleModelo
                {
                    id = item.Id,
                    Compra = facTemp,
                    Articulo = artTemp,
                    precioVenta = item.PrecioVenta,
                    cantidad = item.Cantidad,
                    subTotal = item.Cantidad * item.PrecioVenta


                }); ;



            }
            return listaCompraDetalles;
        }

        public string GuardarCambios()
        {
            string mensaje = null;
            try
            {
                var factDetDataModel = new CompraDetalle
                {


                    Compras = new Compras(),
                    Articulo = new Articulo(),


                    Id = id,
                    PrecioVenta = precioVenta,
                    Cantidad = cantidad,
                    Subtotal = subTotal
                };
                factDetDataModel.Compras.Id = Compra.Id;
                factDetDataModel.Articulo.Id = Articulo.Id;
                factDetDataModel.PrecioVenta = precioVenta;
                factDetDataModel.Cantidad = cantidad;
                factDetDataModel.Subtotal = subTotal;


                switch (State)
                {
                    case EntityState.Agregado:
                        compraDetaRepo.Add(factDetDataModel);
                        //mensaje = "Se agregó correctamente el detalle ";

                        break;
                    case EntityState.Modificado:
                        compraDetaRepo.Edit(factDetDataModel);
                        mensaje = "Se editó correctamente " + factDetDataModel;
                        break;
                    case EntityState.Borrado:
                        compraDetaRepo.Remove(id);
                        mensaje = "Se borró correctamente " + factDetDataModel; ;
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Data.SqlClient.SqlException sqlEx = ex as System.Data.SqlClient.SqlException;
                if (sqlEx != null && sqlEx.Number == 2627)
                {
                    mensaje = "el registro ya existe";
                }
                else
                    mensaje = ex.ToString();
            }
            return mensaje;
        }

    }

}
