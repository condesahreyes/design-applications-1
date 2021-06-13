using AccesoDatos.Entidades_Datos;
using OblDiseño1.Entidades;
using OblDiseño1;

namespace AccesoDatos
{
    public class Mapper
    {
        public EntidadCategoria PasarAEntidad(Categoria categoriaDominio, Usuario usuario)
        {
            EntidadCategoria categoriaDto = new EntidadCategoria();
            CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio(usuario);
            return categoriaRepositorio.ObtenerDTOPorString(categoriaDominio.Nombre);
        }

        public Categoria PasarADominio(int idCategoria, Usuario usuario)
        {
            Categoria categoriaDominio = new Categoria();
            CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio(usuario);

            categoriaDominio.Nombre = categoriaRepositorio.ObtenerDTOPorInt(idCategoria).NombreCategoria;

            return categoriaDominio;
        }

        public EntidadContraseña PasarAEntidadContraseña(Contraseña contraseña, Usuario usuario)
        {
            EntidadContraseña contraseñaEntidad = new EntidadContraseña();
            ContraseñaRepositorio contraseñaRepositorio = new ContraseñaRepositorio(usuario);
            return null;
        }

        public Contraseña PasarADominioContraseña(int idContraseña, Usuario usuario)
        {
            EntidadContraseña contraseñaEntidad;
            ContraseñaRepositorio contraseñaRepositorio = new ContraseñaRepositorio(usuario);
            contraseñaEntidad=contraseñaRepositorio.ObtenerDto(idContraseña);
            return new Contraseña(contraseñaEntidad.Contrasenia);

        }

        public EntidadCredencial PasarAEntidadCredencial(Credencial credencialDominio, Usuario usuario)
        {
            EntidadCredencial credencialEntidad = new EntidadCredencial();
            credencialEntidad.Categoria = PasarAEntidad(credencialDominio.Categoria, usuario);
            //credencialEntidad.Contrasenia = PasarAEntidad(credencialDominio.Contraseña);
            credencialEntidad.FechaUltimaModificacion = credencialDominio.FechaUltimaModificacion;
            credencialEntidad.NombreSitioApp = credencialDominio.NombreSitioApp;
            credencialEntidad.NombreUsuario = credencialDominio.NombreUsuario;
            credencialEntidad.Nota = credencialDominio.Nota;
            credencialEntidad.TipoSitioOApp = credencialDominio.TipoSitioOApp;

            return credencialEntidad;
        }

        public Credencial PasarADominio(EntidadCredencial credencialEntidad, Usuario usuario)
        {
            Usuario dueñoCredencial = new Usuario(credencialEntidad.UsuarioGestorNombre, "12345");
            Credencial credencialDominio = new Credencial();

            CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio(usuario);

            string categoriaNombre = categoriaRepositorio.ObtenerDTOPorInt(credencialEntidad.IdCategoria).NombreCategoria;
            Categoria categoria = new Categoria(categoriaNombre);

            credencialDominio.Categoria = categoria;

            credencialDominio.Contraseña = PasarADominioContraseña(credencialEntidad.ContraseniaId, usuario);
            credencialDominio.FechaUltimaModificacion = credencialEntidad.FechaUltimaModificacion;
            credencialDominio.NombreSitioApp = credencialEntidad.NombreSitioApp;
            credencialDominio.NombreUsuario = credencialEntidad.NombreUsuario;
            credencialDominio.Nota = credencialEntidad.Nota;
            credencialDominio.TipoSitioOApp = credencialEntidad.TipoSitioOApp;

            return credencialDominio;
        }

        public EntidadTarjeta PasarAEntidad(Tarjeta tarjetaDominio, Usuario usuario)
        {
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            EntidadTarjeta tarjetaEntidad = new EntidadTarjeta();

            CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio(usuario);

            tarjetaEntidad.Categoria = categoriaRepositorio.ObtenerDTOPorString(tarjetaDominio.Categoria.Nombre);
            tarjetaEntidad.CodigoSeguridad = tarjetaDominio.CodigoSeguridad;
            tarjetaEntidad.FechaVencimiento = tarjetaDominio.FechaVencimiento;
            tarjetaEntidad.Nombre = tarjetaDominio.Nombre;
            tarjetaEntidad.NotaOpcional = tarjetaDominio.NotaOpcional;
            tarjetaEntidad.Numero = tarjetaDominio.Numero;
            tarjetaEntidad.Tipo = tarjetaDominio.Tipo;
            tarjetaEntidad.UsuarioGestorNombre = usuario.Nombre;
            tarjetaEntidad.UsuarioGestor = usuarioRepositorio.ObtenerUsuarioDto(usuario);

            return tarjetaEntidad;
        }

        public Tarjeta PasarADominio(EntidadTarjeta tarjetaEntidad)
        {
            Usuario dueñoTarjeta = new Usuario(tarjetaEntidad.UsuarioGestorNombre, "12345");
            Tarjeta tarjetaDominio = new Tarjeta();
            tarjetaDominio.Categoria = PasarADominio(tarjetaEntidad.IdCategoria, dueñoTarjeta);
            tarjetaDominio.CodigoSeguridad = tarjetaEntidad.CodigoSeguridad;
            tarjetaDominio.FechaVencimiento = tarjetaEntidad.FechaVencimiento;
            tarjetaDominio.Nombre = tarjetaEntidad.Nombre;
            tarjetaDominio.NotaOpcional = tarjetaEntidad.NotaOpcional;
            tarjetaDominio.Numero = tarjetaEntidad.Numero.ToString();
            tarjetaDominio.Tipo = tarjetaEntidad.Tipo;

            return tarjetaDominio;
        }

        /*public EntidadGestorContraseñasCompartidas PasarAEntidad(GestorContraseniasCompartidas gestorDominio)
        {
            EntidadGestorContraseñasCompartidas gestorEntidad = new EntidadGestorContraseñasCompartidas();
            gestorEntidad.contraseniasCompartidasConmigo = gestorDominio.ObtenerContraseniasCompartidasConmigo();
            
        }*/

        public EntidadUsuario PasarAEntidad(Usuario usuarioDominio)
        {
            EntidadUsuario usuarioEntidad = new EntidadUsuario();
            usuarioEntidad.Nombre = usuarioDominio.Nombre;
            usuarioEntidad.Contrasenia = usuarioDominio.Contrasenia;

            return usuarioEntidad;
        }

        public Usuario PasarADominio(EntidadUsuario usuarioEntidad)
        {
            Usuario usuarioDominio = new Usuario();
            usuarioDominio.Nombre = usuarioEntidad.Nombre;
            usuarioDominio.Contrasenia = usuarioEntidad.Contrasenia;

            return usuarioDominio;
        }


    }
}
