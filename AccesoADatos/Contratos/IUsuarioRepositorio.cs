using AccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.Contratos
{
    public interface IUsuarioRepositorio : IRepositorioGenerico<Usuario>
    {
        bool Login(string loginName, string password);
    }
}
