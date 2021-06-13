using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblDiseño1
{
    public interface IRepositorio<T>
    {
        void Add(T elemento);

        bool esVacio();

        bool Existe(T elemento);

        T Get(T elemento);

        List<T> GetAll();

        void Delete(T elemento);

        void Clear();

        void Modificar(T elementoOriginal, T elemento);

    }
}
