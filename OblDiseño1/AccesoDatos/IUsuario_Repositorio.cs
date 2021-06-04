using OblDiseño1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class IUsuario_Repositorio : IRepositorio<Usuario, int>
    {
        public void Add(Usuario dato) { }

        public bool esVacio() { return false; }

        public Usuario Get(int id) { return null; }

        public IEnumerable<Usuario> GetAll() { return null; }

        public void Delete(int id) { }

        public void Clear() { }
    }
}
