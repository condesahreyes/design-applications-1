using AccesoDatos.Entidades_Datos;
using OblDiseño1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CategoriaRepositorio : IRepositorio<Categoria, string > 
    {
        private readonly Mapper mapper = new Mapper();
        public EntidadUsuario usuario;
        public CategoriaRepositorio(Usuario usuarioDueñoDominio)
        {
            this.usuario = mapper.PasarAEntidad(usuarioDueñoDominio);
        }
        public void Add(Categoria categoriaDominio) 
        {
            using (Contexto contexto = new Contexto())
            {
                if (Existe(categoriaDominio.Nombre))
                    throw new ExepcionObjetosRepetidos("Ya existe una categoria con este nombre");
                else
                {
                    EntidadCategoria categoriaAlAgregar = mapper.PasarAEntidad(categoriaDominio);
                    categoriaAlAgregar.usuarioDueño = this.usuario;
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

        public bool Existe(string nombre)
        {
            using (Contexto contexto = new Contexto())
            {
                if (contexto.categorias.Any(cat => cat.NombreCategoria == nombre))
                    return true;
                else
                    return false;
            }
        }

        public Categoria Get(string nombre) 
        {
            using (Contexto contexto = new Contexto())
            {
                if (Existe(nombre))
                {
                    EntidadCategoria categoriaEntidad = contexto.categorias.Find(nombre);
                    Categoria categoriaDominio = mapper.PasarADominio(categoriaEntidad);
                    return categoriaDominio;
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe una categoria con este nombre");

            }
        }

        public List<Categoria> GetAll()
        {
            using (Contexto contexto = new Contexto())
            {
                List<Categoria> categoriasADevolver = new List<Categoria>();
                foreach (var cat in contexto.categorias)
                {
                    Categoria categoriaDominio = mapper.PasarADominio(cat);
                    categoriasADevolver.Add(categoriaDominio);
                }

                return categoriasADevolver;
            }
        }

        public void Delete(string nombre) 
        {
            using (Contexto contexto = new Contexto())
            {
                if (Existe(nombre))
                {
                    EntidadCategoria categoriaARemover = contexto.categorias.Find(nombre);
                    contexto.categorias.Remove(categoriaARemover);
                    contexto.SaveChanges();
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe una categoria con este nombre");
            }
        }

        public void Clear()
        {
            using (Contexto contexto = new Contexto())
            {
                contexto.categorias.RemoveRange(contexto.categorias);
                contexto.SaveChanges();
            }
        }

    }
}
