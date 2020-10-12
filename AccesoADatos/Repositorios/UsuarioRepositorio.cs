using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AccesoADatos.Contratos;
using AccesoADatos.Entidades;
using CapaComun.Cache;

namespace AccesoADatos.Repositorios
{
    public class UsuarioRepositorio : RepositorioMaestro, IUsuarioRepositorio
    {
        private readonly string selectAll;
        private readonly string insert;
        private readonly string update;
        private readonly string delete;
       // private string login;


        public UsuarioRepositorio()
        {

            selectAll = "select * from USUARIOS";
            insert = "insert into USUARIOS values(@loginName,@nombre,@password,@email)";
            update = "update USUARIOS set loginName=@loginName, nombre=@nombre, password=@password,email=@emal where idUsuario=@idUsuario";
            delete = "delete from USUARIOS where idUsuario=@idUsuario";
           // login = "select * from USUARIOS where loginName=@loginName and password=@password";
            
        }

        public bool Login(string loginName, string password)
        {
            //parametros = new List<SqlParameter>();
            //parametros.Add(new SqlParameter("@loginName", loginName));
            //parametros.Add(new SqlParameter("@password", password));
            //ME DA ERROR Must declare the scalar variable "@loginName".


            var reader = ExecuteReader("select * from USUARIOS where loginName='"+loginName+"' and password='"+password+"'");
            if (reader.Rows.Count != 0)
            {
                foreach (DataRow item in reader.Rows)
                {
                    UserLoginCache.IdUser = Convert.ToInt32(item[0]);
                    UserLoginCache.NombreLog = item[1].ToString();
                    UserLoginCache.Nombre = item[2].ToString();
                    UserLoginCache.Password = item[3].ToString();
                    UserLoginCache.Email = item[4].ToString();
                }
                    return true;
            }
            else
                return false;
        }

       
        public int Add(Usuario entity)
        {
            parametros = new List<SqlParameter>
            {
                new SqlParameter("@loginName", entity.LoginName),
                new SqlParameter("@nombre", entity.Nombre),
                new SqlParameter("@password", entity.Password),
                new SqlParameter("@email", entity.Emal)
            };


            return ExecuteNonQuery(insert);
        }

        public int Edit(Usuario entity)
        {
            parametros = new List<SqlParameter>
            {
                new SqlParameter("@idusuario", entity.Id),
                new SqlParameter("@loginName", entity.LoginName),
                new SqlParameter("@nombre", entity.Nombre),
                new SqlParameter("@password", entity.Password),
                new SqlParameter("@email", entity.Emal)
            };

            return ExecuteNonQuery(update);
        }

        public IEnumerable<Usuario> GetAll()
        {
            {
                var tableResult = ExecuteReader(selectAll);
                var listaUsuarios = new List<Usuario>();
                foreach (DataRow item in tableResult.Rows)
                {

                   listaUsuarios.Add(new Usuario
                    {
                        Id = Convert.ToInt32(item[0]),
                        LoginName = item[1].ToString(),
                        Nombre = item[2].ToString(),
                        Password = item[3].ToString(),
                        Emal = item[4].ToString()
                       
                    });
                }
                return listaUsuarios;
            }
        }

        public int Remove(int id)
        {
            parametros = new List<SqlParameter>
            {
                new SqlParameter("@idUsuario", id)
            };
            return ExecuteNonQuery(delete);
        }
    }
}