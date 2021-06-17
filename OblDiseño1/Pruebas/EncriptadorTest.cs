using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1.Manejadores;
using OblDiseño1;
using System;

namespace Pruebas
{

    [TestClass]
    public class EncriptadorTest
    {
        private static readonly string contrasenia1 = "cae][qwQWDc,p[12waC,WQE";
        private static readonly string contrasenia2 = "QWERTY123.";

        private static string llave1;
        private static string llave2;

        private Encriptador encriptador = new Encriptador();

        [TestInitialize]
        public void Setup()
        {
            llave1 = null;
            llave2 = null;
        }
        
        [TestMethod]
        public void GenerarLLave()
        {
            llave1 = encriptador.GenerarLlave();
            Assert.IsNotNull(llave1);
        }

        [TestMethod]
        public void EncriptaCorrectamenteTest()
        {
            llave1 = encriptador.GenerarLlave();
            
            string contrasenia1Encriptada = encriptador.Encriptar(contrasenia1, llave1);
            Assert.AreNotEqual(contrasenia1, contrasenia1Encriptada);
        }

        [TestMethod]
        public void EncriptaContraseniasDiferentesConMismaLlaveMethod1()
        {
            llave1 = encriptador.GenerarLlave();
            
            string contrasenia1Encriptada = encriptador.Encriptar(contrasenia1, llave1);
            string contrasenia2Encriptada = encriptador.Encriptar(contrasenia2, llave1);
            Assert.AreNotEqual(contrasenia1Encriptada, contrasenia2Encriptada);
        }

        [TestMethod]
        public void EncriptaIgualLaMismaContraseniaConLaMismaLlave()
        {
            llave1 = encriptador.GenerarLlave();

            string contrasenia1Encriptada1 = encriptador.Encriptar(contrasenia1, llave1);
            string contrasenia1Encriptada2 = encriptador.Encriptar(contrasenia1, llave1);
            Assert.AreEqual(contrasenia1Encriptada1, contrasenia1Encriptada2);
        }

        [TestMethod]
        public void EncriptaDiferentementeLaMismaContraConDifrentesLlaves()
        {
            llave1 = encriptador.GenerarLlave();
            llave2 = encriptador.GenerarLlave();
            while (llave1.Equals(llave2))
            {
                llave2 = encriptador.GenerarLlave();
            }

            string contrasenia1EncriptadaConLlave1 = encriptador.Encriptar(contrasenia1, llave1);
            string contrasenia1EncriptadaConLlave2 = encriptador.Encriptar(contrasenia1, llave2);
            Assert.AreNotEqual(contrasenia1EncriptadaConLlave1, contrasenia1EncriptadaConLlave2);
        }

        [TestMethod]
        public void DesencriptaCorrectamente()
        {
            llave1 = encriptador.GenerarLlave();
       
            string contrasenia1Encriptada = encriptador.Encriptar(contrasenia1, llave1);
            string contrasenia1Desencriptada = encriptador.Desencriptar(contrasenia1Encriptada, llave1);
            Assert.AreEqual(contrasenia1, contrasenia1Desencriptada);
        }

        [TestMethod]
        public void DesencriptaCorrectamenteContraseniaCorta()
        {
            string contraseniaCorta = "Qaqwq";
            llave1 = encriptador.GenerarLlave();

            string contrasenia1Encriptada = encriptador.Encriptar(contraseniaCorta, llave1);
            string contrasenia1Desencriptada = encriptador.Desencriptar(contrasenia1Encriptada, llave1);
            Assert.AreEqual(contraseniaCorta, contrasenia1Desencriptada);
        }

        [TestMethod]
        public void DesencriptaCorrectamenteContraseniaCorta1()
        {
            string contraseniaCorta = "Qaqwq1";
            llave1 = encriptador.GenerarLlave();

            string contrasenia1Encriptada = encriptador.Encriptar(contraseniaCorta, llave1);
            string contrasenia1Desencriptada = encriptador.Desencriptar(contrasenia1Encriptada, llave1);
            Assert.AreEqual(contraseniaCorta, contrasenia1Desencriptada);
        }

        [TestMethod]
        public void DesencriptaCorrectamenteContraseniaCorta2()
        {
            string contraseniaCorta = "Qaqwq22";
            llave1 = encriptador.GenerarLlave();

            string contrasenia1Encriptada = encriptador.Encriptar(contraseniaCorta, llave1);
            string contrasenia1Desencriptada = encriptador.Desencriptar(contrasenia1Encriptada, llave1);
            Assert.AreEqual(contraseniaCorta, contrasenia1Desencriptada);
        }

        [TestMethod]
        public void DesencriptaCorrectamenteContraseniaCorta3()
        {
            string contraseniaCorta = "Qaqwq333";
            llave1 = encriptador.GenerarLlave();

            string contrasenia1Encriptada = encriptador.Encriptar(contraseniaCorta, llave1);
            string contrasenia1Desencriptada = encriptador.Desencriptar(contrasenia1Encriptada, llave1);
            Assert.AreEqual(contraseniaCorta, contrasenia1Desencriptada);
        }

        [TestMethod]
        public void DesencriptaCorrectamenteContraseniaCorta4()
        {
            string contraseniaCorta = "Qaqwq4444";
            llave1 = encriptador.GenerarLlave();

            string contrasenia1Encriptada = encriptador.Encriptar(contraseniaCorta, llave1);
            string contrasenia1Desencriptada = encriptador.Desencriptar(contrasenia1Encriptada, llave1);
            Assert.AreEqual(contraseniaCorta, contrasenia1Desencriptada);
        }

        [TestMethod]
        public void DesencriptaCorrectamenteContraseniaCorta55555()
        {
            string contraseniaCorta = "Qaqwq55555";
            llave1 = encriptador.GenerarLlave();

            string contrasenia1Encriptada = encriptador.Encriptar(contraseniaCorta, llave1);
            string contrasenia1Desencriptada = encriptador.Desencriptar(contrasenia1Encriptada, llave1);
            Assert.AreEqual(contraseniaCorta, contrasenia1Desencriptada);
        }

        [TestMethod]
        public void DesencriptaCorrectamenteContraseniaCorta6()
        {
            string contraseniaCorta = "Qaqwq666666";
            llave1 = encriptador.GenerarLlave();

            string contrasenia1Encriptada = encriptador.Encriptar(contraseniaCorta, llave1);
            string contrasenia1Desencriptada = encriptador.Desencriptar(contrasenia1Encriptada, llave1);
            Assert.AreEqual(contraseniaCorta, contrasenia1Desencriptada);
        }

        [TestMethod]
        public void DesencriptaCorrectamenteContraseniaCorta7()
        {
            string contraseniaCorta = "Qaqwq7777777";
            llave1 = encriptador.GenerarLlave();

            string contrasenia1Encriptada = encriptador.Encriptar(contraseniaCorta, llave1);
            string contrasenia1Desencriptada = encriptador.Desencriptar(contrasenia1Encriptada, llave1);
            Assert.AreEqual(contraseniaCorta, contrasenia1Desencriptada);
        }

        [TestMethod]
        public void DesencriptaCorrectamenteContraseniaCorta8()
        {
            string contraseniaCorta = "Qaqwq88888888";
            llave1 = encriptador.GenerarLlave();

            string contrasenia1Encriptada = encriptador.Encriptar(contraseniaCorta, llave1);
            string contrasenia1Desencriptada = encriptador.Desencriptar(contrasenia1Encriptada, llave1);
            Assert.AreEqual(contraseniaCorta, contrasenia1Desencriptada);
        }

        [TestMethod]
        public void DesencriptaCorrectamenteContraseniaCorta9()
        {
            string contraseniaCorta = "Qaqwq999999999";
            llave1 = encriptador.GenerarLlave();

            string contrasenia1Encriptada = encriptador.Encriptar(contraseniaCorta, llave1);
            string contrasenia1Desencriptada = encriptador.Desencriptar(contrasenia1Encriptada, llave1);
            Assert.AreEqual(contraseniaCorta, contrasenia1Desencriptada);
        }

        [TestMethod]
        public void DesencriptaCorrectamenteContraseniaCorta10()
        {
            string contraseniaCorta = "Qaqwq1010101010";
            llave1 = encriptador.GenerarLlave();

            string contrasenia1Encriptada = encriptador.Encriptar(contraseniaCorta, llave1);
            string contrasenia1Desencriptada = encriptador.Desencriptar(contrasenia1Encriptada, llave1);
            Assert.AreEqual(contraseniaCorta, contrasenia1Desencriptada);
        }

        [TestMethod]
        public void DesencriptaCorrectamenteContraseniaCorta11()
        {
            string contraseniaCorta = "Qaqwq10101010101";
            llave1 = encriptador.GenerarLlave();

            string contrasenia1Encriptada = encriptador.Encriptar(contraseniaCorta, llave1);
            string contrasenia1Desencriptada = encriptador.Desencriptar(contrasenia1Encriptada, llave1);
            Assert.AreEqual(contraseniaCorta, contrasenia1Desencriptada);
        }

        [TestMethod]
        public void DesencriptaCorrectamenteContraseniaCorta12()
        {
            string contraseniaCorta = "Qaqwq101010101010";
            llave1 = encriptador.GenerarLlave();

            string contrasenia1Encriptada = encriptador.Encriptar(contraseniaCorta, llave1);
            string contrasenia1Desencriptada = encriptador.Desencriptar(contrasenia1Encriptada, llave1);
            Assert.AreEqual(contraseniaCorta, contrasenia1Desencriptada);
        }
    }
}
