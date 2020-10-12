using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.Entidades
{
    public class Cliente
    {
      
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cuit { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Contacto { get; set; }
        public double Saldo { get; set; }
        public Responsabilidad Responsabilidad { get; set; }
        public Domicilio Domicilio { get; set; }
    }
}

