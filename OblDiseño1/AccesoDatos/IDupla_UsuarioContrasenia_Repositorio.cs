using OblDiseño1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class IDupla_UsuarioContrasenia_Repositorio : IRepositorio<Dupla_UsuarioContrasenia, int>
    {
        public void Add(Dupla_UsuarioContrasenia dato) { }

        public bool esVacio() { return false; }

        public Dupla_UsuarioContrasenia Get(int id) { return null; }

        public IEnumerable<Dupla_UsuarioContrasenia> GetAll() { return null; }

        public void Delete(int id) { }

        public void Clear() { }
    }
}
