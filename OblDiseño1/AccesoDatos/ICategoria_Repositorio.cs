using AccesoDatos.Entidades_Datos;
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
        private readonly Mapper mapper = new Mapper();
        public void Add(Categoria categoriaDominio) 
        {
            using (Contexto contexto = new Contexto())
            {
                if (contexto.categorias.Any(cat => cat.Nombre == categoriaDominio.Nombre))
                    throw new Exepcion_ObjetosRepetidos("Ya existe una categoria con este nombre");
                else
                {
                    Entidad_Categoria categoriaAlAgregar = mapper.PasarAEntidad(categoriaDominio);
                    contexto.categorias.Add(categoriaAlAgregar);
                    contexto.SaveChanges();
                }
                    
            }
        }

        public bool esVacio() 
        {
            using (Contexto contexto = new Contexto())
            {
                return (contexto.categorias.Count() == 0);
            }
        }

        public Categoria Get(int id) { return null; }

        public IEnumerable<Categoria> GetAll() { return null; }

        public void Delete(int id) { }

        public void Clear() { }
    }
}
