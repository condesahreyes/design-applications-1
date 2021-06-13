﻿using AccesoDatos.Entidades_Datos;
using OblDiseño1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CredencialRepositorio : IRepositorio<Credencial>
    {
        private readonly Mapper mapper = new Mapper();
        private Usuario usuario;

        public CredencialRepositorio(Usuario usuarioDueñoDominio)
        {
            this.usuario = usuarioDueñoDominio;
        }

        public void Add(Credencial credencial)
        {
            using (Contexto contexto = new Contexto())
            {
                if (contexto.credenciales.Any(c => (c.NombreUsuario == credencial.NombreUsuario) &&
                (c.NombreSitioApp == credencial.NombreSitioApp)))
                    throw new ExepcionObjetosRepetidos("Ya existe una credencial con para este nombre de usuario y sitio");
                else
                {
                    UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
                    CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio(this.usuario);

                    EntidadCategoria entidadCategoria = categoriaRepositorio.ObtenerDTOPorString(credencial.Categoria.Nombre);
                    EntidadUsuario entidadUsuario = usuarioRepositorio.ObtenerUsuarioDto(this.usuario);

                    EntidadCredencial entidad = new EntidadCredencial(credencial.NombreUsuario,
                         credencial.NombreSitioApp, credencial.Nota, entidadCategoria.CategoriaId,
                         entidadUsuario.Nombre, 0);

                    ContraseñaRepositorio repositorioContraseña = new ContraseñaRepositorio(this.usuario);
                    repositorioContraseña.Add(credencial.Contraseña);

                    entidad.ContraseniaId = contexto.contraseñas.Max(x => x.ContraseniaId);

                    int idCredencial = 1;

                    if (contexto.credenciales.Count() > 0)
                        idCredencial = contexto.credenciales.Max(x => x.CredencialId) + 1;

                    entidad.CredencialId = idCredencial;

                    contexto.credenciales.Add(entidad);
                    contexto.SaveChanges();
                }
            }
        }

        public bool esVacio()
        {
            using (Contexto contexto = new Contexto())
            {
                return (contexto.credenciales.Count() == 0);
            }
        }

        public Credencial Get(Credencial credencial)
        {
            using (Contexto contexto = new Contexto())
            {
                if (Existe(credencial))
                {
                    foreach (var credencialRecorre in contexto.credenciales)
                    {
                        if (credencialRecorre.UsuarioGestorNombre == usuario.Nombre &&
                            credencialRecorre.NombreSitioApp == credencial.NombreSitioApp
                            && credencialRecorre.NombreUsuario == credencial.NombreUsuario)
                            return mapper.PasarADominio(credencialRecorre, this.usuario);
                    }
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe una credencial con este id");
            }
            return null;
        }

        public List<Credencial> GetAll()
        {
            using (Contexto contexto = new Contexto())
            {
                List<Credencial> credencialesADevolver = new List<Credencial>();
                if (!esVacio())
                {
                    foreach (var entidadCredencial in contexto.credenciales)
                    {
                        Credencial credencialDominio = mapper.PasarADominio(entidadCredencial, usuario);
                        credencialesADevolver.Add(credencialDominio);
                    }
                    return credencialesADevolver;
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No hay credenciales guardadas en el sistema");
            }
        }

        public void Delete(Credencial credencial)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Existe(Credencial credencial)
        {
            using (Contexto contexto = new Contexto())
            {
                foreach (var credencialRecorre in contexto.credenciales)
                {
                    if (credencialRecorre.UsuarioGestorNombre == usuario.Nombre &&
                        credencialRecorre.NombreSitioApp == credencial.NombreSitioApp
                        && credencialRecorre.NombreUsuario == credencial.NombreUsuario)
                        return true;
                }
                return false;
            }
        }

            public List<Categoria> ObtenerMisCategorias(string nombre)
            {
                throw new NotImplementedException();
            }

            public void Modificar(Credencial elemento)
            {
                throw new NotImplementedException();
            }
        }
    }
