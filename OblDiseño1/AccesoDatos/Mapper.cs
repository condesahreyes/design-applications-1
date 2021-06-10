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
    public class Mapper
    {
        public EntidadCategoria PasarAEntidad(Categoria categoriaDominio)
        {
            EntidadCategoria categoriaDto = new EntidadCategoria();
            categoriaDto.NombreCategoria = categoriaDominio.Nombre;

            return categoriaDto;
        }

        public Categoria PasarADominio(EntidadCategoria categoriaEntidad)
        {
            Categoria categoriaDominio = new Categoria();
            categoriaDominio.Nombre = categoriaEntidad.NombreCategoria;

            return categoriaDominio;
        }

        public EntidadContraseña PasarAEntidad(Contraseña contraseñaDominio)
        {
            EntidadContraseña contraseñaEntidad = new EntidadContraseña();
            contraseñaEntidad.Contrasenia = contraseñaDominio.Contrasenia;
            contraseñaEntidad.NivelSeguridadContrasenia = contraseñaDominio.NivelSeguridadContrasenia;

            return contraseñaEntidad;
        }

        public Contraseña PasarADominio(EntidadContraseña contraseñaEntidad)
        {
            Contraseña contraseñaDominio = new Contraseña();
            contraseñaDominio.Contrasenia = contraseñaEntidad.Contrasenia;
            contraseñaDominio.NivelSeguridadContrasenia = contraseñaEntidad.NivelSeguridadContrasenia;

            return contraseñaDominio;
        }


        public EntidadCredencial PasarAEntidad(Credencial credencialDominio)
        {
            EntidadCredencial credencialEntidad = new EntidadCredencial();
            credencialEntidad.Categoria = PasarAEntidad(credencialDominio.Categoria);
            credencialEntidad.Contrasenia = PasarAEntidad(credencialDominio.Contraseña);
            credencialEntidad.FechaUltimaModificacion = credencialDominio.FechaUltimaModificacion;
            credencialEntidad.NombreSitioApp = credencialDominio.NombreSitioApp;
            credencialEntidad.NombreUsuario = credencialDominio.NombreUsuario;
            credencialEntidad.Nota = credencialDominio.Nota;
            credencialEntidad.TipoSitioOApp = credencialDominio.TipoSitioOApp;

            return credencialEntidad;
        }

        public Credencial PasarADominio(EntidadCredencial credencialEntidad)
        {
            Credencial credencialDominio = new Credencial();
            credencialDominio.Categoria = PasarADominio(credencialEntidad.Categoria);
            credencialDominio.Contraseña = PasarADominio(credencialEntidad.Contrasenia);
            credencialDominio.FechaUltimaModificacion = credencialEntidad.FechaUltimaModificacion;
            credencialDominio.NombreSitioApp = credencialEntidad.NombreSitioApp;
            credencialDominio.NombreUsuario = credencialEntidad.NombreUsuario;
            credencialDominio.Nota = credencialEntidad.Nota;
            credencialDominio.TipoSitioOApp = credencialEntidad.TipoSitioOApp;
            credencialDominio.Id = credencialEntidad.CredencialId;

            return credencialDominio;
        }

        public EntidadTarjeta PasarAEntidad(Tarjeta tarjetaDominio)
        {
            EntidadTarjeta tarjetaEntidad= new EntidadTarjeta();
            tarjetaEntidad.Categoria = PasarAEntidad(tarjetaDominio.Categoria);
            tarjetaEntidad.CodigoSeguridad = tarjetaDominio.CodigoSeguridad;
            tarjetaEntidad.FechaVencimiento = tarjetaDominio.FechaVencimiento;
            tarjetaEntidad.Nombre = tarjetaDominio.Nombre;
            tarjetaEntidad.NotaOpcional = tarjetaDominio.NotaOpcional;
            tarjetaEntidad.Numero = Int32.Parse(tarjetaDominio.Numero);
            tarjetaEntidad.Tipo = tarjetaDominio.Tipo;

            return tarjetaEntidad;
        }

        public Tarjeta PasarADominio(EntidadTarjeta tarjetaEntidad)
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
            if (usuarioDominio.ObtenerCategorias()!=null && usuarioDominio.ObtenerCategorias().Count != 0)
            {
                foreach (var categoriaDominio in usuarioDominio.ObtenerCategorias())
                {
                    EntidadCategoria categoriaEntidad = PasarAEntidad(categoriaDominio);
                    usuarioEntidad.categorias.Add(categoriaEntidad);
                }
            }

            if (usuarioDominio.ObtenerTarjetas().Count != 0)
            {
                foreach (var tarjetaDominio in usuarioDominio.ObtenerTarjetas())
                {
                    EntidadTarjeta tarjetaEntidad = PasarAEntidad(tarjetaDominio);
                    usuarioEntidad.tarjetas.Add(tarjetaEntidad);
                }
            }

            if (usuarioDominio.ObtenerCredenciales().Count != 0)
            {
                foreach (var credencialDominio in usuarioDominio.ObtenerCredenciales())
                {
                    EntidadCredencial credencialEntidad = PasarAEntidad(credencialDominio);
                    usuarioEntidad.credenciales.Add(credencialEntidad);
                }
            }
            

            //usuarioEntidad.gestorContraseñas = PasarAEntidad(usuarioDominio.GestorCompartirContrasenia);
            return usuarioEntidad;
        }

        public Usuario PasarADominio(EntidadUsuario usuarioEntidad)
        {
            Usuario usuarioDominio = new Usuario();
            usuarioDominio.Nombre = usuarioEntidad.Nombre;
            usuarioDominio.Contrasenia = usuarioEntidad.Contrasenia;
            

            foreach (var categoriaEntidad in usuarioEntidad.categorias)
            {
                Categoria categoriaDominio = PasarADominio(categoriaEntidad);
                usuarioDominio.ObtenerCategorias().Add(categoriaDominio);
            }

            foreach (var credencialEntidad in usuarioEntidad.credenciales)
            {
                Credencial duplaDominio = PasarADominio(credencialEntidad);
                usuarioDominio.ObtenerCredenciales().Add(duplaDominio);
            }

            foreach (var tarjetaEntidad in usuarioEntidad.tarjetas)
            {
                Tarjeta tarjetaDominio = PasarADominio(tarjetaEntidad);
                usuarioDominio.ObtenerTarjetas().Add(tarjetaDominio);
            }

            //usuarioDominio.GestorCompartirContrasenia = PasarADominio(usuarioEntidad.gestorContraseñas);

            return usuarioDominio;
        }


    }
}
