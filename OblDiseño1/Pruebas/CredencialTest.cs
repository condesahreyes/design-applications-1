using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1.Entidades;
using OblDiseño1;
using System;

namespace Pruebas
{
    [TestClass]
    public class CredencialTest
    {
        private static int nivelSeguridad;

        private static bool dataBrench = false;

        private static string nombreUsuario;
        private static string usuarioContrasenia;
        private static string sitio;
        private static string nota;
        private static string nombreCategoria;

        private static DateTime ultimaModificacion = DateTime.Today;

        private Categoria categoria;

        private Credencial unaCredencial;

        private Contraseña contraseña;

        [TestInitialize]
        public void Setup()
        {
            nivelSeguridad = 5;

            ultimaModificacion = DateTime.Today;
            nivelSeguridad = 5;
            dataBrench = false;

            unaCredencial = CrearCredencial();
        }

        private Credencial CrearCredencial()
        {
            nombreUsuario = "JuanEjemplo";
            usuarioContrasenia = "aSD0v89ha+sfunv/*av";
            sitio = "sitio.ejemplo.uy";
            nota = "Esto es una nota para el test";
            nombreCategoria = "Categoria";

            categoria = new Categoria(nombreCategoria);

            Contraseña contraseña = new Contraseña(usuarioContrasenia);

            return new Credencial(nombreUsuario, contraseña, sitio, nota, categoria);
        }

        [TestMethod]
        public void AltaCredencialUsuarioContrasenia()
        {
            Credencial nuevaDupla = new Credencial(nombreUsuario, contraseña,
                sitio, nota, categoria);

            Assert.IsNotNull(nuevaDupla);
        }

        [TestMethod]
        public void AltaVerificacionNombreUsuario()
        {
            Assert.AreEqual(nombreUsuario, unaCredencial.NombreUsuario);
        }

        [TestMethod]
        public void AltaVerificacionContrasenia()
        {
            Assert.AreEqual(usuarioContrasenia, unaCredencial.Contraseña.Contrasenia);
        }

        [TestMethod]
        public void AltaVerificacionNombreSitioApp()
        {
            Assert.AreEqual(sitio, unaCredencial.NombreSitioApp);
        }

        [TestMethod]
        public void AltaVerificacionNota()
        {
            Assert.AreEqual(nota, unaCredencial.Nota);
        }

        [TestMethod]
        public void AltaVerificacionNivelDeSeguridad()
        {
            Assert.AreEqual(nivelSeguridad, unaCredencial.Contraseña.NivelSeguridadContrasenia);
        }

        [TestMethod]
        public void AltaVerificacionDataBrench()
        {
            Assert.AreEqual(dataBrench, unaCredencial.DataBrench);
        }

        [TestMethod]
        public void AltaVerificacionFechaModificacion()
        {
            Assert.AreEqual(ultimaModificacion, unaCredencial.FechaUltimaModificacion);
        }

        [TestMethod]
        public void AltaVerificacionCategoria()
        {
            Assert.AreEqual(categoria, unaCredencial.Categoria);
        }

        [TestMethod]
        public void ModificacionNivelSeguridad()
        {
            string unaContrasenia = "aaaaa";
            int nuevoNivelSeguridad = 1;
            unaCredencial.Contraseña.Contrasenia = unaContrasenia;

            Assert.AreEqual(nuevoNivelSeguridad, unaCredencial.Contraseña.NivelSeguridadContrasenia);
        }

        [TestMethod]
        public void ModificacionFechaUltimaModificacion()
        {
            DateTime unaUltimaModificacion = new DateTime(2021, 03, 29);
            unaCredencial.FechaUltimaModificacion = unaUltimaModificacion;

            Assert.AreEqual(unaUltimaModificacion, unaCredencial.FechaUltimaModificacion);
        }

        [TestMethod]
        public void ModificacionCategoria()
        {
            string unNombreCategoria = "Personal";
            Categoria unaCategoria = new Categoria(unNombreCategoria);
            unaCredencial.Categoria = unaCategoria;

            Assert.AreEqual(unaCategoria, unaCredencial.Categoria);
        }

        [TestMethod]
        public void ModificacionNota()
        {
            string unaNota = "Una nueva nota";
            unaCredencial.Nota = unaNota;

            Assert.AreEqual(unaNota, unaCredencial.Nota);
        }

        [TestMethod]
        public void ModificacionSitioApp()
        {
            string unSitioApp = "otroStioDeEjemplo.edu.uy";
            unaCredencial.NombreSitioApp = unSitioApp;

            Assert.AreEqual(unSitioApp, unaCredencial.NombreSitioApp);
        }

        [TestMethod]
        public void ModificacionContrasenia()
        {
            string unaContrasenia = "aaaaa";
            unaCredencial.Contraseña.Contrasenia = unaContrasenia;

            Assert.AreEqual(unaContrasenia, unaCredencial.Contraseña.Contrasenia);
        }

        [TestMethod]
        public void ModificacionNombreUsuario()
        {
            string unNombreUsuario = "Hernán";
            unaCredencial.NombreUsuario = unNombreUsuario;

            Assert.AreEqual(unNombreUsuario, unaCredencial.NombreUsuario);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void ModificacionNombreUsuarioCorto()
        {
            string nombreUsuarioCorto = "Juan";
            unaCredencial.NombreUsuario = nombreUsuarioCorto;
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void ModificacionNombreUsuarioLargo()
        {
            string nombreUsuarioLargo = "HELENE GERMAINE JOSEPHE MARIE";
            unaCredencial.NombreUsuario = nombreUsuarioLargo;
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void ModificacionContraseniaCorta()
        {
            string contraseniaCorta = "1234";
            unaCredencial.Contraseña.Contrasenia = contraseniaCorta;
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void ModificacionContraseniaLarga()
        {
            string contraseniaLarga = "12345678912345678912345678";
            unaCredencial.Contraseña.Contrasenia = contraseniaLarga;
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void ModificacionNombreSitioAppCorto()
        {
            string nombreSitioAppCorto = "12";
            unaCredencial.NombreSitioApp = nombreSitioAppCorto;
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void ModificacionNombreSitioAppLargo()
        {
            string nombreSitioAppLargo = "12345678912345678912345678";
            unaCredencial.NombreSitioApp = nombreSitioAppLargo;
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void ModificacionNotaLarga()
        {
            string notaLarga = "";

            for (int i = 0; i < 251; i++)
                notaLarga += i;

            unaCredencial.Nota = notaLarga;
        }

        [TestMethod]
        public void BajaDuplaUsuarioContrasenia()
        {
            unaCredencial = null;

            Assert.IsNull(unaCredencial);
        }


        [TestMethod]
        public void PrimerCredencialEsMenor()
        {
            Contraseña contraseña = new Contraseña();
            Categoria categoria = new Categoria("Alamaula");
            Credencial credencialMenor = new Credencial("Facundo", contraseña, "unsitio", "", categoria);
            int comparar = credencialMenor.CompareTo(unaCredencial);
            Assert.AreEqual(-1, comparar);
        }
    }
}