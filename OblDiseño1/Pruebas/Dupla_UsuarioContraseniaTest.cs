using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1;
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

        [TestInitialize]
        public void Setup()
        {
            nombreUsuario = "JuanEjemplo";
            usuarioContrasenia = "aSD0v89ha+sfunv/*av";
            sitio = "sitio.ejemplo.uy";
            nota = "Esto es una nota para el test";
            nivelSeguridad = 5;
            nombreCategoria = "Categoria";
            categoria = new Categoria(nombreCategoria);


            ultimaModificacion = DateTime.Today;
            nivelSeguridad = 5;
            dataBrench = false;

            unaDupla = new Dupla_UsuarioContrasenia(nombreUsuario, usuarioContrasenia, sitio, nota, categoria);
        }

        [TestMethod]
        public void AltaDuplaUsuarioContrasenia()
        {
            Dupla_UsuarioContrasenia nuevaDupla = new Dupla_UsuarioContrasenia(nombreUsuario, usuarioContrasenia,
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
            Assert.AreEqual(usuarioContrasenia, unaDupla.Contrasenia);
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
            Assert.AreEqual(nivelSeguridad, unaDupla.NivelSeguridadContrasenia);
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
            unaDupla.Contrasenia = unaContrasenia;

            Assert.AreEqual(nuevoNivelSeguridad, unaDupla.NivelSeguridadContrasenia);
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
            unaDupla.Contrasenia = unaContrasenia;

            Assert.AreEqual(unaContrasenia, unaDupla.Contrasenia);
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
            unaDupla.Contrasenia = contraseniaCorta;
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void ModificacionContraseniaLarga()
        {
            string contraseniaLarga = "12345678912345678912345678";
            unaDupla.Contrasenia = contraseniaLarga;
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
            string contrasenia = Dupla_UsuarioContrasenia.GenerarContrasenia(largoInseguro, caracteresRequeridos);
            Assert.AreEqual(largoInseguro, contrasenia.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void GeneracionDeContraseniaMuyCorta()
        {
            int largoIncorrecto = 4;
            Dupla_UsuarioContrasenia.GenerarContrasenia(largoIncorrecto, caracteresRequeridos);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void GeneracionDeContraseniaMuyLarga()
        {
            int largoIncorrecto = 26;
            Dupla_UsuarioContrasenia.GenerarContrasenia(largoIncorrecto, caracteresRequeridos);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void GeneracionDeContraseniaNinguTipoDeCaracter()
        {
            bool[] caracteres = { false, false, false, false };
            Dupla_UsuarioContrasenia.GenerarContrasenia(largoSeguridadMedia, caracteres);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDatosDeContraseniaInvalidos))]
        public void GeneracionDeContraseniaLargoContraseniaCorta()
        {
            int largoInvalido = 4;
            Dupla_UsuarioContrasenia.GenerarContrasenia(largoInvalido, caracteresRequeridos);
        }

        [TestMethod]
        public void GeneracionDeContraseniaCaracteresCorrectos()
        {
            string unaContrasenia = Dupla_UsuarioContrasenia.GenerarContrasenia(largoSeguro, caracteresRequeridos);
            bool[] tiposCaracteresContenidos = Dupla_UsuarioContrasenia.ObtenerTiposCaracteresContenidos(unaContrasenia);

            for (int i = 0; i < caracteresRequeridos.Length; i++)
                Assert.AreEqual(caracteresRequeridos[i], tiposCaracteresContenidos[i]);
        }

        [TestMethod]
        public void GeneracionContraseniaSeguiridadRoja()
        {
            string contraseniaRoja = "2b+2B+";
            int nivelSeguridad = Dupla_UsuarioContrasenia.CalcularSeguridad(contraseniaRoja);

            Assert.AreEqual(nivelContraseniaRoja, nivelSeguridad);
        }

        [TestMethod]
        public void GeneracionDeContraseniaSeguiridadNaranja()
        {
            string contraseniaNaranja = "Ashen0ne++";
            int nivelSeguridad = Dupla_UsuarioContrasenia.CalcularSeguridad(contraseniaNaranja);

            Assert.AreEqual(nivelContraseniaNaranja, nivelSeguridad);
        }

        [TestMethod]
        public void GeneracionDeContraseniaSeguiridadAmarilla()
        {
            string contraseniaAmarilla = "4ST0RA_GREAT-SWORD";
            int nivelSeguridad = Dupla_UsuarioContrasenia.CalcularSeguridad(contraseniaAmarilla);

            Assert.AreEqual(nivelContraseniaAmarilla, nivelSeguridad);
        }

        [TestMethod]
        public void GeneracionDeContraseniaSeguiridadVerdeClaro()
        {
            string contraseniaVerdeClaro = "AncientGearChosGiant10";
            int nivelSeguridad = Dupla_UsuarioContrasenia.CalcularSeguridad(contraseniaVerdeClaro);

            Assert.AreEqual(nivelContraseniaVerdeClaro, nivelSeguridad);
        }

        [TestMethod]
        public void GeneracionDeContraseniaSeguiridadVerdeOscuro()
        {
            string contraseniaVerdeOscuro = "AaBbCcDdEeFfGg123+-*";
            int nivelSeguridad = Dupla_UsuarioContrasenia.CalcularSeguridad(contraseniaVerdeOscuro);

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
