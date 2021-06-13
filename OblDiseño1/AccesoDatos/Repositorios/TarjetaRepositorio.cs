﻿using AccesoDatos.Entidades_Datos;
using OblDiseño1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class TarjetaRepositorio : IRepositorio<Tarjeta>
    {
        private readonly Mapper mapper = new Mapper();

        public Usuario usuario;
        public TarjetaRepositorio(Usuario usuarioDueñoDominio)
        {
            this.usuario = usuarioDueñoDominio;
        }
        public void Add(Tarjeta tarjetaAgregar)
        {
            using (Contexto contexto = new Contexto())
            {
                if (Existe(tarjetaAgregar))
                    throw new ExepcionObjetosRepetidos("Ya existe una tarjeta con este numero");
                else
                {
                    UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
                    CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio(this.usuario);

                    int idCategoria = categoriaRepositorio.ObtenerDTOPorString(tarjetaAgregar.Categoria.Nombre).CategoriaId;

                    EntidadTarjeta tarjeta = new EntidadTarjeta(tarjetaAgregar.NotaOpcional, tarjetaAgregar.Nombre,
                        tarjetaAgregar.Tipo, tarjetaAgregar.Numero, tarjetaAgregar.CodigoSeguridad,
                        tarjetaAgregar.FechaVencimiento, idCategoria, this.usuario.Nombre);

                    contexto.tarjetas.Add(tarjeta);
                    contexto.SaveChanges();
                }
            }
        }

        public bool esVacio() 
        {
            throw new NotImplementedException();
        }

        public Tarjeta Get(Tarjeta tarjeta) 
        {
            throw new NotImplementedException();
        }

        public List<Tarjeta> GetAll() 
        {
            throw new NotImplementedException();
        }

        public void Delete(Tarjeta tarjeta)
        {
            using (Contexto contexto = new Contexto())
            {
                if (Existe(tarjeta))
                {
                    foreach(var tarjetaRecorredora in contexto.tarjetas)
                        if(tarjetaRecorredora.Numero==tarjeta.Numero && 
                            tarjetaRecorredora.UsuarioGestorNombre == this.usuario.Nombre)
                                contexto.tarjetas.Remove(tarjetaRecorredora);
                    contexto.SaveChanges();
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe una tarjeta con este numero");
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Existe(Tarjeta tarjeta)
        {
            using (Contexto contexto = new Contexto())
            {
                if (contexto.tarjetas.Any(tarjetaEntidad => tarjetaEntidad.Numero == tarjeta.Numero) &&
                    contexto.tarjetas.Any(tarjetaEntidad => tarjetaEntidad.UsuarioGestorNombre == this.usuario.Nombre))
                    return true;
                else
                    return false;
            }
        }

        public List<Categoria> ObtenerMisCategorias(string nombre)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Tarjeta elemento)
        {
            throw new NotImplementedException();
        }
    }
}
