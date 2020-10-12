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
    public class ComprasModelo
    {
        private int id;
        private int puntoDeVenta;
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




        public TipoFacturaModelo TipoFactura { get; set; }
        public ProveedorModelo Proveedor { get; set; }
        public UsuarioModelo Usuario { get; set; }
        public FormaDePagoModelo FormaDePago { get; set; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public bool Cancelada { get => cancelada; set => cancelada = value; }



        private readonly IComprasRepositorio comprasRepositorio;
        public EntityState State { private get; set; }

        private List<ComprasModelo> listaCompras;


        //PROPIEDADES/MODELO DE VISTAS/ VALIDAR DATOS
        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "El campo Punto de Venta no puede quedar vacio")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Solo se admiten numeros en Punto de Venta")]
        // [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="El nombre solo admite letras")]
        //[StringLength(maximumLength:50, MinimumLength =3,ErrorMessage ="El mínimo de caracteres para el nombre es 3")]
        public int PuntoDeVenta { get => puntoDeVenta; set => puntoDeVenta = value; }

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


        public ComprasModelo()
        {
            comprasRepositorio = new ComprasRepositorio();

        }


        public string GuardarCambios()
        {
            string mensaje = null;
            try
            {
                var comprasDataModel = new Compras
                {


                    TipoFactura = new TipoFactura(),
                    Proveedor = new Proveedor(),
                    Usuario = new Usuario(),
                    FormaDePago = new FormaDePago(),

                    Id = id,
                    PuntoDeVenta = puntoDeVenta,
                    Numero = numero,
                    Fecha = fecha,
                    Neto = neto,
                    Iva = iva,
                    Total = total,
                    Descuento = descuento,
                    Cancelada = cancelada
                };
                comprasDataModel.TipoFactura.Id = TipoFactura.Id;
                comprasDataModel.Proveedor.Id = Proveedor.Id;
                comprasDataModel.Usuario.Id = Usuario.Id;
                comprasDataModel.FormaDePago.Id = FormaDePago.Id;


                switch (State)
                {
                    case EntityState.Agregado:
                        comprasRepositorio.Add(comprasDataModel);
                        mensaje = "Se agregó correctamente " + comprasDataModel.Numero;
                        break;
                    case EntityState.Modificado:
                        comprasRepositorio.Edit(comprasDataModel);
                        mensaje = "Se editó correctamente " + comprasDataModel.Numero;
                        break;
                    case EntityState.Borrado:
                        comprasRepositorio.Remove(id);
                        mensaje = "Se borró correctamente " + comprasDataModel.Numero; ;
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
        public List<ComprasModelo> GetAll()
        {
            var comprasDataModel = comprasRepositorio.GetAll();
            listaCompras = new List<ComprasModelo>();



            foreach (Compras item in comprasDataModel)
            {

                var tipoFacTemp = new TipoFacturaModelo();
                var provTemp = new ProveedorModelo();
                var usuTemp = new UsuarioModelo();
                var formaPagoTemp = new FormaDePagoModelo();

                tipoFacTemp.Id = item.TipoFactura.Id;
                tipoFacTemp.Tipo = item.TipoFactura.Tipo;
                provTemp.Id = item.Proveedor.Id;
                provTemp.RazonSocial = item.Proveedor.RazonSocial;
                usuTemp.Id = item.Usuario.Id;
                usuTemp.Nombre = item.Usuario.Nombre;
                formaPagoTemp.Id = item.FormaDePago.Id;
                formaPagoTemp.Tipo = item.FormaDePago.Tipo;

                listaCompras.Add(new ComprasModelo
                {
                    id = item.Id,
                    puntoDeVenta = item.PuntoDeVenta,
                    numero = item.Numero,
                    TipoFactura = tipoFacTemp,
                    fecha = item.Fecha,
                    Proveedor = provTemp,
                    Usuario = usuTemp,
                    neto = item.Neto,
                    iva = item.Iva,
                    total = item.Total,
                    descuento = item.Descuento,
                    FormaDePago = formaPagoTemp,
                    cancelada = item.Cancelada,

                }); ;



            }
            return listaCompras;
        }

        public IEnumerable<ComprasModelo> FindById(string filtro)
        {
            // return listaCompras.FindAll(e => e.Cliente.ToUpper().Contains(filtro.ToUpper()) || e.descripcion.ToUpper().Contains(filtro.ToUpper()));
            return null;
        }

        public ComprasModelo LastCompra(List<ComprasModelo> lista)
        {
            if (lista.Count != 0)

                return lista.Last();

            else
            {
                var fac = new ComprasModelo();
                fac.Id = 0;
               
                return fac;

            }

        }


    }
}
