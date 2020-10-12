using System;
using System.Collections.Generic;
using AccesoADatos.Contratos;
using AccesoADatos.Entidades;
using AccesoADatos.Repositorios;
using Dominio.Objetos;
using System.ComponentModel.DataAnnotations;


namespace Dominio.Modelos
{
    public class FacturaDetalleModelo
    {
        private int id;
        //private  int idFactura;
        //private readonly int idArticulo;
        private double precioVenta;
        private double cantidad;
        private double subTotal;

        public FacturaModelo Factura { get; set; }
        public ArticuloModelo Articulo { get; set; }

        private readonly IFacturaDetalleRepositorio factDetaRepo;

        public EntityState State { private get; set; }

        public List<FacturaDetalleModelo> listaFactDetalles;

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


        public FacturaDetalleModelo()
        {
            factDetaRepo = new FacturaDetalleRepositorio();
        }
        public List<FacturaDetalleModelo> GetAll()
        {
            var marcaDataModel = factDetaRepo.GetAll();
            listaFactDetalles = new List<FacturaDetalleModelo>();


            foreach (FacturaDetalle item in marcaDataModel)
            {
                var facTemp = new FacturaModelo();
                var artTemp = new ArticuloModelo();

                facTemp.Id = item.Factura.Id;
                facTemp.Numero = item.Factura.Numero;
                artTemp.Id = item.Articulo.Id;
                artTemp.Codigo = item.Articulo.Codigo;
                artTemp.Descripcion = item.Articulo.Descripcion;
                artTemp.Precio = item.Articulo.Precio;


                listaFactDetalles.Add(new FacturaDetalleModelo
                {
                    id = item.Id,
                    Factura = facTemp,
                    Articulo= artTemp,
                    precioVenta = item.PrecioVenta,
                    cantidad = item.Cantidad,
                    subTotal = item.Cantidad * item.PrecioVenta


                }); ;



            }
            return listaFactDetalles;
        }

        public string GuardarCambios()
        {
            string mensaje = null;
            try
            {
                var factDetDataModel = new FacturaDetalle
                {


                    Factura = new Factura(),
                    Articulo = new Articulo(),
                   

                    Id = id,
                    PrecioVenta = precioVenta,
                    Cantidad = cantidad,
                    Subtotal = subTotal
                };
                factDetDataModel.Factura.Id = Factura.Id;
                factDetDataModel.Articulo.Id = Articulo.Id;
                factDetDataModel.PrecioVenta = precioVenta;
                factDetDataModel.Cantidad = cantidad;
                factDetDataModel.Subtotal = subTotal;
               

                switch (State)
                {
                    case EntityState.Agregado:
                        factDetaRepo.Add(factDetDataModel);
                        //mensaje = "Se agregó correctamente el detalle ";

                        break;
                    case EntityState.Modificado:
                        factDetaRepo.Edit(factDetDataModel);
                        mensaje = "Se editó correctamente " + factDetDataModel;
                        break;
                    case EntityState.Borrado:
                        factDetaRepo.Remove(id);
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
