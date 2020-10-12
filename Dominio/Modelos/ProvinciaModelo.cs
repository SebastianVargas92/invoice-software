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
    public class ProvinciaModelo
    {
        private int id;
        private string nombre;

        private IProvinciaRepositorio provinciaRepositorio;
        public EntityState State { private get; set; }

        private List<ProvinciaModelo> listaProvincias;

        //PROPIEDADES/MODELO DE VISTAS/ VALIDAR DATOS
        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "El campo nombre no puede quedar vacio")]
        // [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="El nombre solo admite letras")]
        //[StringLength(maximumLength:50, MinimumLength =3,ErrorMessage ="El mínimo de caracteres para el nombre es 3")]
        public string Nombre { get => nombre; set => nombre = value; }

        public ProvinciaModelo()
        {
            provinciaRepositorio = new ProvinciaRepositorio();

        }
        public string GuardarCambios()
        {
            string mensaje = null;
            try
            {
                var provinciaDataModel = new Provincia();

                provinciaDataModel.Id = id;
                provinciaDataModel.Nombre = nombre;


                switch (State)
                {
                    case EntityState.Agregado:
                        provinciaRepositorio.Add(provinciaDataModel);
                        mensaje = "Se agregó correctamente " + provinciaDataModel.Nombre;
                        break;
                    case EntityState.Modificado:
                        provinciaRepositorio.Edit(provinciaDataModel);
                        mensaje = "Se editó correctamente " + provinciaDataModel.Nombre;
                        break;
                    case EntityState.Borrado:
                        provinciaRepositorio.Remove(id);
                        mensaje = "Se borró correctamente " + provinciaDataModel.Nombre; ;
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

        public List<ProvinciaModelo> GetAll()
        {
            var provinciaDataModel = provinciaRepositorio.GetAll();
            listaProvincias = new List<ProvinciaModelo>();
            foreach (Provincia item in provinciaDataModel)
            {

                listaProvincias.Add(new ProvinciaModelo
                {
                    id = item.Id,
                    nombre = item.Nombre

                }); ;



            }
            return listaProvincias;
        }
        public IEnumerable<ProvinciaModelo> FindById(string filtro)
        {
            return listaProvincias.FindAll(e => e.Nombre.ToUpper().Contains(filtro.ToUpper()));

        }
    }
}