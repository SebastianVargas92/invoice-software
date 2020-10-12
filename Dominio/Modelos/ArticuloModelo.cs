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
    public class ArticuloModelo
    {
        private int id;
        private string codigo;
        private string descripcion;
        private double costo;
        private double rentabilidad;
        private double precio;
        private double lista2;
        private double lista3;
        private int puntoDePedido;
        private double cantMax;
        private double stock;
        private DateTime ultimaModificacion;
        private bool baja;
        private double impInterno;

       

        public GrupoModelo Grupo { get; set; }
        public IvaModelo IvaEntity { get; set; }
        public MarcaModelo Marca { get; set; }
        public ProveedorModelo Proveedor { get; set; }
        public DateTime UltimaModificacion { get => ultimaModificacion; set => ultimaModificacion = value; }
        public bool Baja { get => baja; set => baja = value; }

       

        private readonly IArticuloRepositorio articuloRepositorio;
        public EntityState State { private get; set; }

        private List<ArticuloModelo> listaArticulos;


        //PROPIEDADES/MODELO DE VISTAS/ VALIDAR DATOS
        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage ="El campo código no puede quedar vacio")]
       // [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="El nombre solo admite letras")]
        //[StringLength(maximumLength:50, MinimumLength =3,ErrorMessage ="El mínimo de caracteres para el nombre es 3")]
        public string Codigo { get => codigo; set => codigo = value; }


        [Required(ErrorMessage = "El campo descripcion no puede quedar vacio")]
        public string Descripcion { get => descripcion; set => descripcion = value; }


        [Required(ErrorMessage = "El campo costo no puede quedar vacio")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Solo se admiten numeros en Precio")]
        public double Costo { get => costo; set => costo = value; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Solo se admiten numeros en rentabilidad")]
        public double Rentabilidad { get => rentabilidad; set => rentabilidad = value; }

        [Required(ErrorMessage = "El campo precio no puede quedar vacio")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Solo se admiten numeros en Precio")]
        public double Precio { get => precio; set => precio = value; }
        public double Lista2 { get => lista2; set => lista2 = value; }
        public double Lista3 { get => lista3; set => lista3 = value; }
        

        [Required(ErrorMessage = "El campo punto de pedido no puede quedar vacio")]
        [RegularExpression("([0-9]+)", ErrorMessage ="Solo se admiten numeros en Punto de Pedido")]
        public int PuntoDePedido { get => puntoDePedido; set => puntoDePedido = value; }

        [Required(ErrorMessage = "El campo stock no puede quedar vacio")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Solo se admiten numeros en Stock")]
        public double CantMax { get => cantMax; set => cantMax = value; }

        [Required(ErrorMessage = "El campo stock no puede quedar vacio")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Solo se admiten numeros en Stock")]
        public double Stock { get => stock; set => stock = value; }


        [RegularExpression("([0-9]+)", ErrorMessage = "Solo se admiten numeros en Impuesto Interno")]
        public double ImpInterno { get => impInterno; set => impInterno = value; }



        public ArticuloModelo()
        {
            articuloRepositorio = new ArticuloRepositorio();
                      
        }

        
        public string GuardarCambios()
        {
            string mensaje=null;
            try
            {
                var articuloDataModel = new Articulo
                {


                    IvaEntity = new Iva(),
                    Grupo = new Grupo(),
                    Marca = new Marca(),
                    Proveedor = new Proveedor(),

                    Id = id,
                    Codigo = codigo,
                    Descripcion = descripcion,
                    Costo = costo,
                    Rentabilidad = rentabilidad,
                    Precio = precio,
                    Lista2 = lista2,
                    Lista3 = lista3
                };
                articuloDataModel.IvaEntity.id = IvaEntity.Id;
                articuloDataModel.PuntoDePedido = puntoDePedido;
                articuloDataModel.CantMax = cantMax;
                articuloDataModel.Stock = stock;
                articuloDataModel.Grupo.id = Grupo.Id;
                articuloDataModel.Marca.id = Marca.Id;
                articuloDataModel.Proveedor.Id = Proveedor.Id;
                articuloDataModel.UltimaModificacion = ultimaModificacion;
                articuloDataModel.Baja = baja;
                articuloDataModel.ImpInterno = impInterno;

                switch (State)
                {
                    case EntityState.Agregado:
                        articuloRepositorio.Add(articuloDataModel);
                        mensaje = "Se agregó correctamente " + articuloDataModel.Descripcion;
                        break;
                    case EntityState.Modificado:
                        articuloRepositorio.Edit(articuloDataModel);
                        mensaje = "Se editó correctamente " + articuloDataModel.Descripcion;
                        break;
                    case EntityState.Borrado:
                        articuloRepositorio.Remove(id);
                        mensaje = "Se borró correctamente "+ articuloDataModel.Descripcion; ;
                        break;
                }
            }
            catch(Exception ex)
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
        public List<ArticuloModelo> GetAll()
        {
            var articuloDataModel = articuloRepositorio.GetAll();
            listaArticulos = new List<ArticuloModelo>();

            

            foreach (Articulo item in articuloDataModel)
            {

                var ivaTemp = new IvaModelo();
                var grupTemp = new GrupoModelo();
                var proveTemp = new ProveedorModelo();
                var marcaTemp = new MarcaModelo();

                ivaTemp.Id = item.IvaEntity.id;
                ivaTemp.Valor = item.IvaEntity.valor;
                grupTemp.Id = item.Grupo.id;
                grupTemp.Nombre = item.Grupo.grupo;
                marcaTemp.Id = item.Marca.id;
                marcaTemp.Nombre = item.Marca.marca;
                proveTemp.Id = item.Proveedor.Id;
                proveTemp.RazonSocial = item.Proveedor.RazonSocial;

                listaArticulos.Add(new ArticuloModelo
                {
                    id = item.Id,
                    codigo = item.Codigo,
                    descripcion = item.Descripcion,
                    costo = item.Costo,
                    rentabilidad = item.Rentabilidad,
                    precio = item.Precio,
                    lista2 = item.Lista2,
                    lista3 = item.Lista3,
                    IvaEntity = ivaTemp,
                    puntoDePedido = item.PuntoDePedido,
                    cantMax=item.CantMax,
                    stock = item.Stock,
                    Grupo = grupTemp,
                    Marca = marcaTemp,
                    Proveedor = proveTemp,
                    ultimaModificacion = item.UltimaModificacion,
                    baja = item.Baja,
                    impInterno = item.ImpInterno
                }); ;
                
                
               
            }
            return listaArticulos;
        }

        public IEnumerable<ArticuloModelo>FindById(string filtro)
        {
            return listaArticulos.FindAll(e => e.codigo.ToUpper().Contains(filtro.ToUpper()) || e.descripcion.ToUpper().Contains(filtro.ToUpper()));
          
        }

        public ArticuloModelo FindArticulo(string filtro)
        {
            return listaArticulos.Find(e => e.codigo.ToUpper().Contains(filtro.ToUpper()) || e.descripcion.ToUpper().Contains(filtro.ToUpper()));
        }

       
    }
}
