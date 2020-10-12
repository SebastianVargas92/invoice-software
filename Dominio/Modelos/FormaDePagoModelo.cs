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
    public class FormaDePagoModelo
    {
        private int id;
        private string tipo;

        private readonly IFormaDePagoRepositorio formaDePagoRepositorio;
        public EntityState State { private get; set; }

        private List<FormaDePagoModelo> listaFormasDePago;

        //PROPIEDADES/MODELO DE VISTAS/ VALIDAR DATOS
        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "El campo nombre no puede quedar vacio")]
        // [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="El nombre solo admite letras")]
        //[StringLength(maximumLength:50, MinimumLength =3,ErrorMessage ="El mínimo de caracteres para el nombre es 3")]
        public string Tipo { get => tipo; set => tipo = value; }

        public FormaDePagoModelo()
        {
            formaDePagoRepositorio = new FormaDePagoRepositorio();

        }
        public string GuardarCambios()
        {
            string mensaje = null;
            try
            {
                var formaDataModel = new FormaDePago
                {
                    Id = id,
                    Tipo = tipo
                };


                switch (State)
                {
                    case EntityState.Agregado:
                        formaDePagoRepositorio.Add(formaDataModel);
                        mensaje = "Se agregó correctamente " + formaDataModel.Tipo;
                        break;
                    case EntityState.Modificado:
                        formaDePagoRepositorio.Edit(formaDataModel);
                        mensaje = "Se editó correctamente " + formaDataModel.Tipo;
                        break;
                    case EntityState.Borrado:
                        formaDePagoRepositorio.Remove(id);
                        mensaje = "Se borró correctamente " + formaDataModel.Tipo; ;
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

        public List<FormaDePagoModelo> GetAll()
        {
            var formaDataModel = formaDePagoRepositorio.GetAll();
            listaFormasDePago = new List<FormaDePagoModelo>();
            foreach (FormaDePago item in formaDataModel)
            {
                listaFormasDePago.Add(new FormaDePagoModelo
                {
                    id = item.Id,
                    tipo = item.Tipo

                }); ;



            }
            return listaFormasDePago;
        }
        public IEnumerable<FormaDePagoModelo> FindById(string filtro)
        {
            return listaFormasDePago.FindAll(e => e.Tipo.ToUpper().Contains(filtro.ToUpper()));

        }
    }
}