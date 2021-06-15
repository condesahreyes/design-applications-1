using AccesoDatos.Entidades_Datos;
using System.Collections.Generic;
using System.Linq;
using OblDiseño1;

namespace AccesoDatos
{
    public class CategoriaRepositorio : IRepositorio<Categoria>
    {
        private readonly Mapper mapper = new Mapper();
        private Usuario usuario;

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
            throw new System.NotImplementedException();
        }

        public bool Existe(Categoria categoria)
        {
            using (Contexto contexto = new Contexto())
            {
                if (contexto.categorias.Any(cat => cat.NombreCategoria ==
                categoria.Nombre) && contexto.categorias.Any(cat => cat.Usuario.Nombre == this.usuario.Nombre))
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
                    foreach (var cat in contexto.categorias)
                        if (cat.NombreCategoria == categoria.Nombre && cat.UsuarioNombre == this.usuario.Nombre)
                            return mapper.PasarADominio(cat.CategoriaId, this.usuario);
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe una categoria con este nombre");
                return null;
            }
        }

        public EntidadCategoria ObtenerDTOPorInt(int idCategoria)
        {
            using (Contexto contexto = new Contexto())
            {
                EntidadCategoria miEntidad = contexto.categorias.Find(idCategoria);
                if (miEntidad != null)
                    return contexto.categorias.Find(idCategoria);
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe una categoria con este nombre");
            }
        }

        public EntidadCategoria ObtenerDTOPorString(string nombreCategoria)
        {
            Categoria categoria = new Categoria(nombreCategoria);
            using (Contexto contexto = new Contexto())
            {
                if (Existe(categoria))
                {
                    foreach (var cat in contexto.categorias)
                        if (cat.NombreCategoria == categoria.Nombre && cat.UsuarioNombre == this.usuario.Nombre)
                            return cat;
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe una categoria con este nombre");
                return null;
            }
        }

        public List<Categoria> GetAll()
        {
            using (Contexto contexto = new Contexto())
            {
                List<Categoria> categoriasADevolver = new List<Categoria>();
                foreach (var cat in contexto.categorias)
                {
                    Categoria categoriaDominio = mapper.PasarADominio(cat.CategoriaId, this.usuario);
                    if (cat.UsuarioNombre == this.usuario.Nombre)
                        categoriasADevolver.Add(categoriaDominio);
                }

                return categoriasADevolver;
            }
        }

        public void Delete(Categoria categoria) 
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public List<Categoria> ObtenerMisCategorias(string nombre)
        {
            throw new System.NotImplementedException();
        }

        public void Modificar(Categoria original, Categoria aModificar)
        {
            using (Contexto contexto = new Contexto())
            {
                if (!Existe(aModificar))
                {
                    foreach (var cat in contexto.categorias)
                        if (cat.NombreCategoria == original.Nombre && cat.UsuarioNombre == this.usuario.Nombre)
                            cat.NombreCategoria = aModificar.Nombre;
                    contexto.SaveChanges();
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("Ya existe una categoría con ese nombre");
            }
        }
    }
}
