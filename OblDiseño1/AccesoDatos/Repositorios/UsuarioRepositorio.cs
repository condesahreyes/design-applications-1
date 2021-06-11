using AccesoDatos.Entidades_Datos;
using OblDiseño1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class UsuarioRepositorio : IRepositorio<Usuario, string>
    {
        private readonly Mapper mapper = new Mapper();

        public void Add(Usuario usuarioDominio)
        {
            using (Contexto contexto = new Contexto())
            {
                if (!Existe(usuarioDominio.Nombre))
                {
                    EntidadUsuario usuarioEntidadAAgregar = mapper.PasarAEntidad(usuarioDominio);
                    contexto.usuarios.Add(usuarioEntidadAAgregar);
                    contexto.SaveChanges();
                }
                else
                    throw new ExepcionObjetosRepetidos("Ya existe un usuario con este nombre");
            }
        }
        public bool esVacio() 
        {
            using (Contexto contexto = new Contexto())
            {
                return (contexto.usuarios.Count() == 0);
            }
        }

        public Usuario Get(string nombre) 
        {
            using (Contexto contexto = new Contexto())
            {
                if (Existe(nombre))
                {
                    EntidadUsuario usuarioEntidad = contexto.usuarios.Find(nombre);
                    Usuario usuarioDominio = mapper.PasarADominio(usuarioEntidad);
                    return usuarioDominio;
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe un usuario con este nombre");
            }
        }

        public EntidadUsuario ObtenerUsuarioDto(Usuario unUsuario)
        {
            IRepositorio<Usuario, string> repositorio = new UsuarioRepositorio();
            using (Contexto contexto = new Contexto())
            {
                if (repositorio.Existe(unUsuario.Nombre))
                {
                    return contexto.usuarios.Find(unUsuario.Nombre);

                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe un usuario con este nombre");
            }

        }


        public List<Usuario> GetAll() 
        {
            using (Contexto contexto = new Contexto()) 
            {
                if (!esVacio())
                {
                    List<Usuario> usuariosADevolver = new List<Usuario>();
                    foreach (var entidadUsuario in contexto.usuarios)
                    {
                        Usuario usuarioDominio = mapper.PasarADominio(entidadUsuario);
                        usuariosADevolver.Add(usuarioDominio);
                    }
                    return usuariosADevolver;
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existen usuarios en el sistema");
            }
             
        }

        public void Delete(string nombre)
        {
            using (Contexto contexto = new Contexto())
            {
                if (Existe(nombre))
                {
                    EntidadUsuario usuarioABorrar = contexto.usuarios.Find(nombre);
                    contexto.usuarios.Remove(usuarioABorrar);
                    contexto.SaveChanges();
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe un usuario con este nombre");
            }
        }

        public void Clear() 
        {
            using (Contexto contexto = new Contexto())
            {
                contexto.usuarios.RemoveRange(contexto.usuarios);
            }
        }

        public bool Existe(string nombre)
        {
            using (Contexto contexto = new Contexto())
            {
                if (contexto.usuarios.Any(usuarioEntidad => usuarioEntidad.Nombre == nombre))
                    return true;
                else
                    return false;
            }
        }

        public List<Categoria> ObtenerMisCategorias(string nombre)
        {
            using (Contexto contexto = new Contexto())
            {
                if (Existe(nombre))
                {
                    List<Categoria> categoriasADevolver = new List<Categoria>();
                    foreach (var entidadCategoria in contexto.categorias)
                    {
                        Categoria categoriaDominio = mapper.PasarADominio(entidadCategoria);
                        categoriasADevolver.Add(categoriaDominio);
                    }
                    return categoriasADevolver;
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe un usuario con este nombre");
            }
        }


    }
}

