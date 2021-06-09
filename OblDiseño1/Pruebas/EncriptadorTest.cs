using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using OblDiseño1;


namespace Pruebas
{

    [TestClass]
    public class EncriptadorTest
    {
        private static readonly string contrasenia1 = "cae][qwQWDc,p[12waC,WQE";
        private static readonly string contrasenia2 = "QWERTY123.";

        private static string llave1;
        private static string llave2;


        [TestInitialize]
        public void Setup()
        {
            llave1 = null;
            llave2 = null;
        }
        

        [TestMethod]
        public void GenerarLLave()
        {
            llave1 = Encriptador.GenerarLlave();
            Assert.IsNotNull(llave1);
        }

        [TestMethod]
        public void EncriptaCorrectamenteTest()
        {
            llave1 = Encriptador.generarLLave();
            string contrasenia1Encriptada = new Encriptador.Encriptar(contrasenia1, llave1);
            Assert.AreNotEqual(contrasenia1, contrasenia1Encriptada);
        }

        [TestMethod]
        public void EncriptaContraseniasDiferentesConMismaLlaveMethod1()
        {
            llave1 = Encriptador.GenerarLlave();
            string contrasenia1Encriptada = new Encriptador.Encriptar(contrasenia1, llave1);
            string contrasenia2Encriptada = new Encriptador.Encriptar(contrasenia2, llave1);
            Assert.AreEqual(contrasenia1Encriptada, contrasenia2Encriptada);
        }

        [TestMethod]
        public void EncriptaDiferentementeLaMismaContraConDifrentesLlaves()
        {
            llave1 = Encriptador.GenerarLlave();
            llave2 = Encriptador.GenerarLlave();
            while (llave1.Equals(llave2))
            {
                llave2 = Encriptador.GenerarLlave();
            }
            string contrasenia1EncriptadaConLlave1 = new Encriptador.Encriptar(contrasenia1, llave1);
            string contrasenia1EncriptadaConLlave2 = new Encriptador.Encriptar(contrasenia1, llave2);
            Assert.AreEqual(contrasenia1EncriptadaConLlave1, contrasenia1EncriptadaConLlave2);
        }

        [TestMethod]
        public void DesencriptaCorrectamente()
        {
            llave1 = Encriptador.generarLLave();
            string contrasenia1Encriptada = new Encriptador.Encriptar(contrasenia1, llave1);
            string contrasenia1Desencriptada = new Encriptador.Desencriptar(contrasenia1Encriptada, llave1);
            Assert.AreNotEqual(contrasenia1, contrasenia1Encriptada);
        }
    }
}
