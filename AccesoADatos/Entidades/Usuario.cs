using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Emal { get; set; }

    }
}
