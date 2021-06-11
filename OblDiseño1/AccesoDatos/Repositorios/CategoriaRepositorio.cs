using AccesoDatos.Entidades_Datos;
using System.Collections.Generic;
using System.Linq;
using OblDiseño1;

namespace AccesoDatos
{
    public class CategoriaRepositorio : IRepositorio<Categoria>
    {
        private readonly Mapper mapper = new Mapper();
        Usuario usuario;
        public CategoriaRepositorio(Usuario usuarioDueñoDominio)
        {
            this.usuario = usuarioDueñoDominio;
        }
        public void Add(Categoria categoriaDominio) 
        {
            using (Contexto contexto = new Contexto())
            {
                if (Existe(categoriaDominio))
                    throw new ExepcionObjetosRepetidos("Ya existe una categoria con este nombre");
                else
                {
                    UsuarioRepositorio repositorioUsuario = new UsuarioRepositorio();

                    EntidadUsuario entidadUsuario = repositorioUsuario.ObtenerUsuarioDto(this.usuario);
                    EntidadCategoria categoriaAlAgregar = new EntidadCategoria(categoriaDominio.Nombre, entidadUsuario); 

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

        public bool Existe(Categoria categoria)
        {
            using (Contexto contexto = new Contexto())
            {
                if (contexto.categorias.Any(cat => cat.NombreCategoria == categoria.Nombre) && contexto.categorias.Any(cat => cat.Usuario.Nombre == this.usuario.Nombre))
                    return true;
                else
                    return false;
            }
        }

        public Categoria Get(Categoria categoria) 
        {
            using (Contexto contexto = new Contexto())
            {
                if (Existe(categoria))
                {
                    EntidadCategoria categoriaEntidad = contexto.categorias.Find(categoria.Nombre, this.usuario);
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
                    if(cat.UsuarioNombre==this.usuario.Nombre)
                        categoriasADevolver.Add(categoriaDominio);
                }

                return categoriasADevolver;
            }
        }

        public void Delete(Categoria categoria) 
        {
            using (Contexto contexto = new Contexto())
            {
                if (Existe(categoria))
                {
                    EntidadCategoria categoriaARemover = contexto.categorias.Find(categoria.Nombre);
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

        public List<Categoria> ObtenerMisCategorias(string nombre)
        {
            throw new System.NotImplementedException();
        }

        public void Modificar(Categoria elemento)
        {
            throw new System.NotImplementedException();
        }
    }
}
