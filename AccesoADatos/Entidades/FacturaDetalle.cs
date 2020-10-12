using System;


namespace AccesoADatos.Entidades
{
    public class FacturaDetalle
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public int IdArticulo { get; set; }
        public double PrecioVenta { get; set; }
        public double Cantidad { get; set; }
        public double Subtotal { get; set; }
        public Factura Factura { get; set; }
        public Articulo Articulo { get; set; }
    }
}
