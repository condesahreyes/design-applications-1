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
        Tarjeta tarjetaEsperada = new Tarjeta(nombre, tipo, numero, codigoSeguridad, fechaVencimiento, categoria,"");




        [TestMethod]
        public void Crear_Tarjeta_Test() 
        {
            Tarjeta tarjetaCreada = new Tarjeta();
            Assert.IsNotNull(tarjetaCreada);
        }


        [TestMethod]
        public void Alta_Tarjeta_Test()
        {
            Assert.AreEqual(tarjetaEsperada, new Tarjeta().altaTarjeta("Rodri", "Visa", 1876322167154328, 241, new DateTime(2024, 10, 05), "Personal",""));
        }

        [TestMethod]
        [ExpectedException(typeof(TarjetaIncorrectaException))]
        public void Alta_Tarjeta_NumeroIncorrecto_Test() 
        {
            Tarjeta tarjetaNumeroIncoreccto = new Tarjeta().altaTarjeta(nombre, tipo, 8371635461, codigoSeguridad, fechaVencimiento, categoria,"");
            
        }

        [TestMethod]
        public void Modificar_Tarjeta_Test() 
        {
            Tarjeta tarjetaResultante = new Tarjeta();
            tarjetaResultante.altaTarjeta("Hernan","MasterCard",8471998674553411,789, new DateTime(2024, 10, 05),"Trabajo","");
            tarjeta.modificarTarjeta(nombre, tipo, numero, codigoSeguridad, fechaVencimiento, categoria, "");
            Assert.AreEqual(tarjetaEsperada, tarjetaResultante);
        }

        [TestMethod]
        public void Baja_Tarjeta_Test() 
        {
            Tarjeta tarjetaABorrar = new Tarjeta().altaTarjeta(nombre, tipo, numero, codigoSeguridad, fechaVencimiento, categoria, "");
            tarjetaABorrar.bajaTarjeta();
            Assert.IsNull(tarjetaABorrar);
        }


        [TestMethod]
        [ExpectedException(typeof(TarjetaIncorrectaException))]
        public void Alta_Tarjeta_CodigoSeguridadIncorrecto_Test()
        {
            Tarjeta tarjetaEsperada = new Tarjeta().altaTarjeta(nombre, tipo, numero, 23834, fechaVencimiento, categoria, "");

        }



        [TestMethod]
        [ExpectedException(typeof(TarjetaIncorrectaException))]
        public void Alta_Tarjeta_NombreNulo_Test()
        {
            Tarjeta tarjetaEsperada = new Tarjeta().altaTarjeta(null, tipo, numero, codigoSeguridad, fechaVencimiento, categoria, "");

        }

        [TestMethod]
        [ExpectedException(typeof(TarjetaIncorrectaException))]
        public void Alta_Tarjeta_TipoNulo_Test()
        {
            Tarjeta tarjetaEsperada = new Tarjeta().altaTarjeta(nombre, null, numero, codigoSeguridad, fechaVencimiento, categoria, "");

        }

        [TestMethod]
        [ExpectedException(typeof(TarjetaIncorrectaException))]
        public void Alta_Tarjeta_CodigoSeguridadNulo_Test()
        {
            Tarjeta tarjetaEsperada = new Tarjeta().altaTarjeta(nombre, tipo, numero, null, fechaVencimiento, categoria, "");

        }

        [TestMethod]
        [ExpectedException(typeof(TarjetaIncorrectaException))]
        public void Alta_Tarjeta_fechaVencimientoNulo_Test()
        {
            Tarjeta tarjetaEsperada = new Tarjeta().altaTarjeta(nombre, tipo, numero, codigoSeguridad, null, categoria, "");

        }

        













    }
}
