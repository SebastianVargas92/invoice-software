using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.Entidades
{
    public class Localidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdProv { get; set; }
        public Provincia Provincia { get; set; }

    }
}
