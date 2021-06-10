using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblDiseño1
{
    public interface IRepositorio <T,K>
    {
        void Add(T elemento);

        bool esVacio();

        bool Existe(K id);

        T Get(K id);

        List<T> GetAll();

        void Delete(K id);

        void Clear();

        List<Categoria> ObtenerMisCategorias(string nombre);


    }
}
