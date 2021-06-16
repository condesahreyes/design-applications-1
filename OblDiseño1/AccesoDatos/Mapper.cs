using AccesoDatos.Entidades_Datos;
using OblDiseño1.Entidades;
using OblDiseño1;
using OblDiseño1.ControladoresPorFuncionalidad;
using AccesoDatos.Repositorios;

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

            tarjetaEntidad.IdCategoria = categoriaRepositorio.ObtenerDTOPorString(tarjetaDominio.Categoria.Nombre).CategoriaId;
            tarjetaEntidad.CodigoSeguridad = tarjetaDominio.CodigoSeguridad;
            tarjetaEntidad.FechaVencimiento = tarjetaDominio.FechaVencimiento;
            tarjetaEntidad.Nombre = tarjetaDominio.Nombre;
            tarjetaEntidad.NotaOpcional = tarjetaDominio.NotaOpcional;
            tarjetaEntidad.Numero = tarjetaDominio.Numero;
            tarjetaEntidad.Tipo = tarjetaDominio.Tipo;
            tarjetaEntidad.UsuarioGestorNombre = usuario.Nombre;
            tarjetaEntidad.UsuarioGestorNombre = usuarioRepositorio.ObtenerUsuarioDto(usuario).Nombre;

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
            ControladorObtener controladorObtener = new ControladorObtener();

            Usuario usuarioDominio = new Usuario();
            
            usuarioDominio.Nombre = usuarioEntidad.Nombre;
            usuarioDominio.Contrasenia = usuarioEntidad.Contrasenia;
            TarjetaRepositorio repoTarjeta = new TarjetaRepositorio(usuarioDominio);
            CategoriaRepositorio repoCategoria = new CategoriaRepositorio(usuarioDominio);
            CredencialRepositorio repoCredencial = new CredencialRepositorio(usuarioDominio);

            usuarioDominio.tarjetas = repoTarjeta.GetAll();
            usuarioDominio.credenciales = repoCredencial.GetAll();
            usuarioDominio.categorias = repoCategoria.GetAll();

            return usuarioDominio;
        }

        public EntidadDataBrechTarjeta PasarAEntidadTarjetaBracheada(Tarjeta tarjetaBracheada, Usuario usuario)
        {
            TarjetaRepositorio repoTarjeta = new TarjetaRepositorio(usuario);
            EntidadTarjeta tarjetaEntidad = repoTarjeta.ObtenerDto(tarjetaBracheada);
            Categoria categoria = PasarADominio(tarjetaEntidad.IdCategoria, usuario);
            EntidadDataBrechTarjeta miTarjeta = new EntidadDataBrechTarjeta(tarjetaEntidad.TarjetaId, tarjetaEntidad.Numero,
                tarjetaEntidad.UsuarioGestorNombre, tarjetaEntidad.NotaOpcional, tarjetaEntidad.Nombre, tarjetaEntidad.Tipo,
                tarjetaEntidad.CodigoSeguridad, tarjetaEntidad.FechaVencimiento, categoria.Nombre);

            return miTarjeta;
        }

        public EntidadDataBrechCredencial PasarAEntidadCredencialBracheada(Credencial credencialBracheada, Usuario usuario)
        {
            CredencialRepositorio repoCredencial = new CredencialRepositorio(usuario);

            EntidadCredencial credencialEntidad = repoCredencial.ObtenerDto(credencialBracheada);

            string contraseña = credencialBracheada.ObtenerContraseña;

            EntidadDataBrechCredencial miCredencial = new EntidadDataBrechCredencial(credencialEntidad.CredencialId, credencialEntidad.NombreUsuario,
                contraseña, credencialEntidad.NombreSitioApp, credencialEntidad.UsuarioGestorNombre, credencialBracheada.Nota ,credencialBracheada.Categoria.Nombre, credencialBracheada.FechaUltimaModificacion);

            return miCredencial;
        }

        public EntidadDataBreach PasarAEntidadDataBreach(ChequeadorDeDataBreaches dataBreachParametro, Usuario usuario)
        {
            EntidadDataBreach dataBreach = new EntidadDataBreach(dataBreachParametro.Fecha, usuario.Nombre);
            foreach (var tarjeta in dataBreachParametro.TarjetasVulneradas)
            {
                dataBreach.tarjetasVulneradas.Add(PasarAEntidadTarjetaBracheada(tarjeta, usuario));
            }

            foreach (var credencial in dataBreachParametro.CredencialesVulneradas)
            {
                dataBreach.credencialVulneradas.Add(PasarAEntidadCredencialBracheada(credencial, usuario));
            }
            return dataBreach;
        }



        public Credencial PasarADominioCredencialVulnerada(EntidadDataBrechCredencial credencialVulnerada)
        {
            Credencial credencial = new Credencial();
            credencial.NombreUsuario = credencialVulnerada.NombreUsuario;
            credencial.Contraseña = new Contraseña(credencialVulnerada.Contrasenia);
            credencial.NombreSitioApp = credencialVulnerada.NombreSitioApp;
            credencial.Nota = credencialVulnerada.Nota;
            credencial.Categoria = new Categoria(credencialVulnerada.Categoria);
            credencial.FechaUltimaModificacion = credencialVulnerada.FechaUltimaModificacion;

            return credencial;
        }

        public Tarjeta PasarADominioTarjetaVulnerada(EntidadDataBrechTarjeta tarjetaVulnerada)
        {
            Tarjeta tarjeta= new Tarjeta();
            tarjeta.Nombre = tarjetaVulnerada.Nombre;
            tarjeta.Tipo = tarjetaVulnerada.Tipo;
            tarjeta.Numero = tarjetaVulnerada.Numero;
            tarjeta.CodigoSeguridad = tarjetaVulnerada.CodigoSeguridad;
            tarjeta.FechaVencimiento = tarjetaVulnerada.FechaVencimiento;
            tarjeta.Categoria = new Categoria(tarjetaVulnerada.Categoria);
            tarjeta.NotaOpcional = tarjetaVulnerada.NotaOpcional;

            return tarjeta;
        }

        public ChequeadorDeDataBreaches PasarADominioDataBreach(EntidadDataBreach dataBreach, Usuario usuario)
        {
            DataBrechRepositorio repoDataBreach = new DataBrechRepositorio(usuario);
            ChequeadorDeDataBreaches miDataBreach = new ChequeadorDeDataBreaches(usuario);
            miDataBreach.Fecha = dataBreach.fecha;
            miDataBreach.id = dataBreach.IdDataBrech;


            miDataBreach.CredencialesVulneradas = repoDataBreach.ObtenerCredencialesVulneradas(miDataBreach);
            miDataBreach.TarjetasVulneradas = repoDataBreach.ObtenerTarjetasVulneradas(miDataBreach);

            return miDataBreach;
        }

    }
}
