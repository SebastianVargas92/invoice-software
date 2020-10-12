using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.Entidades
{
   public class Domicilio
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public int IdLocalidad { get; set; }
        public Localidad Localidad { get; set; }
    }
}
