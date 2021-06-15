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
                    EntidadRegistroCredencialCompartida registroAPersistir = CrearRegistro(aCompartir, alQueLeComparto);

                    contexto.credencialesCompartidas.Add(registroAPersistir);
                    contexto.SaveChanges();
                }
                else
                {
                    throw new ExepcionObjetosRepetidos("Se intento insertar en la base un Registro Contrasenia Compartida que ya existia");
                }
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Delete(Credencial aDejarDeCompartir, Usuario alQueLeDejoDeCompartir)
        {
            using (Contexto contexto = new Contexto())
            {
                if (Existe(aDejarDeCompartir, alQueLeDejoDeCompartir))
                {
                    EntidadRegistroCredencialCompartida registroADejarDeCompartir = CrearRegistro(aDejarDeCompartir, alQueLeDejoDeCompartir);

                    foreach (var registro in contexto.credencialesCompartidas)
                    {
                        if(VerificarQueSonElMismoRegistro(registroADejarDeCompartir, registro))
                        {
                            contexto.credencialesCompartidas.Remove(registro);
                            contexto.SaveChanges();
                            break;
                        }
                    }               
                }
                else
                {
                    throw new ExepcionObjetosRepetidos("Se intento eliminar en la base un Registro Contrasenia Compartida que no existia");
                }
            }
        }

        public bool esVacio()
        {
            using(Contexto contexto = new Contexto())
            {
                return contexto.credencialesCompartidas.Count() == 0;
            }
        }

        public bool Existe(Credencial unaCredencial, Usuario unUsuario)
        {
            using(Contexto contexto = new Contexto())
            {
                EntidadRegistroCredencialCompartida registroAVerificarExistencia = CrearRegistro(unaCredencial, unUsuario);

                foreach (var registro in contexto.credencialesCompartidas)
                {
                    if (VerificarQueSonElMismoRegistro(registroAVerificarExistencia, registro)) 
                    { 
                        return true;
                    }
                }
                return false;
            }
        }


        public List<Credencial> ObtenerTodasLasCredencialesQueComparto()
        {
            using(Contexto contexto = new Contexto())
            {
                List<Credencial> credencialesADevolver = new List<Credencial>();
                foreach (var entidadRegistroContraseniaCompartida in contexto.credencialesCompartidas)
                {
                    if (entidadRegistroContraseniaCompartida.NombreUsuarioQueComparte == this.usuarioDuenio.Nombre)
                    {
                        Credencial credencialDeDominio = mapper.PasarADominio(
                            entidadRegistroContraseniaCompartida.CredencialCompartida, this.usuarioDuenio);

                        credencialesADevolver.Add(credencialDeDominio);
                    }

                }
                return credencialesADevolver;
            }
        }


        public List<Credencial> ObtenerTodasLasCredencialesQueMeComparten()
        {
            using (Contexto contexto = new Contexto())
            {
                List<Credencial> credencialesADevolver = new List<Credencial>();
                foreach (var entidadRegistroContraseniaCompartida in contexto.credencialesCompartidas)
                {
                    if (entidadRegistroContraseniaCompartida.NombreUsuarioAlQueSeLeCompartio == this.usuarioDuenio.Nombre)
                    {
                        Credencial credencialDeDominio = mapper.PasarADominio(
                            entidadRegistroContraseniaCompartida.CredencialCompartida, this.usuarioDuenio);

                        credencialesADevolver.Add(credencialDeDominio);
                    }

                }
                return credencialesADevolver;
            }
        }


        private bool VerificarQueSonElMismoRegistro(EntidadRegistroCredencialCompartida registroADejarDeCompartir,
            EntidadRegistroCredencialCompartida registro)
        {
            if (registro.CredencialCompartidaId == registroADejarDeCompartir.CredencialCompartidaId &&
                registro.NombreUsuarioAlQueSeLeCompartio == registroADejarDeCompartir.NombreUsuarioAlQueSeLeCompartio &&
                registro.NombreUsuarioQueComparte == registroADejarDeCompartir.NombreUsuarioQueComparte)
                return true;
            return false;
        }

        private EntidadRegistroCredencialCompartida CrearRegistro(Credencial aCompartir, Usuario alQueLeComparto)
        {
            EntidadUsuario entidadUsuarioDuenio = mapper.PasarAEntidad(this.usuarioDuenio);
            EntidadUsuario entidadUsuarioAlQueSeLeComparte = mapper.PasarAEntidad(alQueLeComparto);
            EntidadCredencial entidadCredencial = mapper.PasarAEntidadCredencial(aCompartir, this.usuarioDuenio);

            CredencialRepositorio credenRepo = new CredencialRepositorio(this.usuarioDuenio);


            return new EntidadRegistroCredencialCompartida(entidadUsuarioDuenio.Nombre, entidadUsuarioAlQueSeLeComparte.Nombre,
                credenRepo.ObtenerId(aCompartir));
        }
    }
}
