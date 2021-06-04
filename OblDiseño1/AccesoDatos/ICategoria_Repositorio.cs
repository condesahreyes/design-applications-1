using OblDiseño1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ICategoria_Repositorio : IRepositorio<Categoria, int > 
    {
        public void Add(Categoria dato) { }

        public bool esVacio() { return false; }

        public Categoria Get(int id) { return null; }

        public IEnumerable<Categoria> GetAll() { return null; }

        public void Delete(int id) { }

        public void Clear() { }
    }
}
