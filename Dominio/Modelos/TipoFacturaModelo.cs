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
    public class TipoFacturaModelo
    {
        private int id;
        private string tipo;

        private readonly ITipoFacturaRepositorio tipoFacturaRepositorio;
        public EntityState State { private get; set; }

        private List<TipoFacturaModelo> listaTipoFacturas;

        //PROPIEDADES/MODELO DE VISTAS/ VALIDAR DATOS
        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "El campo nombre no puede quedar vacio")]
        // [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="El nombre solo admite letras")]
        //[StringLength(maximumLength:50, MinimumLength =3,ErrorMessage ="El mínimo de caracteres para el nombre es 3")]
        public string Tipo { get => tipo; set => tipo = value; }

        public TipoFacturaModelo()
        {
            tipoFacturaRepositorio = new TipoFacturaRepositorio();

        }
        public string GuardarCambios()
        {
            string mensaje = null;
            try
            {
                var tipoFacDataModel = new TipoFactura
                {
                    Id = id,
                    Tipo = tipo
                };


                switch (State)
                {
                    case EntityState.Agregado:
                        tipoFacturaRepositorio.Add(tipoFacDataModel);
                        mensaje = "Se agregó correctamente " + tipoFacDataModel.Tipo;
                        break;
                    case EntityState.Modificado:
                        tipoFacturaRepositorio.Edit(tipoFacDataModel);
                        mensaje = "Se editó correctamente " + tipoFacDataModel.Tipo;
                        break;
                    case EntityState.Borrado:
                        tipoFacturaRepositorio.Remove(id);
                        mensaje = "Se borró correctamente " + tipoFacDataModel.Tipo; ;
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

        public List<TipoFacturaModelo> GetAll()
        {
            var tipoFacDataModel = tipoFacturaRepositorio.GetAll();
            listaTipoFacturas = new List<TipoFacturaModelo>();
            foreach (TipoFactura item in tipoFacDataModel)
            {
                listaTipoFacturas.Add(new TipoFacturaModelo
                {
                    id = item.Id,
                    tipo = item.Tipo

                }); ;



            }
            return listaTipoFacturas;
        }
        public IEnumerable<TipoFacturaModelo> FindById(string filtro)
        {
            return listaTipoFacturas.FindAll(e => e.Tipo.ToUpper().Contains(filtro.ToUpper()));

        }
    }
}