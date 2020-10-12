using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Presentacion.Helps
{
   public class ValidacionDeDatos
    {
        private ValidationContext contexto;
        private List<ValidationResult> resultados;
        private bool valido;
        private string mensaje;

        public ValidacionDeDatos(object instancia)
        {
            contexto = new ValidationContext(instancia);
            resultados = new List<ValidationResult>();
            valido = Validator.TryValidateObject(instancia, contexto, resultados, true);
        }
        public bool Validar()
        {
            if(valido == false)
            {
                foreach(ValidationResult item in resultados)
                {
                    mensaje += item.ErrorMessage + "\n";
                }
                System.Windows.Forms.MessageBox.Show(mensaje);
            }
            return valido;
        }

    }
}
