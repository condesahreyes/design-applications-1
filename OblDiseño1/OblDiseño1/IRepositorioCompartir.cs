using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblDiseño1
{
    public interface IRepositorioCompartir<T,K>
    {
        void Add(T elemento, K elemento2);

        bool esVacio();

        bool Existe(T elemento, K elemento2);

        //T Get(T elemento, K elemento2);

        List<T> ObtenerTodasLasCredencialesQueComparto();

        List<T> ObtenerTodasLasCredencialesQueMeComparten();

        List<T> ObtenerCredencialesQueMeComparteUnUsuario(K elemento);

        List<K> ObtenerTodosLosUsuariosALosQueCompartoUnaCredencial(T elemento);

        List<K> ObtenerUsuariosQueMeCompartenAlgunaCredencial();

        void Delete(T elemento, K elemento2);

        void Clear();


        //void Modificar(T elementoOriginal, T elemento, K elemento2);

    }
}

