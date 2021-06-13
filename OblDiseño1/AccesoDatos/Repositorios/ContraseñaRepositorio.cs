using AccesoDatos.Entidades_Datos;
using OblDiseño1;
using OblDiseño1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ContraseñaRepositorio : IRepositorio<Contraseña>
    {
        private readonly Mapper mapper = new Mapper();

        public Usuario usuario;
        public ContraseñaRepositorio(Usuario usuarioDueñoDominio)
        {
            this.usuario = usuarioDueñoDominio;
        }
        public void Add(Contraseña contraseña)
        {
            using (Contexto contexto = new Contexto())
            {
                EntidadContraseña miContraseña = new EntidadContraseña(contraseña.Contrasenia,
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
                    Contraseña contraseñaDominio = mapper.PasarADominioContraseña(contraseñaEntidad.ContraseniaId, usuario);
                    return contraseñaDominio;
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
                contraseñaABuscar.Contrasenia = contraseñaAModificar.Contrasenia;
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
