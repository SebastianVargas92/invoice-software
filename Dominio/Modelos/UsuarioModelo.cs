using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoADatos;
using AccesoADatos.Entidades;
using AccesoADatos.Repositorios;
using Dominio.Objetos;
using System.ComponentModel.DataAnnotations;
using System.Data;
using AccesoADatos.Contratos;

namespace Dominio.Modelos
{
    public class UsuarioModelo
    {
        private int id;
        private string loginName;
        private string nombre;
        private string password;
        private string email;

          


        private IUsuarioRepositorio usuarioRepositorio;
        public EntityState State { private get; set; }

        private List<UsuarioModelo> listaUsuarios;


        //PROPIEDADES/MODELO DE VISTAS/ VALIDAR DATOS
        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "El campo Nombre de inicio no puede quedar vacio")]
        // [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="El nombre solo admite letras")]
        //[StringLength(maximumLength:50, MinimumLength =3,ErrorMessage ="El mínimo de caracteres para el nombre es 3")]
        public string LoginName { get => loginName; set => loginName = value; }

        [Required(ErrorMessage = "El campo nombre no puede quedar vacio")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Required(ErrorMessage = "El campo Password no puede quedar vacio")]
        public string Password { get => password; set => password = value; }
        [Required(ErrorMessage = "El campo Email no puede quedar vacio")]
        public string Email { get => email; set => email = value; }
        

        public UsuarioModelo()
        {
            usuarioRepositorio = new UsuarioRepositorio();

            

        }

         
        public bool LoginUser(string loginName, string password)
        {
            return usuarioRepositorio.Login(loginName, password);
        }

        public string GuardarCambios()
        {
            string mensaje = null;
            try
            {
                var usuarioDataModel = new Usuario
                {
                    Id = id,
                    LoginName = loginName,
                    Nombre = nombre,
                    Password = password,
                    Emal = email
                };


                switch (State)
                {
                    case EntityState.Agregado:
                        usuarioRepositorio.Add(usuarioDataModel);
                        mensaje = "Se agregó correctamente " + usuarioDataModel.Nombre;
                        break;
                    case EntityState.Modificado:
                        usuarioRepositorio.Edit(usuarioDataModel);
                        mensaje = "Se editó correctamente " + usuarioDataModel.Nombre;
                        break;
                    case EntityState.Borrado:
                        usuarioRepositorio.Remove(id);
                        mensaje = "Se borró correctamente " + usuarioDataModel.Nombre; ;
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
        public List<UsuarioModelo> GetAll()
        {
            var usuarioDataModel = usuarioRepositorio.GetAll();

            listaUsuarios = new List<UsuarioModelo>();


            foreach (Usuario item in usuarioDataModel)
            {

                listaUsuarios.Add(new UsuarioModelo
                {
                    id = item.Id,
                    loginName = item.LoginName,
                    nombre = item.Nombre,
                    password = item.Password,
                    email = item.Emal
                }); ;



            }
            return listaUsuarios;
        }

        public IEnumerable<UsuarioModelo> FindById(string filtro)
        {
            return listaUsuarios.FindAll(e => e.nombre.ToUpper().Contains(filtro.ToUpper()) || e.loginName.ToUpper().Contains(filtro.ToUpper()));

        }


    }
}
