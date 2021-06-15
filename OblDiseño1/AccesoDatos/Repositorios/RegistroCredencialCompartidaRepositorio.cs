using AccesoDatos.Entidades_Datos;
using System.Collections.Generic;
using OblDiseño1.Entidades;
using System.Linq;
using OblDiseño1;
using System;


namespace AccesoDatos.Repositorios
{
    public class RegistroCredencialCompartidaRepositorio : IRepositorioCompartir<Credencial, Usuario>
    {
        private readonly Mapper mapper = new Mapper();

        public Usuario usuarioDuenio;

        public RegistroCredencialCompartidaRepositorio(Usuario usuarioDuenioDominio)
        {
            this.usuarioDuenio = usuarioDuenioDominio;
        }

        public void Add(Credencial aCompartir, Usuario alQueLeComparto)
        {
            using (Contexto contexto = new Contexto())
            {
                if (!Existe(aCompartir, alQueLeComparto))
                {
                    EntidadUsuario entidadUsuarioDuenio = mapper.PasarAEntidad(this.usuarioDuenio);
                    EntidadUsuario entidadUsuarioAlQueSeLeComparte = mapper.PasarAEntidad(alQueLeComparto);
                    EntidadCredencial entidadCredencial = mapper.PasarAEntidadCredencial(aCompartir, this.usuarioDuenio);

                    EntidadRegistroCredencialCompartida registroAPersistir = new EntidadRegistroCredencialCompartida();

                    contexto.credencialesCompartidas.Add()
                    contexto.SaveChanges();
                }
                else
                {

                }


                EntidadContraseña miContraseña = new EntidadContraseña(contraseña.Contrasenia,
                contraseña.NivelSeguridadContrasenia);
                contexto.contraseñas.Add(miContraseña);
                contexto.SaveChanges();
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Delete(Credencial aCompartir, Usuario alQueLeComparto)
        {
            throw new NotImplementedException();
        }

        public bool esVacio()
        {
            throw new NotImplementedException();
        }

        public bool Existe(Credencial aCompartir, Usuario alQueLeComparto)
        {
            using(Contexto contexto = new Contexto())
            {
                EntidadUsuario entidadUsuarioDuenio = mapper.PasarAEntidad(this.usuarioDuenio);
                EntidadUsuario entidadUsuarioAlQueSeLeComparte = mapper.PasarAEntidad(alQueLeComparto);
                EntidadCredencial entidadCredencial = mapper.PasarAEntidadCredencial(aCompartir, this.usuarioDuenio);

                foreach (var registro in contexto.credencialesCompartidas)
                {
                    if (registro.NombreUsuarioQueComparte == entidadUsuarioDuenio.Nombre &&
                        registro.NombreUsuarioAlQueSeLeCompartio == entidadUsuarioAlQueSeLeComparte.Nombre &&
                        registro.CredencialCompartida.NombreSitioApp == entidadCredencial.NombreSitioApp &&
                        registro.CredencialCompartida.NombreUsuario == entidadCredencial.NombreUsuario) 
                    { 
                        return true;
                    }
                }
                return false;
            }
        }

        public Credencial Get(Credencial aCompartir, Usuario alQueLeComparto)
        {
            throw new NotImplementedException();
        }

        public List<Credencial> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
