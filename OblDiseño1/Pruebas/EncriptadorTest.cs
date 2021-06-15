using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1;
using OblDiseño1.Manejadores;
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
    }
}
