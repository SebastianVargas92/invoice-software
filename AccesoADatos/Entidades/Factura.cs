using System;


namespace AccesoADatos.Entidades
{
    public class Factura
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public TipoFactura TipoFactura { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public Usuario Usuario { get; set; }
        public double Neto { get; set; }
        public double Iva { get; set; }
        public double Total { get; set; } 
        public double Descuento { get; set; }
        public FormaDePago FormaDePago { get; set; }
        public bool Cancelada { get; set; }

    }
}
