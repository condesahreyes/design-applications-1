﻿using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1;

namespace Pruebas
{

    [TestClass]
    public class UsuarioTest
    {
        //Variables
        private static string nombre;
        private static string contrasenia;
        private static string contrasenia2;
        private static string contraseniaCorta;
        private static string contraseniaLarga;

        //ArrayList
        private ArrayList tarjetas;
        private ArrayList duplas;
        private ArrayList categorias;

        //Objetos
        Usuario usuario;
        Categoria categoria;
        Tarjeta tarjeta;
        Dupla_UsuarioContrasenia dupla;

        [TestInitialize]
        public void Setup()
        {
            nombre = "user";
            contrasenia = "contrasenia123";
            contrasenia2 = "contrasenia1234";
            contraseniaCorta = "1234";
            contraseniaLarga = "contrasenia123456789012345";

            tarjetas = new ArrayList();
            duplas = new ArrayList();
            categorias = new ArrayList();

            usuario = new Usuario(nombre, contrasenia, categorias, tarjetas, duplas);
            categoria = new Categoria("Personal");

            tarjeta = new Tarjeta("Visa Gold", "Visa", 1234567891234567, 123, new DateTime(2021, 12, 15), categoria, null);
            dupla = new Dupla_UsuarioContrasenia("Hernán", "1234", "Instagram", "", categoria);

        }

        [TestMethod]
        public void AltaUsuarioListasVacias()
        {
            Assert.IsNotNull(usuario);
        }

        [TestMethod]
        public void AltaUsuarioVerificarNombre()
        {
            Assert.AreEqual(nombre, usuario.Nombre);
        }

        [TestMethod]
        public void AltaUsuarioVerificarContrasenia()
        {
            Assert.AreEqual(contrasenia, usuario.Contrasenia);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUsuarioDataException))]
        public void AltaUsuarioNombreVacio()
        {
            Usuario unUsuario = new Usuario("", contraseniaLarga, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUsuarioDataException))]
        public void AltaUsuarioContraseniaCorta()
        {
            Usuario unUsuario = new Usuario(nombre, contraseniaCorta, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUsuarioDataException))]
        public void AltaUsuarioContraseniaLarga()
        {
            Usuario unUsuario = new Usuario(nombre, contraseniaLarga, null, null, null);
        }

        [TestMethod]
        public void CambiarContrasenia()
        {
            usuario.setContrasenia(contrasenia2);
            Assert.AreEqual(contrasenia2, usuario.Contrasenia);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUsuarioDataException))]
        public void CambiarContraseniaCorta()
        {
            usuario.setContrasenia(contraseniaCorta);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUsuarioDataException))]
        public void CambiarContraseniaLarga()
        {
            usuario.setContrasenia(contraseniaLarga);
        }

        [TestMethod]
        public void AgregarTarjetaPorPrimeraVez()
        {
            usuario.agregarTarjeta(tarjeta);
            Assert.AreEqual(1, usuario.getTarjetas().Count);
        }

        [TestMethod]
        public void EliminarMiUnicaTarjeta()
        {
            usuario.agregarTarjeta(tarjeta);
            usuario.eliminarTarjeta(tarjeta);
            Assert.AreEqual(0, usuario.getTarjetas().Count);
        }

        [TestMethod]
        public void AgregarDuplaPorPrimeraVez()
        {
            usuario.agregarDupla(dupla);
            Assert.AreEqual(1, usuario.getDuplas().Count);
        }

        [TestMethod]
        public void EliminarMiUnicaDupla()
        {
            usuario.agregarDupla(dupla);
            usuario.eliminarDupla(dupla);
            Assert.AreEqual(0, usuario.getDuplas().Count);
        }

        [TestMethod]
        public void AgregarCategoriaPorPrimeraVez()
        {
            usuario.agregarCategoria(categoria);
            Assert.AreEqual(1, usuario.getCategorias().Count);
        }

        [TestMethod]
        public void EliminarMiUnicaCategoria()
        {
            usuario.agregarCategoria(categoria);
            usuario.eliminarCategoria(categoria);
            Assert.AreEqual(0, usuario.getCategorias().Count);
        }

    }
}
