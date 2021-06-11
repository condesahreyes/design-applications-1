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
    public class ContraseñaRepositorio : IRepositorio<Contraseña, string>
    {
        private readonly Mapper mapper = new Mapper();

        public EntidadUsuario usuario;
        public ContraseñaRepositorio(Usuario usuarioDueñoDominio)
        {
            this.usuario = mapper.PasarAEntidad(usuarioDueñoDominio);
        }
        public void Add(Contraseña contraseña)
        {/*
            using (Contexto contexto = new Contexto())
            {
                EntidadContraseña contraseñaEntidad = mapper.PasarAEntidad(contraseña);
                contraseñaEntidad.CredencialUsuario. = this.usuario;
                contexto.contraseñas.Add(contraseñaEntidad);
                contexto.SaveChanges();
            }*/
        }

        public void Clear()
        {
            using (Contexto contexto = new Contexto())
            {
                contexto.contraseñas.RemoveRange(contexto.contraseñas);
            }
        }

        public void Delete(string contraseña)
        {
            using (Contexto contexto = new Contexto())
            {
                if (Existe(contraseña))
                {
                    Contraseña ContraseñaABorrarDominio = Get(contraseña);
                    EntidadContraseña ContraseñaABorrarEntidad = mapper.PasarAEntidad(ContraseñaABorrarDominio);
                    contexto.contraseñas.Remove(ContraseñaABorrarEntidad);
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe esta contraseña en el sistema");
            }
        }

        public bool esVacio()
        {
            using (Contexto contexto = new Contexto())
                return (contexto.contraseñas.Count() == 0);
        }

        public bool Existe(string contraseña)
        {
            using (Contexto contexto = new Contexto())
            {
                if (contexto.contraseñas.Any(contra => contra.Contrasenia == contraseña))
                    return true;
                else
                    return false;
            }
        }

        public Contraseña Get(string contraseña)
        {
            using (Contexto contexto = new Contexto())
            {
                if (Existe(contraseña))
                {
                    EntidadContraseña contraseñaEntidad = contexto.contraseñas.Find(contraseña);
                    Contraseña contraseñaDominio = mapper.PasarADominio(contraseñaEntidad);
                    return contraseñaDominio;
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe esta contraseña asociada en el mismo");
            }
        }

        public List<Contraseña> GetAll()
        {
            using (Contexto contexto = new Contexto())
            {
                List<Contraseña> contraseñasADevolver = new List<Contraseña>();
                foreach (var contra in contexto.contraseñas)
                {
                    Contraseña contraseñaDominio = mapper.PasarADominio(contra);
                    contraseñasADevolver.Add(contraseñaDominio);
                }

                return contraseñasADevolver;
            }
        }

        public List<Categoria> ObtenerMisCategorias(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
