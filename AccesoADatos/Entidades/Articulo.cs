using System;

namespace AccesoADatos.Entidades
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public double Rentabilidad { get; set; }
        public double Precio { get; set; }
        public double Lista2 { get; set; }
        public double Lista3 { get; set; }
        public int PuntoDePedido { get; set; }
        public double CantMax { get; set; }
        public double Stock { get; set; }
        public DateTime UltimaModificacion { get; set; }
        public bool Baja { get; set; }
        public double ImpInterno { get; set; }
        public Grupo Grupo { get; set; }
        public Iva IvaEntity { get; set; }
        public Marca Marca { get; set; }
        public Proveedor Proveedor { get; set; }

    }
}
