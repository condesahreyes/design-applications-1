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

                    ContraseñaRepositorio repositorioContraseña = new ContraseñaRepositorio(this.usuario);
                    repositorioContraseña.Add(credencial.Contraseña);

                    EntidadCredencial entidad = new EntidadCredencial(credencial.NombreUsuario,
                         credencial.NombreSitioApp, credencial.Nota, entidadCategoria.CategoriaId,
                         entidadUsuario.Nombre, contexto.contraseñas.Count());
                    entidad.CredencialId = contexto.credenciales.Count() + 1;


                    int numero = contexto.contraseñas.Count();

                    contexto.credenciales.Add(entidad);
                    contexto.SaveChanges();
                }
            }
        }

        public bool esVacio()
        {
            throw new NotImplementedException();
        }

        public Credencial Get(Credencial credencial) 
        {
            throw new NotImplementedException();
        }

        public List<Credencial> GetAll()
        {
            throw new NotImplementedException();
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
            /*
            using (Contexto contexto = new Contexto())
            {
                if (contexto.credenciales.Any(credencial => credencial. == id))
                    return true;
                else
                    return false;
            */
            return false;
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
