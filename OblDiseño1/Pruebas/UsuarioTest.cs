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
            dupla = new Dupla_UsuarioContrasenia(nombres[1], contrasenias[0], 
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
            usuario.ActualizarContrasenia(contrasenias[2]);

            Assert.AreEqual(contrasenias[2], usuario.Contrasenia);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUsuarioDataException))]
        public void CambiarContraseniaCorta()
        {
            usuario.ActualizarContrasenia(contraseniaCorta);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUsuarioDataException))]
        public void CambiarContraseniaLarga()
        {
            usuario.ActualizarContrasenia(contraseniaLarga);
        }

        [TestMethod]
        public void AgregarTarjetaPorPrimeraVez()
        {
            usuario.AgregarTarjeta(tarjeta);

            Assert.AreEqual(1, usuario.ObtenerTarjetas().Count);
        }

        [TestMethod]
        public void EliminarMiUnicaTarjeta()
        {
            usuario.AgregarTarjeta(tarjeta);
            usuario.EliminarTarjeta(tarjeta);

            Assert.AreEqual(0, usuario.ObtenerTarjetas().Count);
        }

        [TestMethod]
        public void AgregarDuplaPorPrimeraVez()
        {
            usuario.AgregarDupla(dupla);

            Assert.AreEqual(1, usuario.ObtenerDuplas().Count);
        }

        [TestMethod]
        public void EliminarMiUnicaDupla()
        {
            usuario.AgregarDupla(dupla);
            usuario.EliminarDupla(dupla);

            Assert.AreEqual(0, usuario.ObtenerDuplas().Count);
        }

        [TestMethod]
        public void AgregarCategoriaPorPrimeraVez()
        {
            usuario.AgregarCategoria(categoria);

            Assert.AreEqual(1, usuario.ObtenerCategorias().Count);
        }

        [TestMethod]
        public void EliminarMiUnicaCategoria()
        {
            usuario.AgregarCategoria(categoria);
            usuario.EliminarCategoria(categoria);

            Assert.AreEqual(0, usuario.ObtenerCategorias().Count);
        }

        [TestMethod]
        public void ListarCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();

            for (int i = 0; i < nombresCategorias.Length; i++)
            { 
                Categoria unaCategoria = new Categoria(nombresCategorias[i]);
                categorias.Add(unaCategoria);
                usuario.AgregarCategoria(unaCategoria);
            }

            CollectionAssert.AreEquivalent(categorias,usuario.ObtenerCategorias());
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
                usuario.AgregarTarjeta(unaTarjeta);
            }

            CollectionAssert.AreEquivalent(tarjetas, usuario.ObtenerTarjetas());
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
                usuario.AgregarDupla(unaDupla);
            }

            CollectionAssert.AreEquivalent(duplas, usuario.ObtenerDuplas());
        }

        [TestMethod]
        public void ListarCategoriasTexto()
        {
            List<string> listarCategoriasPorMetodo = new List<string>();
            List<string> listaCategorias = new List<string>();

            for (int i = 0; i < nombresCategorias.Length; i++)
            {
                Categoria unaCategoria = new Categoria(nombresCategorias[i]);
                usuario.AgregarCategoria(unaCategoria);
                listaCategorias.Add("Nombre : " + unaCategoria.Nombre);
            }

            listarCategoriasPorMetodo = usuario.ListarCategorias();

            CollectionAssert.AreEquivalent(listaCategorias, listarCategoriasPorMetodo);
        }

        [TestMethod]
        public void ListarTarjetasTexto()
        {

            List<string> listarTarjetasPorMetodo = new List<string>();
            List<string> listaCategorias = new List<string>();

            for (int i = 0; i < nombresTarjetas.Length; i++)
            {
                Tarjeta unaTarjeta = new Tarjeta(nombresTarjetas[i], tiposTarjetas[i],
                numTarjetas[i], codigosTarjetas[i], new DateTime(2021, 12, 15), categoria, null);

                usuario.AgregarTarjeta(unaTarjeta);

                listaCategorias.Add("Nombre : " + unaTarjeta.Nombre + " Tipo: " + unaTarjeta.Tipo +
                " Numero: " + unaTarjeta.Numero + " Codigo de Seguridad: " +
                unaTarjeta.CodigoSeguridad + " Fecha de Vencimiento: " +
                unaTarjeta.FechaVencimiento + "Categoria: " + unaTarjeta.Categoria +
                "Nota: " + unaTarjeta.NotaOpcional);

            }

            listarTarjetasPorMetodo = usuario.ListarTarjetas();

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

                usuario.AgregarDupla(unaDupla);

                listaDuplas.Add("Nombre : " + unaDupla.NombreUsuario + " Contraseña: " + unaDupla.Contrasenia +
                " Nombre sitio: " + unaDupla.NombreSitioApp + " Categoria: " + unaDupla.Categoria +
                " Nivel de seguridad: " + unaDupla.NivelSeguridadContrasenia);
            }

            listarDuplasPorMetodo = usuario.ListarDuplas();

            CollectionAssert.AreEquivalent(listaDuplas, listarDuplasPorMetodo);
        }

        [TestMethod]
        public void ListarContraseñasCompartidasConmigo()
        {
            string[] contraseniasCompartidasConmigo = { contrasenias[0], contrasenias[1] };
            
            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[0], "queonda");
            Usuario usuarioAlQueCompartoContrasenia = new Usuario(nombres[2], "muymanso");
            Dupla_UsuarioContrasenia primerdupla = new Dupla_UsuarioContrasenia("fing@edu.com", contrasenias[0],
               "Instagram", "", categoria);
            Dupla_UsuarioContrasenia segundadupla = new Dupla_UsuarioContrasenia("soydeort@ort.com.uy", contrasenias[1],
              "Facebook", "", categoria);

            usuarioQueComparteContrasenia.AgregarDupla(primerdupla);
            usuarioQueComparteContrasenia.AgregarDupla(segundadupla);
            usuarioQueComparteContrasenia.CompartirContrasenia(usuarioQueComparteContrasenia.ObtenerDuplas()[0], usuarioAlQueCompartoContrasenia);
            usuarioQueComparteContrasenia.CompartirContrasenia(usuarioQueComparteContrasenia.ObtenerDuplas()[1], usuarioAlQueCompartoContrasenia);

            List<Dupla_UsuarioContrasenia> listaEsperada = new List<Dupla_UsuarioContrasenia> { primerdupla, segundadupla };

            CollectionAssert.AreEquivalent(listaEsperada, usuarioAlQueCompartoContrasenia.ObtenerContraseniasCompartidasConmigo());
        }


        [TestMethod]
        public void ListarContraseñasCompartidasPorMi()
        {
            string[] contraseniasCompartidasPorMi = { contrasenias[1], contrasenias[2] };

            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[2], "tranquilaso");
            Usuario usuarioAlQueCompartoContrasenia = new Usuario(nombres[1], "olapapu");
            
            Dupla_UsuarioContrasenia primerdupla = new Dupla_UsuarioContrasenia(nombres[2], contrasenias[1],
              "Instagram", "", categoria);
            Dupla_UsuarioContrasenia segundadupla = new Dupla_UsuarioContrasenia(nombres[1], contrasenias[2],
              "Facebook", "", categoria);

            usuarioQueComparteContrasenia.AgregarDupla(primerdupla);
            usuarioQueComparteContrasenia.AgregarDupla(segundadupla);

            usuarioQueComparteContrasenia.CompartirContrasenia(usuarioQueComparteContrasenia.ObtenerDuplas()[0], usuarioAlQueCompartoContrasenia);
            usuarioQueComparteContrasenia.CompartirContrasenia(usuarioQueComparteContrasenia.ObtenerDuplas()[1], usuarioAlQueCompartoContrasenia);

            List<Dupla_UsuarioContrasenia> listaEsperada = new List<Dupla_UsuarioContrasenia> { primerdupla, segundadupla };

            CollectionAssert.AreEquivalent(listaEsperada, usuarioQueComparteContrasenia.ObtenerContraseniasCompartidasPorMi());
        }


        [TestMethod]
        public void UusarioQueDejaDeCompartirContrasenia()
        {
            string[] contraseniasCompartidasPorMi = { contrasenias[1], contrasenias[2] };

            Usuario usuarioAlQueCompartoContrasenia = new Usuario(nombres[1], "olapapu");
            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[2], "tranquilaso");

            Dupla_UsuarioContrasenia primerdupla = new Dupla_UsuarioContrasenia(nombres[2], contrasenias[1],
              "Instagram", "", categoria);
            Dupla_UsuarioContrasenia segundadupla = new Dupla_UsuarioContrasenia(nombres[1], contrasenias[2],
              "Facebook", "", categoria);

            usuarioQueComparteContrasenia.AgregarDupla(primerdupla);
            usuarioQueComparteContrasenia.AgregarDupla(segundadupla);

            usuarioQueComparteContrasenia.CompartirContrasenia(usuarioQueComparteContrasenia.ObtenerDuplas()[0], usuarioAlQueCompartoContrasenia);
            usuarioQueComparteContrasenia.CompartirContrasenia(usuarioQueComparteContrasenia.ObtenerDuplas()[1], usuarioAlQueCompartoContrasenia);
            usuarioQueComparteContrasenia.DejarDeCompartirContrasenia(usuarioQueComparteContrasenia.ObtenerDuplas()[0], usuarioAlQueCompartoContrasenia);

            List<Dupla_UsuarioContrasenia> listaEsperada = new List<Dupla_UsuarioContrasenia> { segundadupla };

            CollectionAssert.AreEquivalent(listaEsperada, usuarioQueComparteContrasenia.ObtenerContraseniasCompartidasPorMi());
        }

        [TestMethod]
        public void UsuarioQueLeDejanDeCompartirContrasenia()
        {
            string[] contraseniasCompartidasPorMi = { contrasenias[1], contrasenias[2] };

            Usuario usuarioAlQueCompartoContrasenia = new Usuario(nombres[1], "olapapu");
            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[2], "tranquilaso");

            Dupla_UsuarioContrasenia primerdupla = new Dupla_UsuarioContrasenia(nombres[2], contrasenias[1],
              "Instagram", "", categoria);
            Dupla_UsuarioContrasenia segundadupla = new Dupla_UsuarioContrasenia(nombres[1], contrasenias[2],
              "Facebook", "", categoria);

            usuarioQueComparteContrasenia.AgregarDupla(primerdupla);
            usuarioQueComparteContrasenia.AgregarDupla(segundadupla);

            usuarioQueComparteContrasenia.CompartirContrasenia(usuarioQueComparteContrasenia.ObtenerDuplas()[0], usuarioAlQueCompartoContrasenia);
            usuarioQueComparteContrasenia.CompartirContrasenia(usuarioQueComparteContrasenia.ObtenerDuplas()[1], usuarioAlQueCompartoContrasenia);
            usuarioQueComparteContrasenia.DejarDeCompartirContrasenia(usuarioQueComparteContrasenia.ObtenerDuplas()[1], usuarioAlQueCompartoContrasenia);

            List<Dupla_UsuarioContrasenia> listaEsperada = new List<Dupla_UsuarioContrasenia> { primerdupla };
            CollectionAssert.AreEquivalent(listaEsperada, usuarioAlQueCompartoContrasenia.ObtenerContraseniasCompartidasConmigo());
        }


        [TestMethod]
        public void ActualizarContraseñaQueComparto()
        {

            string[] contraseniasCompartidasPorMi = { contrasenias[1], contrasenias[2] };

            Usuario usuarioAlQueCompartoContrasenia = new Usuario(nombres[1], "olapapu");
            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[2], "tranquilaso");

            Dupla_UsuarioContrasenia primerdupla = new Dupla_UsuarioContrasenia(nombres[2], contrasenias[1],
              "Instagram", "", categoria);
            Dupla_UsuarioContrasenia segundadupla = new Dupla_UsuarioContrasenia(nombres[1], contrasenias[2],
              "Facebook", "", categoria);

            usuarioQueComparteContrasenia.AgregarDupla(primerdupla);
            usuarioQueComparteContrasenia.AgregarDupla(segundadupla);

            usuarioQueComparteContrasenia.CompartirContrasenia(usuarioQueComparteContrasenia.ObtenerDuplas()[0], usuarioAlQueCompartoContrasenia);
            usuarioQueComparteContrasenia.CompartirContrasenia(usuarioQueComparteContrasenia.ObtenerDuplas()[1], usuarioAlQueCompartoContrasenia);
            primerdupla.ActualizarContrasenia("nuevaPassword");

            List<Dupla_UsuarioContrasenia> listaEsperada = new List<Dupla_UsuarioContrasenia> { primerdupla, segundadupla };

            CollectionAssert.AreEquivalent(listaEsperada, usuarioQueComparteContrasenia.ObtenerContraseniasCompartidasPorMi());
        }

        [TestMethod]
        public void ActualizarContraseñaQueMeComparten()
        {
            string[] contraseniasCompartidasPorMi = { contrasenias[1], contrasenias[2] };

            Usuario usuarioAlQueCompartoContrasenia = new Usuario(nombres[1], "olapapu");
            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[2], "tranquilaso");

            Dupla_UsuarioContrasenia primerdupla = new Dupla_UsuarioContrasenia(nombres[2], contrasenias[1],
              "Instagram", "", categoria);
            Dupla_UsuarioContrasenia segundadupla = new Dupla_UsuarioContrasenia(nombres[1], contrasenias[2],
              "Facebook", "", categoria);

            usuarioQueComparteContrasenia.AgregarDupla(primerdupla);
            usuarioQueComparteContrasenia.AgregarDupla(segundadupla);

            usuarioQueComparteContrasenia.CompartirContrasenia(usuarioQueComparteContrasenia.ObtenerDuplas()[0], usuarioAlQueCompartoContrasenia);
            usuarioQueComparteContrasenia.CompartirContrasenia(usuarioQueComparteContrasenia.ObtenerDuplas()[1], usuarioAlQueCompartoContrasenia);
            segundadupla.ActualizarContrasenia("otraPassword");

            List<Dupla_UsuarioContrasenia> listaEsperada = new List<Dupla_UsuarioContrasenia> { primerdupla, segundadupla };
            CollectionAssert.AreEquivalent(listaEsperada, usuarioAlQueCompartoContrasenia.ObtenerContraseniasCompartidasConmigo());
        }

    }
}
