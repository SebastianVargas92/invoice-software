using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace guidProyecto
{
    
 [ComVisibleAttribute(true)]  //Deja la clase visible para COM
    [Guid("B96AC990-D0E2-476D-BED4-A17EDBDC5331")] //GUID que generamos, Identificador de la Libreria
    [ProgId("TestLib.Class")] //Identificador para poder Acceder a esta clase desde el exterior
    public class Class1
    {
        public string Hola()
        {
            return "Hola Mundo desde .NET";
        }
    }
}