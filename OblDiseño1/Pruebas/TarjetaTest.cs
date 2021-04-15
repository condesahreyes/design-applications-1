﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1;
using System;

namespace Pruebas
{
    [TestClass]
    public class TarjetaTest
    {
        private long numero;
        private string tipo;
        private string nota;
        private string nombre;
        private int codigoSeguridad;
        private long numeroIncorrecto;
        private int codigoSeguridadLargo;
        private int codigoSeguridadCorto;

        private Categoria categoria;
        private Tarjeta tarjetaEsperada;
        private DateTime fechaIncorrecta;
        private DateTime fechaVencimiento;

        [TestInitialize]
        public void Setup()
        {
            tipo = "Visa";
            nota = "nota";
            nombre = "Rodri";
            codigoSeguridad = 241;
            codigoSeguridadCorto = 2;
            numero = 1876322167154328;
            codigoSeguridadLargo = 23834;
            numeroIncorrecto = 8371635461;
            categoria = new Categoria("Personal");
            fechaIncorrecta = new DateTime(1200, 04, 12);
            fechaVencimiento = new DateTime(2024, 10, 05);
            tarjetaEsperada = new Tarjeta("Rodri", "Visa", 1876322167154328, 241, fechaVencimiento, categoria, nota);
        }
        
        [TestMethod]
        public void Crear_Tarjeta_Test()
        {
            Tarjeta tarjetaCreada = new Tarjeta(nombre, tipo, numero, codigoSeguridad, fechaVencimiento, categoria, nota);
            Assert.IsNotNull(tarjetaCreada);
        }

        [TestMethod]
        public void Tarjetas_Iguales_Test()
        {
            Assert.AreEqual(tarjetaEsperada, new Tarjeta(nombre, tipo, numero, codigoSeguridad, fechaVencimiento, categoria, nota));
        }

        public void Tarjetas_Diferentes_Test()
        {
            Assert.AreNotEqual(tarjetaEsperada, new Tarjeta(nombre, tipo, numero, codigoSeguridad, fechaVencimiento, categoria, nota));
        }

        [TestMethod]
        [ExpectedException(typeof(TarjetaIncorrectaException))]
        public void Tarjeta_NumeroIncorrecto_Test()
        {
            Tarjeta tarjetaNumeroIncoreccto = new Tarjeta(nombre, tipo, numeroIncorrecto, codigoSeguridad, fechaVencimiento, categoria, nota);
        }

        [TestMethod]
        public void Baja_Tarjeta_Test()
        {
            Tarjeta tarjetaABorrar = new Tarjeta(nombre, tipo, numero, codigoSeguridad, fechaVencimiento, categoria, nota);
            tarjetaABorrar.BorrarTarjeta(tarjetaABorrar);
            Assert.IsNotNull(tarjetaABorrar);
        }

        [TestMethod]
        [ExpectedException(typeof(TarjetaIncorrectaException))]
        public void Tarjeta_CodigoSeguridadLargo_Test()
        {
            Tarjeta tarjetaEsperada = new Tarjeta(nombre, tipo, numero, codigoSeguridadLargo, fechaVencimiento, categoria, nota);
        }

        [TestMethod]
        [ExpectedException(typeof(TarjetaIncorrectaException))]
        public void Tarjeta_CodigoSeguridadCorto_Test()
        {
            Tarjeta tarjetaEsperada = new Tarjeta(nombre, tipo, numero, codigoSeguridadCorto, fechaVencimiento, categoria, nota);
        }

        [TestMethod]
        [ExpectedException(typeof(TarjetaIncorrectaException))]
        public void Tarjeta_NombreNulo_Test()
        {
            Tarjeta tarjetaEsperada = new Tarjeta(null, tipo, numero, codigoSeguridad, fechaVencimiento, categoria, nota);
        }

        [TestMethod]
        [ExpectedException(typeof(TarjetaIncorrectaException))]
        public void Tarjeta_TipoNulo_Test()
        {
            Tarjeta tarjetaEsperada = new Tarjeta(nombre, null, numero, codigoSeguridad, fechaVencimiento, categoria, nota);
        }

        [TestMethod]
        [ExpectedException(typeof(TarjetaIncorrectaException))]
        public void Tarjeta_fechaVencimientoInvalida_Test()
        {
            Tarjeta tarjetaEsperada = new Tarjeta(nombre, tipo, numero, codigoSeguridad, fechaIncorrecta, categoria, nota);
        }

    }
}
