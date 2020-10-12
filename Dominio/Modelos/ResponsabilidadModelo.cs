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
    public class ResponsabilidadModelo
    {
        private int id;
        private string nombre;

        private IResponsabilidadRepositorio responsabilidadRepositorio;
        public EntityState State { private get; set; }

        private List<ResponsabilidadModelo> listaResponsabilidad;

        //PROPIEDADES/MODELO DE VISTAS/ VALIDAR DATOS
        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "El campo nombre no puede quedar vacio")]
        // [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="El nombre solo admite letras")]
        //[StringLength(maximumLength:50, MinimumLength =3,ErrorMessage ="El mínimo de caracteres para el nombre es 3")]
        public string Nombre { get => nombre; set => nombre = value; }

        public ResponsabilidadModelo()
        {
            responsabilidadRepositorio = new ResponsabilidadRepositorio();

        }
        public string GuardarCambios()
        {
            string mensaje = null;
            try
            {
                var DataModel = new Responsabilidad();

                DataModel.id = id;
                DataModel.nombre = nombre;


                switch (State)
                {
                    case EntityState.Agregado:
                        responsabilidadRepositorio.Add(DataModel);
                        mensaje = "Se agregó correctamente " + DataModel.nombre;
                        break;
                    case EntityState.Modificado:
                        responsabilidadRepositorio.Edit(DataModel);
                        mensaje = "Se editó correctamente " + DataModel.nombre;
                        break;
                    case EntityState.Borrado:
                        responsabilidadRepositorio.Remove(id);
                        mensaje = "Se borró correctamente " + DataModel.nombre; ;
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

        public List<ResponsabilidadModelo> GetAll()
        {
            var DataModel = responsabilidadRepositorio.GetAll();
            listaResponsabilidad = new List<ResponsabilidadModelo>();
            foreach (Responsabilidad item in DataModel)
            {
                listaResponsabilidad.Add(new ResponsabilidadModelo
                {
                    id = item.id,
                    nombre = item.nombre

                }); ;



            }
            return listaResponsabilidad;
        }
        public IEnumerable<ResponsabilidadModelo> FindById(string filtro)
        {
            return listaResponsabilidad.FindAll(e => e.nombre.ToUpper().Contains(filtro.ToUpper()));

        }
    }
}