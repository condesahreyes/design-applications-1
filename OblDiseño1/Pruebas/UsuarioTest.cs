using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1;

namespace Pruebas
{

    [TestClass]
    public class UsuarioTest
    {
        //Variables
        private static readonly string nombre = "user";
        private static readonly string contrasenia = "contrasenia123";
        private static readonly string contraseniaCorta = "1234";
        private static readonly string contraseniaLarga = "contrasenia123456789012345";

        //ArrayList
        private ArrayList tarjetas = new ArrayList();
        private ArrayList duplas = new ArrayList();
        private ArrayList categorias = new ArrayList();

        //Objetos
        Usuario usuario = new Usuario(nombre, contrasenia, null, null, null);
        Categoria categoria = new Categoria("Personal");
        Tarjeta tarjeta = new Tarjeta("Visa Gold", "Visa", "12345", "ABCD", "15/12/21", categoria, null);
        Dupla_UsuarioContrasenia dupla = new Dupla_UsuarioContrasenia("Hernán", "1234", "Instagram", 1, null, "20/01/21", "", categoria);

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
        public void AgregarTarjeta()
        {
            usuario.AgregarTarjeta(tarjeta);
            Assert.IsNotNull(usuario.tarjetas);
        }

        [TestMethod]
        public void AgregarDupla()
        {
            duplas.AgregarDuplas(dupla);
            Assert.IsNotNull(usuario.duplas);
        }

        [TestMethod]
        public void AgregarCategoria()
        {
            duplas.AgregarCategoria(categoria);
            Assert.IsNotNull(usuario.categorias);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUsuarioDataException))]
        public void AltaUsuarioContraseniaCorta()
        {
            Usuario usuario = new Usuario(nombre, contraseniaCorta, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUsuarioDataException))]
        public void AltaUsuarioContraseniaLarga()
        {
            Usuario usuario = new Usuario(nombre, contraseniaLarga, null, null, null);
        }
    }
}
