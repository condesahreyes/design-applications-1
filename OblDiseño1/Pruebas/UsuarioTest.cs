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

        private static string nombreLargo;
        private static string contraseniaCorta;
        private static string contraseniaLarga;

        private static string[] contrasenias = {"contrasenia123", 
            "1234Contrasenia", "laContraseña"};

        private static string[] nombres = {"Hernán", "Santiago", "Rodrigo"};

        private static string[] nombresCategorias = {"Personal", 
            "Trabajo", "Entretenimiento", "Estudios"};

        private static string[] nombresTarjetas = {"Visa",
            "Itau", "BBVA", "HSBC"};

        private static string[] tiposTarjetas = {"Visa gold",
            "Itau volar", "BBVA credito", "HSBC debito"};

        private static long[] numTarjetas = { 1234567891234567, 
            7894561234567894, 9876543219876543, 5462134567896543};

        private static int[] codigosTarjetas = { 123, 321, 456, 789};

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
            contraseniaCorta = "1234";
            contraseniaLarga = "contrasenia123456789012345";
            nombreLargo = "Este es un nombre muy largo";

            duplas = new List<Dupla_UsuarioContrasenia>();
            tarjetas = new List<Tarjeta>();
            categorias = new List<Categoria>();

            usuario = new Usuario(nombres[0], contrasenias[0]);
            categoria = new Categoria(nombresCategorias[0]);
            tarjeta = new Tarjeta(nombresTarjetas[0], tiposTarjetas[0], numTarjetas[0],
                codigosTarjetas[0], new DateTime(2021, 12, 15), categoria, null);
            dupla = new Dupla_UsuarioContrasenia(nombres[1], contraseniaCorta, 
                "Instagram", "", categoria);

        }

        [TestMethod]
        public void AltaUsuarioListasVacias()
        {
            Assert.IsNotNull(usuario);
        }

        [TestMethod]
        public void AltaUsuarioVerificarNombre()
        {
            Assert.AreEqual(nombres[0], usuario.Nombre);
        }

        [TestMethod]
        public void AltaUsuarioVerificarContrasenia()
        {
            Assert.AreEqual(contrasenias[0], usuario.Contrasenia);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUsuarioDataException))]
        public void AltaUsuarioNombreVacio()
        {
            Usuario unUsuario = new Usuario("", contrasenias[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUsuarioDataException))]
        public void AltaUsuarioNombreLargo()
        {
            Usuario unUsuario = new Usuario(nombreLargo, contrasenias[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUsuarioDataException))]
        public void AltaUsuarioContraseniaCorta()
        {
            Usuario unUsuario = new Usuario(nombres[1], contraseniaCorta);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUsuarioDataException))]
        public void AltaUsuarioContraseniaLarga()
        {
            Usuario unUsuario = new Usuario(nombres[1], contraseniaLarga);
        }

        [TestMethod]
        public void CambiarContrasenia()
        {
            usuario.setContrasenia(contrasenias[2]);

            Assert.AreEqual(contrasenias[2], usuario.Contrasenia);
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

        [TestMethod]
        public void ListarCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();

            for (int i = 0; i < nombresCategorias.Length; i++)
            { 
                Categoria unaCategoria = new Categoria(nombresCategorias[i]);
                categorias.Add(unaCategoria);
                usuario.agregarCategoria(unaCategoria);
            }

            CollectionAssert.AreEquivalent(categorias,usuario.getCategorias());
        }

        [TestMethod]
        public void ListarTarjetas()
        {
            List<Tarjeta> tarjetas = new List<Tarjeta>();

            for (int i = 0; i < nombresTarjetas.Length; i++)
            {
                Tarjeta unaTarjeta= new Tarjeta(nombresTarjetas[i], tiposTarjetas[i],
                numTarjetas[i], codigosTarjetas[i], new DateTime(2021, 12, 15), categoria, null); ;
                tarjetas.Add(unaTarjeta);
                usuario.agregarTarjeta(unaTarjeta);
            }

            CollectionAssert.AreEquivalent(tarjetas, usuario.getTarjetas());
        }

        [TestMethod]
        public void ListarDuplas()
        {
            List<Dupla_UsuarioContrasenia> duplas = new List<Dupla_UsuarioContrasenia>();

            for (int i = 0; i < nombres.Length; i++)
            {
                Dupla_UsuarioContrasenia unaDupla = new Dupla_UsuarioContrasenia(nombres[i], 
                    contrasenias[i], "Instagram", "", categoria);
                duplas.Add(unaDupla);
                usuario.agregarDupla(unaDupla);
            }

            CollectionAssert.AreEquivalent(duplas, usuario.getDuplas());
        }

        [TestMethod]
        public void ListarCategoriasTexto()
        {
            List<string> listarCategoriasPorMetodo = new List<string>();
            List<string> listaCategorias = new List<string>();
            for (int i = 0; i < nombresCategorias.Length; i++)
            {
                Categoria unaCategoria = new Categoria(nombresCategorias[i]);
                listarCategoriasPorMetodo[i] = unaCategoria.listarCategorias();
                listaCategorias[i]= "Nombre : " + unaCategoria.Nombre;
            }

            CollectionAssert.AreEquivalent(categorias, usuario.getCategorias());
        }

        [TestMethod]
        public void ListarTarjetasTexto()
        {

            List<string> listarTarjetasPorMetodo = new List<string>();
            List<string> listaCategorias = new List<string>();

            for (int i = 0; i < nombresTarjetas.Length; i++)
            {
                Tarjeta unaTarjeta = new Tarjeta(nombresTarjetas[i], tiposTarjetas[i],
                numTarjetas[i], codigosTarjetas[i], new DateTime(2021, 12, 15), categoria, null); ;
                listarTarjetasPorMetodo[i]= unaTarjeta.ListarTarjetas();
                listaCategorias[i] = "Nombre : " + unaTarjeta.Nombre + " Tipo: " + unaTarjeta.Tipo +
                " Numero: " + unaTarjeta.Numero + " Codigo de Seguridad: " +
                unaTarjeta.CodigoSeguridad + " Fecha de Vencimiento: " +
                unaTarjeta.FechaVencimiento + "Categoria: " + unaTarjeta.Categoria +
                "Nota: " + unaTarjeta.NotaOpcional;
            }

            CollectionAssert.AreEquivalent(listaCategorias, listarTarjetasPorMetodo);
        }

        [TestMethod]
        public void ListarDuplasTexto()
        {
            List<string> listarDuplasPorMetodo = new List<string>();
            List<string> listaDuplas = new List<string>();

            for (int i = 0; i < nombres.Length; i++)
            {
                Dupla_UsuarioContrasenia unaDupla = new Dupla_UsuarioContrasenia(nombres[i],
                    contrasenias[i], "Instagram", "", categoria);
                listarDuplasPorMetodo[i] = unaDupla.ListarDuplas();
                listaDuplas[i] = "Nombre : " + unaDupla.UsernameDupla + " Contraseña: " + unaDupla.PssDupla +
                " Nombre sitio: " + unaDupla.NombreSitioApp + " Categoria: " + unaDupla.Categoria +
                " Nivel de seguridad: " + unaDupla.NivelSeguridadPss;
            }

            CollectionAssert.AreEquivalent(duplas, usuario.getDuplas());
        }

    }
}
