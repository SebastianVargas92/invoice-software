using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.Entidades
{
    public class CompraDetalle
    {
        public int Id { get; set; }
        public int IdCompras { get; set; }
        public int IdArticulo { get; set; }
        public double PrecioVenta { get; set; }
        public double Cantidad { get; set; }
        public double Subtotal { get; set; }
        public Compras Compras { get; set; }
        public Articulo Articulo { get; set; }
    }
}
