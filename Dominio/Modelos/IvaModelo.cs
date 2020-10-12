using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoADatos.Contratos;
using AccesoADatos.Entidades;
using AccesoADatos.Repositorios;
using Dominio.Objetos;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Dominio.Modelos
{
   public class IvaModelo
    {
        private int id;
        private double valor;

        private IIvaRepositorio ivaRepositorio;
        public EntityState State { private get; set; }

        private List<IvaModelo> listaIvas;

        //PROPIEDADES/MODELO DE VISTAS/ VALIDAR DATOS
        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "El campo nombre no puede quedar vacio")]
        // [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="El nombre solo admite letras")]
        //[StringLength(maximumLength:50, MinimumLength =3,ErrorMessage ="El mínimo de caracteres para el nombre es 3")]
        public double Valor { get => valor; set => valor = value; }

        public IvaModelo()
        {
            ivaRepositorio = new IvaRepositorio();

        }
        public string GuardarCambios()
        {
            string mensaje = null;
            try
            {
                var ivaDataModel = new Iva();

                ivaDataModel.id = id;
                ivaDataModel.valor = valor;


                switch (State)
                {
                    case EntityState.Agregado:
                        ivaRepositorio.Add(ivaDataModel);
                        mensaje = "Se agregó correctamente " + ivaDataModel.valor;
                        break;
                    case EntityState.Modificado:
                        ivaRepositorio.Edit(ivaDataModel);
                        mensaje = "Se editó correctamente " + ivaDataModel.valor;
                        break;
                    case EntityState.Borrado:
                        ivaRepositorio.Remove(id);
                        mensaje = "Se borró correctamente " + ivaDataModel.valor;
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Data.SqlClient.SqlException sqlEx = ex as System.Data.SqlClient.SqlException;
                if (sqlEx != null && sqlEx.Number == 2627)
                {
                    mensaje = "el registro ya existe";
                }
                else
                    mensaje = ex.ToString();
            }
            return mensaje;
        }

        public List<IvaModelo> GetAll()
        {
            var ivaDataModel = ivaRepositorio.GetAll();
            listaIvas = new List<IvaModelo>();
            foreach (Iva item in ivaDataModel)
            {
                listaIvas.Add(new IvaModelo
                {
                    id = item.id,
                    valor = item.valor

                }); ;



            }
            return listaIvas;
        }
       
    }
}
