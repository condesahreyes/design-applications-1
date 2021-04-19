using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1;

namespace Pruebas
{

    [TestClass]
    public class UsuarioTest
    {
        private static string nombre;
        private static string contrasenia;
        private static string nombreLargo;
        private static string contrasenia2;
        private static string contraseniaCorta;
        private static string contraseniaLarga;
        private static string nombreCategoria;

        private List<Tarjeta> tarjetas;
        private List<Dupla_UsuarioContrasenia> duplas;
        private List<Categoria> categorias;

        private Usuario usuario;
        private Tarjeta tarjeta;
        private Categoria categoria;
        private Dupla_UsuarioContrasenia dupla;

        [TestInitialize]
        public void Setup()
        {
            nombre = "user";
            contraseniaCorta = "1234";
            nombreCategoria = "personal";
            contrasenia = "contrasenia123";
            contrasenia2 = "contrasenia1234";
            contraseniaLarga = "contrasenia123456789012345";
            nombreLargo = "Este es un nombre muy largo";

            duplas = new List<Dupla_UsuarioContrasenia>();
            tarjetas = new List<Tarjeta>();
            categorias = new List<Categoria>();

            usuario = new Usuario(nombre, contrasenia);
            categoria = new Categoria(nombreCategoria);
            tarjeta = new Tarjeta("Visa Gold", "Visa", 1234567891234567, 123, new DateTime(2021, 12, 15), categoria, null);
            dupla = new Dupla_UsuarioContrasenia("Hernán", "12345", "Instagram", "", categoria);

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
            Usuario unUsuario = new Usuario("", contrasenia);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUsuarioDataException))]
        public void AltaUsuarioNombreLargo()
        {
            Usuario unUsuario = new Usuario(nombreLargo, contrasenia);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUsuarioDataException))]
        public void AltaUsuarioContraseniaCorta()
        {
            Usuario unUsuario = new Usuario(nombre, contraseniaCorta);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUsuarioDataException))]
        public void AltaUsuarioContraseniaLarga()
        {
            Usuario unUsuario = new Usuario(nombre, contraseniaLarga);
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
