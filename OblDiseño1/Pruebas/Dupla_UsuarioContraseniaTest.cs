﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1;
using OblDiseño1.Entidades;
using System;

namespace Pruebas
{
    [TestClass]
    public class Dupla_UsuarioContraseniaTest
    {

        private static int nivelSeguridad;
        private const int nivelContraseniaRoja = 1;
        private const int nivelContraseniaNaranja = 2;
        private const int nivelContraseniaAmarilla = 3;
        private const int nivelContraseniaVerdeClaro = 4;
        private const int nivelContraseniaVerdeOscuro = 5;
        private readonly static int largoInseguro = 6;
        private readonly static int largoSeguridadMedia = 10;
        private readonly static int largoSeguro = 18;

        private const bool incluirMayus = true;
        private const bool incluirMinus = true;
        private const bool incluirDigitos = true;
        private const bool incluirEspeciales = true;
        private static bool dataBrench = false;

        private bool[] caracteresRequeridos = { incluirMayus, incluirMinus, incluirDigitos, incluirEspeciales};

        private static string nombreUsuario;
        private static string usuarioContrasenia;
        private static string sitio;
        private static string nota;
        private static string nombreCategoria;

        private static DateTime ultimaModificacion = DateTime.Today;

        Categoria categoria;

        Dupla_UsuarioContrasenia unaDupla;

        Contraseña contraseña;

        [TestInitialize]
        public void Setup()
        {
            nivelSeguridad = 5;

            ultimaModificacion = DateTime.Today;
            nivelSeguridad = 5;
            dataBrench = false;

            unaDupla = CrearCredencial();
        }

        private Dupla_UsuarioContrasenia CrearCredencial()
        {
            nombreUsuario = "JuanEjemplo";
            usuarioContrasenia = "aSD0v89ha+sfunv/*av";
            sitio = "sitio.ejemplo.uy";
            nota = "Esto es una nota para el test";
            nombreCategoria = "Categoria";

            categoria = new Categoria(nombreCategoria);

            Contraseña contraseña = new Contraseña(usuarioContrasenia);

            return new Dupla_UsuarioContrasenia(nombreUsuario, contraseña, sitio, nota, categoria);
        }

        [TestMethod]
        public void AltaDuplaUsuarioContrasenia()
        {
            Dupla_UsuarioContrasenia nuevaDupla = new Dupla_UsuarioContrasenia(nombreUsuario, contraseña,
                sitio, nota, categoria);

            Assert.IsNotNull(nuevaDupla);
        }

        [TestMethod]
        public void AltaVerificacionNombreUsuario()
        {
            Assert.AreEqual(nombreUsuario, unaDupla.NombreUsuario);
        }

        [TestMethod]
        public void AltaVerificacionContrasenia()
        {
            Assert.AreEqual(usuarioContrasenia, unaDupla.Contraseña.Contrasenia);
        }

        [TestMethod]
        public void AltaVerificacionNombreSitioApp()
        {
            Assert.AreEqual(sitio, unaDupla.NombreSitioApp);
        }

        [TestMethod]
        public void AltaVerificacionNota()
        {
            Assert.AreEqual(nota, unaDupla.Nota);
        }

        [TestMethod]
        public void AltaVerificacionNivelDeSeguridad()
        {
            Assert.AreEqual(nivelSeguridad, unaDupla.Contraseña.NivelSeguridadContrasenia);
        }

        [TestMethod]
        public void AltaVerificacionDataBrench()
        {
            Assert.AreEqual(dataBrench, unaDupla.DataBrench);
        }

        [TestMethod]
        public void AltaVerificacionFechaModificacion()
        {
            Assert.AreEqual(ultimaModificacion, unaDupla.FechaUltimaModificacion);
        }

        [TestMethod]
        public void AltaVerificacionCategoria()
        {
            Assert.AreEqual(categoria, unaDupla.Categoria);
        }

        [TestMethod]
        public void ModificacionNivelSeguridad()
        {
            string unaContrasenia = "aaaaa";
            int nuevoNivelSeguridad = 1;
            unaDupla.Contraseña.Contrasenia = unaContrasenia;

            Assert.AreEqual(nuevoNivelSeguridad, unaDupla.Contraseña.NivelSeguridadContrasenia);
        }

        [TestMethod]
        public void ModificacionFechaUltimaModificacion()
        {
            DateTime unaUltimaModificacion = new DateTime(2021, 03, 29);
            unaDupla.FechaUltimaModificacion = unaUltimaModificacion;

            Assert.AreEqual(unaUltimaModificacion, unaDupla.FechaUltimaModificacion);
        }

        [TestMethod]
        public void ModificacionCategoria()
        {
            string unNombreCategoria = "Personal";
            Categoria unaCategoria = new Categoria(unNombreCategoria);
            unaDupla.Categoria = unaCategoria;

            Assert.AreEqual(unaCategoria, unaDupla.Categoria);
        }

        [TestMethod]
        public void ModificacionNota()
        {
            string unaNota = "Una nueva nota";
            unaDupla.Nota = unaNota;

            Assert.AreEqual(unaNota, unaDupla.Nota);
        }

        [TestMethod]
        public void ModificacionSitioApp()
        {
            string unSitioApp = "otroStioDeEjemplo.edu.uy";
            unaDupla.NombreSitioApp = unSitioApp;

            Assert.AreEqual(unSitioApp, unaDupla.NombreSitioApp);
        }

        [TestMethod]
        public void ModificacionContrasenia()
        {
            string unaContrasenia = "aaaaa";
            unaDupla.Contraseña.Contrasenia = unaContrasenia;

            Assert.AreEqual(unaContrasenia, unaDupla.Contraseña.Contrasenia);
        }

        [TestMethod]
        public void ModificacionNombreUsuario()
        {
            string unNombreUsuario = "Hernán";
            unaDupla.NombreUsuario = unNombreUsuario;

            Assert.AreEqual(unNombreUsuario, unaDupla.NombreUsuario);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void ModificacionNombreUsuarioCorto()
        {
            string nombreUsuarioCorto = "Juan";
            unaDupla.NombreUsuario = nombreUsuarioCorto;
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void ModificacionNombreUsuarioLargo()
        {
            string nombreUsuarioLargo = "HELENE GERMAINE JOSEPHE MARIE";
            unaDupla.NombreUsuario = nombreUsuarioLargo;
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void ModificacionContraseniaCorta()
        {
            string contraseniaCorta = "1234";
            unaDupla.Contraseña.Contrasenia = contraseniaCorta;
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void ModificacionContraseniaLarga()
        {
            string contraseniaLarga = "12345678912345678912345678";
            unaDupla.Contraseña.Contrasenia = contraseniaLarga;
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void ModificacionNombreSitioAppCorto()
        {
            string nombreSitioAppCorto = "12";
            unaDupla.NombreSitioApp = nombreSitioAppCorto;
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void ModificacionNombreSitioAppLargo()
        {
            string nombreSitioAppLargo = "12345678912345678912345678";
            unaDupla.NombreSitioApp = nombreSitioAppLargo;
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void ModificacionNotaLarga()
        {
            string notaLarga = "";

            for (int i = 0; i < 251; i++)
                notaLarga += i;

            unaDupla.Nota = notaLarga;
        }

        [TestMethod]
        public void GeneracionDeContraseniaLargoInseguro()
        {
            string contrasenia = Contraseña.GenerarContrasenia(largoInseguro, caracteresRequeridos);
            Assert.AreEqual(largoInseguro, contrasenia.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void GeneracionDeContraseniaMuyCorta()
        {
            int largoIncorrecto = 4;
            Contraseña.GenerarContrasenia(largoIncorrecto, caracteresRequeridos);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void GeneracionDeContraseniaMuyLarga()
        {
            int largoIncorrecto = 26;
            Contraseña.GenerarContrasenia(largoIncorrecto, caracteresRequeridos);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void GeneracionDeContraseniaNinguTipoDeCaracter()
        {
            bool[] caracteres = { false, false, false, false };
            Contraseña.GenerarContrasenia(largoSeguridadMedia, caracteres);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void GeneracionDeContraseniaLargoContraseniaCorta()
        {
            int largoInvalido = 4;
            Contraseña.GenerarContrasenia(largoInvalido, caracteresRequeridos);
        }

        [TestMethod]
        public void GeneracionDeContraseniaCaracteresCorrectos()
        {
            string unaContrasenia = Contraseña.GenerarContrasenia(largoSeguro, caracteresRequeridos);
            bool[] tiposCaracteresContenidos = Contraseña.ObtenerTiposCaracteresContenidos(unaContrasenia);

            for (int i = 0; i < caracteresRequeridos.Length; i++)
                Assert.AreEqual(caracteresRequeridos[i], tiposCaracteresContenidos[i]);
        }

        [TestMethod]
        public void GeneracionContraseniaSeguiridadRoja()
        {
            string contraseniaRoja = "2b+2B+";
            int nivelSeguridad = Contraseña.CalcularSeguridad(contraseniaRoja);

            Assert.AreEqual(nivelContraseniaRoja, nivelSeguridad);
        }

        [TestMethod]
        public void GeneracionDeContraseniaSeguiridadNaranja()
        {
            string contraseniaNaranja = "Ashen0ne++";
            int nivelSeguridad = Contraseña.CalcularSeguridad(contraseniaNaranja);

            Assert.AreEqual(nivelContraseniaNaranja, nivelSeguridad);
        }

        [TestMethod]
        public void GeneracionDeContraseniaSeguiridadAmarilla()
        {
            string contraseniaAmarilla = "4ST0RAGREATSWORD";
            int nivelSeguridad = Contraseña.CalcularSeguridad(contraseniaAmarilla);

            Assert.AreEqual(nivelContraseniaAmarilla, nivelSeguridad);
        }

        [TestMethod]
        public void GeneracionDeContraseniaSeguiridadVerdeClaro()
        {
            string contraseniaVerdeClaro = "AncientGearChosGiant10";
            int nivelSeguridad = Contraseña.CalcularSeguridad(contraseniaVerdeClaro);

            Assert.AreEqual(nivelContraseniaVerdeClaro, nivelSeguridad);
        }

        [TestMethod]
        public void GeneracionDeContraseniaSeguiridadVerdeOscuro()
        {
            string contraseniaVerdeOscuro = "AaBbCcDdEeFfGg123+-*";
            int nivelSeguridad = Contraseña.CalcularSeguridad(contraseniaVerdeOscuro);

            Assert.AreEqual(nivelContraseniaVerdeOscuro, nivelSeguridad);
        }

        [TestMethod]
        public void BajaDuplaUsuarioContrasenia()
        {
            unaDupla = null;

            Assert.IsNull(unaDupla);
        }

    }
}