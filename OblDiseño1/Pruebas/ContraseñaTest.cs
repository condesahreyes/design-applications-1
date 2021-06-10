using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using OblDiseño1.Entidades;
using System.Text;
using OblDiseño1;
using System;

namespace Pruebas
{
    [TestClass]
    public class ContraseñaTest
    {
        private const int nivelContraseniaVerdeOscuro = 5;
        private const int nivelContraseniaVerdeClaro = 4;
        private const int nivelContraseniaAmarilla = 3;
        private const int nivelContraseniaNaranja = 2;
        private const int nivelContraseniaRoja = 1;

        private readonly static int largoSeguridadMedia = 10;
        private readonly static int largoInseguro = 6;
        private readonly static int largoSeguro = 18;

        private const bool incluirEspeciales = true;
        private const bool incluirDigitos = true;
        private const bool incluirMayus = true;
        private const bool incluirMinus = true;

        private bool[] caracteresRequeridos = { incluirMayus, 
            incluirMinus, incluirDigitos, incluirEspeciales};

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

    }
}
