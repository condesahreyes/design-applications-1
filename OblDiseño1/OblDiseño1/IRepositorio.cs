using OblDiseño1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
        public interface IRepositorio<T, K>
        {
            void Add(T dato);

            bool esVacio();

            T Get(K id);

            IEnumerable<T> GetAll();

            void Delete(K id);

            void Clear();
        }

        //public interface ICategoria_Repositorio : IRepositorio<Categoria, int>;


}
