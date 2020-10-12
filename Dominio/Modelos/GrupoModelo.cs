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
   public class GrupoModelo
    {
        private int id;
        private string nombre;

        private IGrupoRepositorio grupoRepositorio;
        public EntityState State { private get; set; }

        private List<GrupoModelo> listaGrupos;

        //PROPIEDADES/MODELO DE VISTAS/ VALIDAR DATOS
        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "El campo nombre no puede quedar vacio")]
        // [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="El nombre solo admite letras")]
        //[StringLength(maximumLength:50, MinimumLength =3,ErrorMessage ="El mínimo de caracteres para el nombre es 3")]
        public string Nombre { get => nombre; set => nombre = value; }

        public GrupoModelo()
        {
            grupoRepositorio = new GrupoRepositorio();

        }
        public string GuardarCambios()
        {
            string mensaje = null;
            try
            {
                var grupoDataModel = new Grupo();

                grupoDataModel.id = id;
                grupoDataModel.grupo = nombre;
                

                switch (State)
                {
                    case EntityState.Agregado:
                        grupoRepositorio.Add(grupoDataModel);
                        mensaje = "Se agregó correctamente " + grupoDataModel.grupo;
                        break;
                    case EntityState.Modificado:
                        grupoRepositorio.Edit(grupoDataModel);
                        mensaje = "Se editó correctamente " + grupoDataModel.grupo;
                        break;
                    case EntityState.Borrado:
                        grupoRepositorio.Remove(id);
                        mensaje = "Se borró correctamente " + grupoDataModel.grupo; ;
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

        public List<GrupoModelo> GetAll()
        {
            var grupoDataModel = grupoRepositorio.GetAll();
            listaGrupos = new List<GrupoModelo>();
            foreach (Grupo item in grupoDataModel)
            {
                listaGrupos.Add(new GrupoModelo
                {
                    id = item.id,
                    nombre = item.grupo
                    
                }); ;



            }
            return listaGrupos;
        }
        public IEnumerable<GrupoModelo> FindById(string filtro)
        {
            return listaGrupos.FindAll(e => e.nombre.ToUpper().Contains(filtro.ToUpper()));

        }
    }
}
