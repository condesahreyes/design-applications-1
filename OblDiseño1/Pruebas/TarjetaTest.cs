using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1;

namespace Pruebas
{
    [TestClass]
    public class TarjetaTest
    {

        Categoria categoria = new Categoria("Personal");
        string nombre = "Rodri";
        string tipo = "Visa";
        long numero = 1876322167154328;
        int codigoSeguridad = 241;
        DateTime fechaVencimiento = new DateTime(2024, 10, 05);
        Tarjeta tarjetaEsperada = new Tarjeta("Rodri", "Visa",1876322167154328, 241, new DateTime(2024, 10, 05), new Categoria("Personal"), "");




        [TestMethod]
        public void Crear_Tarjeta_Test()
        {
            Tarjeta tarjetaCreada = new Tarjeta("Rodri", "Visa", 1876322167154328, 241, new DateTime(2024, 10, 05), new Categoria("Personal"), "");
            Assert.IsNotNull(tarjetaCreada);
        }


        [TestMethod]
        public void Tarjetas_Iguales_Test()
        {
            Assert.AreEqual(tarjetaEsperada, new Tarjeta("Rodri", "Visa", 1876322167154328, 241, new DateTime(2024, 10, 05), categoria, ""));
        }

        public void Tarjetas_Diferentes_Test()
        {
            Assert.AreNotEqual(tarjetaEsperada, new Tarjeta("Rodri", "Visa", 2198322311154602, 125, new DateTime(2024, 11, 01), categoria, ""));
        }


        [TestMethod]
        [ExpectedException(typeof(TarjetaIncorrectaException))]
        public void Tarjeta_NumeroIncorrecto_Test()
        {
            Tarjeta tarjetaNumeroIncoreccto = new Tarjeta(nombre, tipo, 8371635461, codigoSeguridad, fechaVencimiento, categoria, "");

        }


        [TestMethod]
        public void Baja_Tarjeta_Test()
        {
            Tarjeta tarjetaABorrar = new Tarjeta(nombre, tipo, numero, codigoSeguridad, fechaVencimiento, categoria, "");
            // tarjetaABorrar.borrarTarjeta();
            Assert.IsNull(tarjetaABorrar);
        }


        [TestMethod]
        [ExpectedException(typeof(TarjetaIncorrectaException))]
        public void Tarjeta_CodigoSeguridadLargo_Test()
        {
            Tarjeta tarjetaEsperada = new Tarjeta(nombre, tipo, numero, 23834, fechaVencimiento, categoria, "");

        }



        [TestMethod]
        [ExpectedException(typeof(TarjetaIncorrectaException))]
        public void Tarjeta_NombreNulo_Test()
        {
            Tarjeta tarjetaEsperada = new Tarjeta(null, tipo, numero, codigoSeguridad, fechaVencimiento, categoria, "");

        }

        [TestMethod]
        [ExpectedException(typeof(TarjetaIncorrectaException))]
        public void Tarjeta_TipoNulo_Test()
        {
            Tarjeta tarjetaEsperada = new Tarjeta(nombre, null, numero, codigoSeguridad, fechaVencimiento, categoria, "");

        }

        [TestMethod]
        [ExpectedException(typeof(TarjetaIncorrectaException))]
        public void Tarjeta_CodigoSeguridadCorto_Test()
        {
            Tarjeta tarjetaEsperada = new Tarjeta(nombre, tipo, numero, 0, fechaVencimiento, categoria, "");
        }

        [TestMethod]
        [ExpectedException(typeof(TarjetaIncorrectaException))]
        public void Tarjeta_fechaVencimientoInvalida_Test()
        {
            DateTime algo = new DateTime(0000, 000, 00);
            Tarjeta tarjetaEsperada = new Tarjeta(nombre, tipo, numero, codigoSeguridad, new DateTime(1200,40,12), categoria, "");
        }















    }
}
