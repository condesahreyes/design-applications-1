using AccesoDatos.Entidades_Datos;
using System.Collections.Generic;
using OblDiseño1.Manejadores;
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
            using (Contexto contexto = new Contexto())
            {
                if (Existe(usuario))
                {
                    EntidadUsuario usuarioEntidad = contexto.usuarios.Find(usuario.Nombre);
                    return mapper.PasarADominio(usuarioEntidad);
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe un usuario con este nombre");
            }
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
            using (Contexto contexto = new Contexto())
            {
                if (contexto.usuarios.Count() > 0)
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
                    return null;
            }
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
            using (Contexto contexto = new Contexto())
            {
                if (Existe(usuario))
                {
                    List<Categoria> categoriasADevolver = new List<Categoria>();
                    foreach (var entidadCategoria in contexto.categorias)
                    {
                        Categoria categoriaDominio = mapper.PasarADominio(entidadCategoria.CategoriaId, usuario);
                        categoriasADevolver.Add(categoriaDominio);
                    }
                    return categoriasADevolver;
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe un usuario con este nombre");
            }
        }

        public void Modificar(Usuario usuarioOriginal, Usuario usuario)
        {
            Encriptador encriptador = new Encriptador();
            string llave = encriptador.ObtenerLlaveHardcodeada();
            using (Contexto contexto = new Contexto())
            {
                if (Existe(usuarioOriginal))
                {
                    foreach (var usuarioContexto in contexto.usuarios)
                        if (usuarioContexto.Nombre == usuarioOriginal.Nombre)
                        {
                            usuarioContexto.Contrasenia  = encriptador.Encriptar(usuario.Contrasenia, llave);
                        } 
                    contexto.SaveChanges();
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe una categoria con " +
                        "este nombre");
            }
        }
    }
}

