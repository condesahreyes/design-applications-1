using OblDiseño1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ITarjeta_Repositorio : IRepositorio<Tarjeta, int>
    {
        public void Add(Tarjeta dato) { }

        public bool esVacio() { return false; }

        public Tarjeta Get(int id) { return null; }

        public IEnumerable<Tarjeta> GetAll() { return null; }

        public void Delete(int id) { }

        public void Clear() { }
    }
}
