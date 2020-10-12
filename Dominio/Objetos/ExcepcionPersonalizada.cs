using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Objetos
{
    class ExcepcionPersonalizada : Exception
    {
        public ExcepcionPersonalizada(string mens) : base(mens)
        { }

    }
}
