using AccesoDatos.Entidades_Datos;
using OblDiseño1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CredencialRepositorio : IRepositorio<Credencial, int>
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
                    /*
                    ControladorObtener obtener = new ControladorObtener(this.usuario);

                    EntidadCategoria entidadCtaegoria = obtener.Cat
                    EntidadUsuario entidadUsuario = obtener.ObtenerUsuarioDto(this.usuario);
                    EntidadContraseña miContraseña = new EntidadContraseña(credencial.ObtenerContraseña, 
                        credencial.ObtenerNivelSeguridad, credencial);
                    EntidadCredencial entidad = new EntidadCredencial(credencial.NombreUsuario, 
                        miContraseña, credencial.NombreSitioApp, credencial.Nota, , entidadUsuario);


                    EntidadCredencial entidadCredencialAAgregar = mapper.PasarAEntidad(credencialDominio);
                    entidadCredencialAAgregar.UsuarioGestor = this.usuario;
                    contexto.credenciales.Add(entidadCredencialAAgregar);
                    contexto.SaveChanges();
                    */
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

        public Credencial Get(int id) 
        {
            using (Contexto contexto = new Contexto())
            {
                if (Existe(id))
                {
                    EntidadCredencial credencialEntidad = contexto.credenciales.Find(id);
                    Credencial credencialDominio = mapper.PasarADominio(credencialEntidad);
                    return credencialDominio;
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe una credencial con este id");
            }
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
                        Credencial credencialDominio = mapper.PasarADominio(entidadCredencial);
                        credencialesADevolver.Add(credencialDominio);
                    }
                    return credencialesADevolver;
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No hay credenciales guardadas en el sistema");
            }
        }


        public void Delete(int id) 
        {
            using (Contexto contexto = new Contexto())
            {
                if (Existe(id))
                {
                    EntidadCredencial credencialEntidadARemover = contexto.credenciales.Find(id);
                    contexto.credenciales.Remove(credencialEntidadARemover);
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe una credencial con este id");
            }
        }

        public void Clear() 
        {
            using (Contexto contexto = new Contexto())
            {
                contexto.credenciales.RemoveRange(contexto.credenciales);
            }
        }

        public bool Existe(int id)
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
