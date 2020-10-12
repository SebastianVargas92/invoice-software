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
using System.Web.UI.WebControls;

namespace Dominio.Modelos
{
    public class ClienteModelo
    {
        private int id;
        private string nombre;
        private string cuit;
        private string telefono;
        private string email;
        private string contacto;
        private double saldo;

        public ResponsabilidadModelo Responsabilidad { get; set; }
        public DomicilioModelo Domicilio { get; set; }

        private readonly IClienteRepositorio clienteRepositorio;
        public EntityState State { private get; set; }

        private List<ClienteModelo> listaClientes;
        

        //PROPIEDADES/MODELO DE VISTAS/ VALIDAR DATOS
        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "El campo Nombre no puede quedar vacio")]
        // [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="El nombre solo admite letras")]
        //[StringLength(maximumLength:50, MinimumLength =3,ErrorMessage ="El mínimo de caracteres para el nombre es 3")]
        public string Nombre { get => nombre; set => nombre = value; }

        [Required(ErrorMessage = "El campo Cuit no puede quedar vacio")]        
        // [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="El nombre solo admite letras")]
        [StringLength(maximumLength:13, MinimumLength=11,ErrorMessage ="Debe contener máximo 13 carácteres con guiones u once sin guiones")]
        public string Cuit { get => cuit; set => cuit = value; }


        [Required(ErrorMessage = "El campo telefono no puede quedar vacio")]
        [RegularExpression("^[0-9]{1,10}$", ErrorMessage = "Número de teléfono inválido")]
        //[StringLength(maximumLength:50, MinimumLength =3,ErrorMessage ="El mínimo de caracteres para el nombre es 3")]
        public string Telefono { get => telefono; set => telefono = value; }

        [Required(ErrorMessage = "El campo Email no puede quedar vacio")]
        [RegularExpression(@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
     + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$", ErrorMessage ="Dirección de correo inválida")]        
        //[StringLength(maximumLength:50, MinimumLength =3,ErrorMessage ="El mínimo de caracteres para el nombre es 3")]
        public string Email { get => email; set => email = value; }

        [Required(ErrorMessage = "El campo Contacto no puede quedar vacio")]
        // [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="El nombre solo admite letras")]
        //[StringLength(maximumLength:50, MinimumLength =3,ErrorMessage ="El mínimo de caracteres para el nombre es 3")]
        public string Contacto { get => contacto; set => contacto = value; }



        public ClienteModelo()
        {
            clienteRepositorio = new ClienteRepositorio();

        }

        
       
       

        public bool CuitValidator(string cuit)
        {
            
            //if (cuit.Length != 13) throw new ExcepcionPersonalizada("Cuit debe contener 11 dígitos");
            bool rv = false;
            int verificador;
            int resultado = 0;
            string cuit_nro;
            if (cuit.Contains("-"))
            {
                cuit_nro = cuit.Replace("-", string.Empty);
            }
            else
            {
                cuit_nro = cuit;
            }
            
            string codes = "6789456789";
            if (long.TryParse(cuit_nro, out long cuit_long))
            {
                verificador = int.Parse(cuit_nro[cuit_nro.Length - 1].ToString());
                int x = 0;
                while (x < 10)
                {
                    int digitoValidador = int.Parse(codes.Substring((x), 1));
                    int digito = int.Parse(cuit_nro.Substring((x), 1));
                    int digitoValidacion = digitoValidador * digito;
                    resultado += digitoValidacion;
                    x++;
                }
                resultado %= 11;
                rv = (resultado == verificador);
                if (resultado != verificador)
                {
                    throw new ExcepcionPersonalizada("Cuit inválido");
                }
            }
            return rv;
        }    
   
       
      
        public string GuardarCambios()
        {
            string mensaje = null;
            try
            {
                var clienteDataModel = new Cliente
                {
                    Responsabilidad = new Responsabilidad(),
                    Domicilio = new Domicilio(),

                    Id = id,
                    Nombre = nombre,
                    Cuit = cuit
                };
                clienteDataModel.Domicilio.Id = Domicilio.id;
                clienteDataModel.Responsabilidad.id = Responsabilidad.Id;
                clienteDataModel.Telefono = telefono;
                clienteDataModel.Email = email;
                clienteDataModel.Contacto = contacto;
                clienteDataModel.Saldo = saldo;


                switch (State)
                {
                    case EntityState.Agregado:
                        clienteRepositorio.Add(clienteDataModel);
                        mensaje = "Se agregó correctamente " + clienteDataModel.Nombre;
                        break;
                    case EntityState.Modificado:
                        clienteRepositorio.Edit(clienteDataModel);
                        mensaje = "Se editó correctamente " + clienteDataModel.Nombre;
                        break;
                    case EntityState.Borrado:
                        clienteRepositorio.Remove(id);
                        mensaje = "Se borró correctamente " + clienteDataModel.Nombre; ;
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

        public List<ClienteModelo> GetAll()
        {
            var clienterDataModel = clienteRepositorio.GetAll();
            listaClientes = new List<ClienteModelo>();
            foreach (Cliente item in clienterDataModel)
            {

                var respTemp = new ResponsabilidadModelo();
                var domicilioTemp = new DomicilioModelo();
                var locaTemp = new LocalidadModelo();
                var provTemp = new ProvinciaModelo();



                domicilioTemp.id = item.Domicilio.Id;
                domicilioTemp.calle = item.Domicilio.Calle;
                domicilioTemp.idLocalidad = item.Domicilio.IdLocalidad;
                locaTemp.Id = item.Domicilio.Localidad.Id;
                locaTemp.Nombre = item.Domicilio.Localidad.Nombre;
                locaTemp.IdProv = item.Domicilio.Localidad.IdProv;
                provTemp.Id = item.Domicilio.Localidad.Provincia.Id;
                provTemp.Nombre = item.Domicilio.Localidad.Provincia.Nombre;
                domicilioTemp.localidad = locaTemp;
                domicilioTemp.localidad.Provincia = provTemp;



                respTemp.Id = item.Responsabilidad.id;
                respTemp.Nombre = item.Responsabilidad.nombre;

                listaClientes.Add(new ClienteModelo
                {
                    id = item.Id,
                    nombre = item.Nombre,
                    cuit = item.Cuit,
                    Domicilio = domicilioTemp,
                    Responsabilidad = respTemp,
                    telefono = item.Telefono,
                    email = item.Email,
                    contacto = item.Contacto,
                    saldo = item.Saldo

                }); ;

            }
            return listaClientes;
        }
        public IEnumerable<ClienteModelo> FindById(string filtro)
        {
            return listaClientes.FindAll(e => e.Nombre.ToUpper().Contains(filtro.ToUpper()));

        }

        public ClienteModelo FindCliente(string filtro)
        {
            return listaClientes.Find(e => e.Nombre.ToUpper().Contains(filtro.ToUpper()) || e.Cuit.ToUpper().Contains(filtro.ToUpper()));
        }
    }
}

