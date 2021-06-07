using AccesoDatos.Entidades_Datos;
using OblDiseño1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Mapper
    {
        public Entidad_Categoria PasarAEntidad(Categoria categoriaDominio)
        {
            Entidad_Categoria categoriaDto = new Entidad_Categoria();
            categoriaDto.Nombre = categoriaDominio.Nombre;

            return categoriaDto;
        }

        public Categoria PasarADominio(Entidad_Categoria categoriaEntidad)
        {
            Categoria categoriaDominio = new Categoria();
            categoriaDominio.Nombre = categoriaEntidad.Nombre;

            return categoriaDominio;
        }

        public Entidad_DuplaUsuarioContrasenia PasarAEntidad(Dupla_UsuarioContrasenia duplaDominio)
        {
            Entidad_DuplaUsuarioContrasenia duplaEntidad = new Entidad_DuplaUsuarioContrasenia();
            duplaEntidad.Categoria = PasarAEntidad(duplaDominio.Categoria);
            duplaEntidad.Contrasenia = duplaDominio.Contrasenia;
            duplaEntidad.FechaUltimaModificacion = duplaDominio.FechaUltimaModificacion;
            duplaEntidad.NivelSeguridadContrasenia = duplaDominio.NivelSeguridadContrasenia;
            duplaEntidad.NombreSitioApp = duplaDominio.NombreSitioApp;
            duplaEntidad.NombreUsuario = duplaDominio.NombreUsuario;
            duplaEntidad.Nota = duplaDominio.Nota;
            duplaEntidad.TipoSitioOApp = duplaDominio.TipoSitioOApp;

            return duplaEntidad;
        }

        public Dupla_UsuarioContrasenia PasarADominio(Entidad_DuplaUsuarioContrasenia duplaEntidad)
        {
            Dupla_UsuarioContrasenia duplaDominio = new Dupla_UsuarioContrasenia(duplaEntidad.NombreUsuario, duplaEntidad.Contrasenia, duplaEntidad.NombreSitioApp, duplaEntidad.Nota, PasarADominio(duplaEntidad.Categoria));
            return duplaDominio;
        }

        public Entidad_Tarjeta PasarAEntidad(Tarjeta tarjetaDominio)
        {
            Entidad_Tarjeta tarjetaEntidad= new Entidad_Tarjeta();
            tarjetaEntidad.Categoria = PasarAEntidad(tarjetaDominio.Categoria);
            tarjetaEntidad.CodigoSeguridad = tarjetaDominio.CodigoSeguridad;
            tarjetaEntidad.FechaVencimiento = tarjetaDominio.FechaVencimiento;
            tarjetaEntidad.Nombre = tarjetaDominio.Nombre;
            tarjetaEntidad.NotaOpcional = tarjetaDominio.NotaOpcional;
            tarjetaEntidad.Numero = Int32.Parse(tarjetaDominio.Numero);
            tarjetaEntidad.Tipo = tarjetaDominio.Tipo;

            return tarjetaEntidad;
        }

        public Tarjeta PasarADominio(Entidad_Tarjeta tarjetaEntidad)
        {
            Tarjeta tarjetaDominio = new Tarjeta();
            tarjetaDominio.Categoria = PasarADominio(tarjetaEntidad.Categoria);
            tarjetaDominio.CodigoSeguridad = tarjetaEntidad.CodigoSeguridad ;
            tarjetaDominio.FechaVencimiento = tarjetaEntidad.FechaVencimiento;
            tarjetaDominio.Nombre = tarjetaEntidad.Nombre;
            tarjetaDominio.NotaOpcional = tarjetaEntidad.NotaOpcional;
            tarjetaDominio.Numero = tarjetaEntidad.Numero.ToString();
            tarjetaDominio.Tipo = tarjetaEntidad.Tipo;

            return tarjetaDominio;
        }

        public Entidad_Usuario PasarAEntidad(Usuario usuarioDominio)
        {
            Entidad_Usuario usuarioEntidad = new Entidad_Usuario();
            usuarioEntidad.Nombre = usuarioDominio.Nombre;
            usuarioEntidad.Contrasenia = usuarioDominio.Contrasenia;
            foreach (var cat in usuarioDominio.ObtenerCategorias())
            {
                Entidad_Categoria categoriaEntidad = PasarAEntidad(cat);
                usuarioEntidad.categorias.Add(categoriaEntidad);
            }

            foreach (var tarjetas in usuarioDominio.ObtenerTarjetas())
            {
                Entidad_Tarjeta tarjetaEntidad = PasarAEntidad(tarjetas);
                usuarioEntidad.tarjetas.Add(tarjetaEntidad);
            }

            foreach (var duplas in usuarioDominio.ObtenerDuplas())
            {
                Entidad_DuplaUsuarioContrasenia duplasEntidad = PasarAEntidad(duplas);
                usuarioEntidad.duplas.Add(duplasEntidad);
            }
                
            
            return usuarioEntidad;
        }

        public Usuario PasarADominio(Entidad_Usuario usuarioEntidad)
        {
            Usuario usuarioDominio = new Usuario();
            usuarioDominio.Nombre = usuarioEntidad.Nombre;
            usuarioDominio.Contrasenia = usuarioEntidad.Contrasenia;

            foreach (var categoriaEntidad in usuarioEntidad.categorias)
            {
                Categoria categoriaDominio = PasarADominio(categoriaEntidad);
                usuarioDominio.ObtenerCategorias().Add(categoriaDominio);
            }

            foreach (var duplaEntidad in usuarioEntidad.duplas)
            {
                Dupla_UsuarioContrasenia duplaDominio = PasarADominio(duplaEntidad);
                usuarioDominio.ObtenerDuplas().Add(duplaDominio);
            }

            foreach (var tarjetaEntidad in usuarioEntidad.tarjetas)
            {
                Tarjeta tarjetaDominio = PasarADominio(tarjetaEntidad);
                usuarioDominio.ObtenerTarjetas().Add(tarjetaDominio);
            }

            return usuarioDominio;
        }


    }
}
