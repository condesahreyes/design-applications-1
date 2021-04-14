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
        private static string nombre = "user";
        private static string contrasenia = "contrasenia123";
        private static string contrasenia2 = "contrasenia1234";
        private static string contraseniaCorta = "1234";
        private static string contraseniaLarga = "contrasenia123456789012345";

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
        /*
        usuario = new Usuario(nombre, contrasenia, null, null, null);
        categoria = new Categoria("Personal");
        tarjeta = new Tarjeta("Visa Gold", "Visa", "12345", "ABCD", "15/12/21", categoria, null);
        dupla = new Dupla_UsuarioContrasenia("Hernán", "1234", "Instagram", 1, null, "20/01/21", "", categoria);
        */
         }
        /*
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
            usuario.cambiarContrasenia(contrasenia2);
            Assert.AreEqual(contrasenia2, usuario.Contrasenia);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUsuarioDataException))]
        public void CambiarContraseniaCorta()
        {
            usuario.cambiarContrasenia(contraseniaCorta);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUsuarioDataException))]
        public void CambiarContraseniaLarga()
        {
            usuario.cambiarContrasenia(contraseniaLarga);
        }

        [TestMethod]
        public void AgregarTarjetaPorPrimeraVez()
        {
            usuario.AgregarTarjeta(tarjeta);
            Assert.IsNotNull(usuario.tarjetas);
        }

        [TestMethod]
        public void EliminarMiUnicaTarjeta()
        {
            usuario.AgregarTarjeta(tarjeta);
            usuario.EliminarTarjeta(tarjeta);
            Assert.IsNull(usuario.tarjetas);
        }

        [TestMethod]
        public void AgregarDuplaPorPrimeraVez()
        {
            duplas.AgregarDuplas(dupla);
            Assert.IsNotNull(usuario.duplas);
        }

        [TestMethod]
        public void EliminarMiUnicaDupla()
        {
            duplas.AgregarDuplas(dupla);
            usuario.EliminarDupla(dupla);
            Assert.IsNull(usuario.duplas);
        }

        [TestMethod]
        public void AgregarCategoriaPorPrimeraVez()
        {
            categorias.AgregarCategoria(categoria);
            Assert.IsNotNull(usuario.categorias);
        }

        [TestMethod]
        public void EliminarMiUnicaCategoria()
        {
            categorias.AgregarCategoria(categoria);
            categorias.EliminarCategoria(categoria);
            Assert.IsNull(usuario.categorias);
        }
        */
    }
}
