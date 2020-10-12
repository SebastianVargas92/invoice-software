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
using System.Security.Cryptography;

namespace Dominio.Modelos
{
    public class FacturaModelo
    {
        private int id;
        private int numero;
        private readonly TipoFactura tipoFactura;
        private DateTime fecha;
        private readonly Cliente cliente;
        private readonly Usuario usuario;
        private double neto;
        private double iva;
        private double total;
        private double descuento;
        private readonly FormaDePago formaDePago;
        private bool cancelada;
        private List<FacturaDetalleModelo> detallesFactura;



        public TipoFacturaModelo TipoFactura { get; set; }
        public ClienteModelo Cliente { get; set; }
        public UsuarioModelo Usuario { get; set; }
        public FormaDePagoModelo FormaDePago { get; set; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public bool Cancelada { get => cancelada; set => cancelada = value; }



        private readonly IFacturaRepositorio facturaRepositorio;
        public EntityState State { private get; set; }

        private List<FacturaModelo> listaFacturas;


        //PROPIEDADES/MODELO DE VISTAS/ VALIDAR DATOS
        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "El campo numero no puede quedar vacio")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Solo se admiten numeros en Numero")]
        // [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="El nombre solo admite letras")]
        //[StringLength(maximumLength:50, MinimumLength =3,ErrorMessage ="El mínimo de caracteres para el nombre es 3")]
        public int Numero { get => numero; set => numero = value; }


        [Required(ErrorMessage = "El campo neto no puede quedar vacio")]
        //[RegularExpression("([0-9]+)", ErrorMessage = "Solo se admiten numeros en Neto")]
        public double Neto { get => neto; set => neto = value; }


        [Required(ErrorMessage = "El campo Iva no puede quedar vacio")]
        //[RegularExpression("([0-9]+)", ErrorMessage = "Solo se admiten numeros en Iva")]
        public double Iva { get => iva; set => iva = value; }

        //[RegularExpression("([0-9]+)", ErrorMessage = "Solo se admiten numeros en total")]
        public double Total { get => total; set => total = value; }

        [Required(ErrorMessage = "El campo precio no puede quedar vacio")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Solo se admiten numeros en Precio")]
        public double Descuento { get => descuento; set => descuento = value; }
        public List<FacturaDetalleModelo> DetallesFactura { get => detallesFactura; set => detallesFactura = value; }

        public FacturaModelo()
        {
            facturaRepositorio = new FacturaRepositorio();

        }


        public string GuardarCambios()
        {
            string mensaje = null;
            try
            {
                var facturaDataModel = new Factura
                {


                    TipoFactura = new TipoFactura(),
                    Cliente = new Cliente(),
                    Usuario = new Usuario(),
                    FormaDePago = new FormaDePago(),

                    Id = id,
                    Numero = numero,
                    Fecha = fecha,
                    Neto = neto,
                    Iva = iva,
                    Total = total,
                    Descuento = descuento,
                    Cancelada = cancelada
                };
                facturaDataModel.TipoFactura.Id = TipoFactura.Id;
                facturaDataModel.Cliente.Id = Cliente.Id;
                facturaDataModel.Usuario.Id = Usuario.Id;
                facturaDataModel.FormaDePago.Id = FormaDePago.Id;


                switch (State)
                {
                    case EntityState.Agregado:
                        facturaRepositorio.Add(facturaDataModel);
                        mensaje = "Se agregó correctamente " + facturaDataModel.Numero;
                        break;
                    case EntityState.Modificado:
                        facturaRepositorio.Edit(facturaDataModel);
                        mensaje = "Se editó correctamente " + facturaDataModel.Numero;
                        break;
                    case EntityState.Borrado:
                        facturaRepositorio.Remove(id);
                        mensaje = "Se borró correctamente " + facturaDataModel.Numero; ;
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

        private List<FacturaDetalleModelo> getDetallesFactura(int id)
        {
            FacturaDetalleModelo det = new FacturaDetalleModelo();
            var Fact = new FacturaModelo();
            det.Factura = Fact;
            var detalleLista = det.GetAll();
            var detLista = new List<FacturaDetalleModelo>();

            foreach (var d in detalleLista)
            {
                if (id == d.Factura.Id)
                {
                    detLista.Add(d);
                }
            }


            return detLista;
        }
        public List<FacturaModelo> GetAll()
        {
            var facturaDataModel = facturaRepositorio.GetAll();
            listaFacturas = new List<FacturaModelo>();



            foreach (Factura item in facturaDataModel)
            {

                var tipoFacTemp = new TipoFacturaModelo();
                var cliTemp = new ClienteModelo();
                var usuTemp = new UsuarioModelo();
                var formaPagoTemp = new FormaDePagoModelo();

                tipoFacTemp.Id = item.TipoFactura.Id;
                tipoFacTemp.Tipo = item.TipoFactura.Tipo;
                cliTemp.Id = item.Cliente.Id;
                cliTemp.Nombre = item.Cliente.Nombre;
                usuTemp.Id = item.Usuario.Id;
                usuTemp.Nombre = item.Usuario.Nombre;
                formaPagoTemp.Id = item.FormaDePago.Id;
                formaPagoTemp.Tipo = item.FormaDePago.Tipo;

                listaFacturas.Add(new FacturaModelo
                {
                    id = item.Id,
                    numero = item.Numero,
                    TipoFactura = tipoFacTemp,
                    fecha = item.Fecha,
                    Cliente = cliTemp,
                    Usuario = usuTemp,
                    neto = item.Neto,
                    iva = item.Iva,
                    total = item.Total,
                    descuento = item.Descuento,
                    FormaDePago = formaPagoTemp,
                    cancelada = item.Cancelada,
                    detallesFactura = getDetallesFactura(item.Id)

                });



            }
            return listaFacturas;
        }

        public IEnumerable<FacturaModelo> FindById(string filtro)
        {
            return listaFacturas.FindAll(e => e.Cliente.Nombre.ToUpper().Contains(filtro.ToUpper())
            || e.Numero.ToString().Contains(filtro.ToUpper())
            //|| e.TipoFactura.Tipo.ToString().ToUpper().Contains(filtro.ToUpper()) nulo
            //|| e.formaDePago.Tipo.ToString().ToUpper().Contains(filtro.ToUpper()) nulo
            );

        }

        public FacturaModelo lastFactura(List<FacturaModelo> lista)
        {
            if (lista.Count != 0)
            {

                return lista.Last();

            }
            else
            {
                var fac = new FacturaModelo();
                fac.Id = 0;
                fac.Numero = 0;
                return fac;

            }

        }

        public FacturaModelo GetFacturaById(List<FacturaModelo> lista, int id)
        {

            var fac = new FacturaModelo();
            foreach (var item in lista)
            {
                if (item.Id == id)
                {
                    fac = item;
                    break;
                }
            }
            return fac;
        }


    }

}

