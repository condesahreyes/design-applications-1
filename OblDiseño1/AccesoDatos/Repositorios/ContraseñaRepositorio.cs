using AccesoDatos.Entidades_Datos;
using System.Collections.Generic;
using OblDiseño1.Entidades;
using System.Linq;
using OblDiseño1;
using System;
using OblDiseño1.Manejadores;

namespace AccesoDatos
{
    public class ContraseñaRepositorio : IRepositorio<Contraseña>
    {
        private readonly Mapper mapper = new Mapper();
        private Encriptador encriptador = new Encriptador();
        public Usuario usuario;

        public ContraseñaRepositorio(Usuario usuarioDueñoDominio)
        {
            this.usuario = usuarioDueñoDominio;
        }
        public void Add(Contraseña contraseña)
        {
            using (Contexto contexto = new Contexto())
            {
                string contraseniaEncriptada = encriptador.Encriptar(contraseña.Contrasenia, encriptador.ObtenerLlaveHardcodeada());
                EntidadContraseña miContraseña = new EntidadContraseña(contraseniaEncriptada,
                contraseña.NivelSeguridadContrasenia);
                contexto.contraseñas.Add(miContraseña);
                contexto.SaveChanges();
            }
        }

        public void AgregarCredencialId(int contraseñaId)
        {
            using (Contexto contexto = new Contexto())
            {
                foreach (var contraseña in contexto.contraseñas)
                {
                    if(contraseña.ContraseniaId == contraseñaId)
                        contraseña.CredencialId= contexto.credenciales.Max(x => x.CredencialId);
                }
                contexto.SaveChanges();
            }
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Contraseña contraseña)
        {
            throw new System.NotImplementedException();
        }

        public bool esVacio()
        {
            throw new System.NotImplementedException();
        }

        public bool Existe(Contraseña contraseña)
        {
            using (Contexto contexto = new Contexto())
            {
                if (contexto.contraseñas.Any(contra => contra.Contrasenia == contraseña.Contrasenia))
                    return true;
                else
                    return false;
            }
        }

        public Contraseña Get(Contraseña contraseña)
        {
            using (Contexto contexto = new Contexto())
            {
                if (Existe(contraseña))
                {
                    EntidadContraseña contraseñaEntidad = contexto.contraseñas.Find(contraseña.Contrasenia);
                    return mapper.PasarADominioContraseña(contraseñaEntidad.ContraseniaId, usuario);
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe esta contraseña asociada en el mismo");
            }
        }

        public EntidadContraseña ObtenerDto(int  id)
        {
            using (Contexto contexto = new Contexto())
            {
                foreach (var contraseña in contexto.contraseñas)
                    if (contraseña.ContraseniaId == id)
                        return contraseña;
            }
            return null;
        }

        public List<Contraseña> GetAll()
        {
            using (Contexto contexto = new Contexto())
            {
                List<Contraseña> contraseñasADevolver = new List<Contraseña>();
                foreach (var contra in contexto.contraseñas)
                {
                    Contraseña contraseñaDominio = mapper.PasarADominioContraseña(contra.ContraseniaId, usuario);
                    contraseñasADevolver.Add(contraseñaDominio);
                }

                return contraseñasADevolver;
            }
        }

        public void ModificarConEntidad(int contraseñaId, Contraseña contraseñaAModificar)
        {
            using (Contexto contexto = new Contexto())
            {
                EntidadContraseña contraseñaABuscar = contexto.contraseñas.Find(contraseñaId);
                contraseñaABuscar.Contrasenia = encriptador.Encriptar(contraseñaAModificar.Contrasenia, encriptador.ObtenerLlaveHardcodeada());
                contexto.SaveChanges();
            }
        }

        public List<Categoria> ObtenerMisCategorias(string nombre)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Contraseña elementoOriginal, Contraseña elemento)
        {
            throw new NotImplementedException();
        }
    }
}
