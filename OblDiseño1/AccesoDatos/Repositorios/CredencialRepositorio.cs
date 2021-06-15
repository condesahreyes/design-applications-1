using AccesoDatos.Entidades_Datos;
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
                    int contraseñaID = contexto.contraseñas.Max(x => x.ContraseniaId);
                    entidad.ContraseniaId = contraseñaID;

                    contexto.credenciales.Add(entidad);
                    contexto.SaveChanges();
                    repositorioContraseña.AgregarCredencialId(contraseñaID);
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
            }
            return null;
        }

        public void Delete(Credencial credencial)
        {
            using (Contexto contexto = new Contexto())
            {
                if (Existe(credencial))
                {
                    foreach (var credencialRecorredora in contexto.credenciales)
                        if (credencialRecorredora.NombreUsuario == credencial.NombreUsuario &&
                            credencialRecorredora.UsuarioGestorNombre == this.usuario.Nombre && 
                            credencialRecorredora.NombreSitioApp == credencial.NombreSitioApp)
                            contexto.credenciales.Remove(credencialRecorredora);

                    contexto.SaveChanges();
                }
                else
                    throw new ExepcionIntentoDeObtencionDeObjetoInexistente("No existe dicha credencial");
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Existe(Credencial credencial)
        {
            using (Contexto contexto = new Contexto())
            {
                foreach (var credencialRecorredora in contexto.credenciales)
                    if (credencialRecorredora.NombreUsuario == credencial.NombreUsuario &&
                        credencialRecorredora.UsuarioGestorNombre == this.usuario.Nombre &&
                        credencialRecorredora.NombreSitioApp == credencial.NombreSitioApp)
                        return true;
            }
            return false;
        }

        public List<Categoria> ObtenerMisCategorias(string nombre)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Credencial credencialOriginal, Credencial credencialAModificar)
        {
            CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio(this.usuario);
            ContraseñaRepositorio contraseñaRepositorio = new ContraseñaRepositorio(this.usuario);
            using (Contexto contexto = new Contexto())
            {
                if (!Existe(credencialAModificar) || (credencialOriginal.NombreUsuario == credencialAModificar.NombreUsuario
                    && credencialOriginal.NombreSitioApp == credencialAModificar.NombreSitioApp))
                {
                    foreach (var entidadCredencial in contexto.credenciales)
                        if ((credencialOriginal.NombreUsuario == entidadCredencial.NombreUsuario) &&
                            (credencialOriginal.NombreSitioApp == entidadCredencial.NombreSitioApp))
                        {
                            entidadCredencial.NombreUsuario = credencialAModificar.NombreUsuario;
                            entidadCredencial.NombreSitioApp = credencialAModificar.NombreSitioApp;
                            entidadCredencial.Nota = credencialAModificar.Nota;
                            entidadCredencial.TipoSitioOApp = credencialAModificar.TipoSitioOApp;

                            contraseñaRepositorio.ModificarConEntidad(entidadCredencial.ContraseniaId, 
                                credencialAModificar.Contraseña);
                            EntidadCategoria nuevaCategoria = categoriaRepositorio.ObtenerDTOPorString
                                (credencialAModificar.Categoria.Nombre);
                            entidadCredencial.IdCategoria = nuevaCategoria.CategoriaId;
                            break;
                        }
                    contexto.SaveChanges();
                }
                else
                    throw new ExepcionObjetosRepetidos("Ya existe una contraseña para este nombre de usuario y nombre de sitio");
            }
        }

        public int ObtenerId(Credencial credencial)
        {
            using (Contexto contexto = new Contexto())
            {
                foreach (var unaCredencial in contexto.credenciales)
                {
                    if (unaCredencial.NombreSitioApp == credencial.NombreSitioApp &&
                        unaCredencial.NombreUsuario == credencial.NombreUsuario)
                    {
                        return unaCredencial.CredencialId;
                    }      
                }
                string mensajeExepcion = "La credencial de <<NombreSitioApp = " + credencial.NombreSitioApp 
                    + ">> y <<NombreUsuario = " + credencial.NombreUsuario + ">>";
                throw new ExepcionIntentoDeObtencionDeObjetoInexistente(mensajeExepcion);
            }
        }
    }
}




