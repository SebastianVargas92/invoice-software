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
    public class MarcaModelo
    {
        private int id;
        private string nombre;

        private readonly IMarcaRepositorio marcaRepositorio;
        public EntityState State { private get; set; }

        private List<MarcaModelo> listaMarcas;

        //PROPIEDADES/MODELO DE VISTAS/ VALIDAR DATOS
        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "El campo nombre no puede quedar vacio")]
        // [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="El nombre solo admite letras")]
        //[StringLength(maximumLength:50, MinimumLength =3,ErrorMessage ="El mínimo de caracteres para el nombre es 3")]
        public string Nombre { get => nombre; set => nombre = value; }

        public MarcaModelo()
        {
            marcaRepositorio = new MarcaRepositorio();

        }
        public string GuardarCambios()
        {
            string mensaje = null;
            try
            {
                var marcaDataModel = new Marca
                {
                    id = id,
                    marca = nombre
                };


                switch (State)
                {
                    case EntityState.Agregado:
                        marcaRepositorio.Add(marcaDataModel);
                        mensaje = "Se agregó correctamente " + marcaDataModel.marca;
                        break;
                    case EntityState.Modificado:
                        marcaRepositorio.Edit(marcaDataModel);
                        mensaje = "Se editó correctamente " + marcaDataModel.marca;
                        break;
                    case EntityState.Borrado:
                        marcaRepositorio.Remove(id);
                        mensaje = "Se borró correctamente " + marcaDataModel.marca; ;
                        break;
                }
            }
            catch (Exception ex)
            {
                if (ex is System.Data.SqlClient.SqlException sqlEx && sqlEx.Number == 2627)
                {
                    mensaje = "el registro ya existe";
                }
                else
                    mensaje = ex.ToString();
            }
            return mensaje;
        }

        public List<MarcaModelo> GetAll()
        {
            var marcaDataModel = marcaRepositorio.GetAll();
            listaMarcas = new List<MarcaModelo>();
            foreach (Marca item in marcaDataModel)
            {
                listaMarcas.Add(new MarcaModelo
                {
                    id = item.id,
                    nombre = item.marca

                }); ;



            }
            return listaMarcas;
        }
        public IEnumerable<MarcaModelo> FindById(string filtro)
        {
            return listaMarcas.FindAll(e => e.nombre.ToUpper().Contains(filtro.ToUpper()));

        }
    }
}