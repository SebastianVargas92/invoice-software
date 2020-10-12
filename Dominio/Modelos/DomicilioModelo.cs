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
    public class DomicilioModelo
    {
        private int Id;
        private string Calle;
        private int IdLocalidad;
        



        private IDomicilioRepositorio domicilioRepositorio;
        public EntityState State { private get; set; }

        private List<DomicilioModelo> listaDomicilios;

        //PROPIEDADES/MODELO DE VISTAS/ VALIDAR DATOS
        public int id { get => Id; set => Id = value; }

        [Required(ErrorMessage = "El campo Calle no puede quedar vacio")]
        // [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="El nombre solo admite letras")]
        //[StringLength(maximumLength:50, MinimumLength =3,ErrorMessage ="El mínimo de caracteres para el nombre es 3")]
        public string calle { get => Calle; set => Calle = value; }

        public int idLocalidad { get => IdLocalidad; set => IdLocalidad = value; }
       

        public LocalidadModelo localidad { get; set; }


        public DomicilioModelo()
        {
            domicilioRepositorio = new DomicilioRepositorio();

        }
        public string GuardarCambios()
        {
            string mensaje = null;
            try
            {
                var domicilioDataModel = new Domicilio();
                
                domicilioDataModel.Id = Id;
                domicilioDataModel.Calle = Calle;
                domicilioDataModel.IdLocalidad = IdLocalidad;
                //domicilioDataModel.Localidad.Id = localidad.Id;
                


                switch (State)
                {
                    case EntityState.Agregado:
                        domicilioRepositorio.Add(domicilioDataModel);
                        mensaje = "Se agregó correctamente " + domicilioDataModel.Calle;
                        break;
                    case EntityState.Modificado:
                        domicilioRepositorio.Edit(domicilioDataModel);
                        mensaje = "Se editó correctamente " + domicilioDataModel.Calle;
                        break;
                    case EntityState.Borrado:
                        domicilioRepositorio.Remove(Id);
                        mensaje = "Se borró correctamente " + domicilioDataModel.Calle; ;
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

        public List<DomicilioModelo> GetAll()
        {
            var domicilioDataModel = domicilioRepositorio.GetAll();
            listaDomicilios = new List<DomicilioModelo>();
            foreach (Domicilio item in domicilioDataModel)
            {
                var locaTemp = new LocalidadModelo();
                localidad = new LocalidadModelo();
                locaTemp.Id = item.IdLocalidad;
                //locaTemp.Nombre = item.Localidad.Nombre;
                //locaTemp.IdProv = item.Localidad.IdProv;

                listaDomicilios.Add(new DomicilioModelo
                {
                    Id = item.Id,
                    Calle = item.Calle,
                    IdLocalidad = item.IdLocalidad,
                    localidad = locaTemp
                    

                }); ;



            }
            return listaDomicilios;
        }
        public IEnumerable<DomicilioModelo> FindById(string filtro)
        {
            return listaDomicilios.FindAll(e => e.Calle.ToUpper().Contains(filtro.ToUpper()));

        }
    }
}