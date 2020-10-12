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
    public class LocalidadModelo
    {
        private int id;
        private string nombre;
        private int idProv;
         

        private ILocalidadRepositorio localidadRepositorio;
        public EntityState State { private get; set; }

        private List<LocalidadModelo> listaLocalidades;

        //PROPIEDADES/MODELO DE VISTAS/ VALIDAR DATOS
        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "El campo nombre no puede quedar vacio")]
        // [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="El nombre solo admite letras")]
        //[StringLength(maximumLength:50, MinimumLength =3,ErrorMessage ="El mínimo de caracteres para el nombre es 3")]
        public string Nombre { get => nombre; set => nombre = value; }

        [Required(ErrorMessage = "El campo Provincia no puede quedar vacio")]
        public int IdProv { get => idProv; set => idProv = value; }

        public ProvinciaModelo Provincia { get; set; }


        public LocalidadModelo()
        {
            localidadRepositorio = new LocalidadRepositorio();

        }
        public string GuardarCambios()
        {
            string mensaje = null;
            try
            {
                var localidadDataModel = new Localidad();
                localidadDataModel.Provincia = new Provincia();

                localidadDataModel.Id = id;
                localidadDataModel.Nombre = nombre;
                localidadDataModel.IdProv = idProv;
                localidadDataModel.Provincia.Id = Provincia.Id;
                localidadDataModel.Provincia.Nombre = Provincia.Nombre;


                switch (State)
                {
                    case EntityState.Agregado:
                        localidadRepositorio.Add(localidadDataModel);
                        mensaje = "Se agregó correctamente " + localidadDataModel.Nombre;
                        break;
                    case EntityState.Modificado:
                        localidadRepositorio.Edit(localidadDataModel);
                        mensaje = "Se editó correctamente " + localidadDataModel.Nombre;
                        break;
                    case EntityState.Borrado:
                        localidadRepositorio.Remove(id);
                        mensaje = "Se borró correctamente " + localidadDataModel.Nombre; ;
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

        public List<LocalidadModelo> GetAll()
        {
            var LocalidadDataModel = localidadRepositorio.GetAll();
            listaLocalidades = new List<LocalidadModelo>();
            foreach (Localidad item in LocalidadDataModel)
            {
                //var provinciaTemp = new ProvinciaModelo();

                //provinciaTemp.Id = Provincia.Id;
                //provinciaTemp.Nombre = Provincia.Nombre;

                listaLocalidades.Add(new LocalidadModelo
                {
                    id = item.Id,
                    nombre = item.Nombre,
                    idProv = item.IdProv,
                   // Provincia = provinciaTemp

                }); ;



            }
            return listaLocalidades;
        }
        public IEnumerable<LocalidadModelo> FindById(string filtro)
        {
            return listaLocalidades.FindAll(e => e.nombre.ToUpper().Contains(filtro.ToUpper()));

        }
    }
}