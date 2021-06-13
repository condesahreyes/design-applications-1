using AccesoDatos.Entidades_Datos;
using System.Collections.Generic;
using System.Linq;
using OblDiseño1;
using System;

namespace AccesoDatos
{
    public class UsuarioRepositorio : IRepositorio<Usuario>
    {
        private readonly Mapper mapper = new Mapper();

        public void Add(Usuario usuarioDominio)
        {
            using (Contexto contexto = new Contexto())
            {
                if (!Existe(usuarioDominio))
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
            throw new NotImplementedException();
        }

        public Usuario Get(Usuario usuario) 
        {
            throw new NotImplementedException();
        }

        public EntidadUsuario ObtenerUsuarioDto(Usuario unUsuario)
        {
            IRepositorio<Usuario> repositorio = new UsuarioRepositorio();
            using (Contexto contexto = new Contexto())
            {
                if (repositorio.Existe(unUsuario))
                {
                    return contexto.usuarios.Find(unUsuario.Nombre);

                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe un usuario con este nombre");
            }

        }


        public List<Usuario> GetAll() 
        {
            throw new NotImplementedException();
        }

        public void Delete(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Clear() 
        {
            throw new NotImplementedException();
        }

        public bool Existe(Usuario usuario)
        {
            using (Contexto contexto = new Contexto())
            {
                if (contexto.usuarios.Any(usuarioEntidad => usuarioEntidad.Nombre == usuario.Nombre))
                    return true;
                else
                    return false;
            }
        }

        public List<Categoria> ObtenerMisCategorias(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Usuario elemento)
        {
            throw new NotImplementedException();
        }
    }
}

