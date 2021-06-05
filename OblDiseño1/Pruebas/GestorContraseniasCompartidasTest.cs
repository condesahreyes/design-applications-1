using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1;
using OblDiseño1.Entidades;

namespace Pruebas
{
    [TestClass]
    public class GestorContraseniasCompartidasTest
    {
        private static string notaDupla;
        private static string nombreSitioDupla;

        private static string[] contrasenias = {"contrasenia123",
            "1234Contrasenia", "laContraseña"};

        private static string[] nombres = { "Hernán", "Santiago", "Rodrigo" };

        string[] contraseniasCompartidasPorMi = { contrasenias[1], contrasenias[2] };

        private Categoria categoria;
        private Dupla_UsuarioContrasenia dupla;
        Contraseña contraseña1;
        Contraseña contraseña2;
        Contraseña contraseña3;
        private GestorContraseniasCompartidas miGestor;

        [TestInitialize]
        public void Setup()
        {
            notaDupla = "";
            nombreSitioDupla = "Instagram";
            contraseña1 = new Contraseña(contrasenias[0]);
            contraseña2 = new Contraseña(contrasenias[1]);
            contraseña3 = new Contraseña(contrasenias[2]);

            dupla = new Dupla_UsuarioContrasenia(nombres[1], contraseña1,
                nombreSitioDupla, notaDupla, categoria);
        }

        [TestMethod]
        public void ListarContraseñasQueComparto()
        {

            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[0], "queonda");
            Usuario usuarioAlQueCompartoContrasenia = new Usuario(nombres[2], "muymanso");
            Dupla_UsuarioContrasenia primerdupla = new Dupla_UsuarioContrasenia("fing@edu.com", contraseña1,
               "Instagram", "", categoria);
            Dupla_UsuarioContrasenia segundadupla = new Dupla_UsuarioContrasenia("soydeort@ort.com.uy", contraseña2,
              "Facebook", "", categoria);

            usuarioQueComparteContrasenia.AgregarDupla(primerdupla);
            usuarioQueComparteContrasenia.AgregarDupla(segundadupla);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerDuplas()[0], usuarioAlQueCompartoContrasenia);
            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerDuplas()[1], usuarioAlQueCompartoContrasenia);

            List<string> listaEsperada = new List<string> { primerdupla.ToString(), segundadupla.ToString() };

            CollectionAssert.AreEquivalent(listaEsperada, miGestor.ConvertirContraseñasCompartidasPorMiAListaString(miGestor.ObtenerContraseniasCompartidasPorMi()));
        }

        [TestMethod]
        public void ListarContraseñasQueMeComparten()
        {

            Usuario usuarioQueQueMeComparteContrasenia = new Usuario(nombres[2], "tranquilaso");
            Usuario usuarioAlQueLeCompartenContrasenia = new Usuario(nombres[1], "olapapu");

            Dupla_UsuarioContrasenia primerdupla = new Dupla_UsuarioContrasenia(nombres[2], contraseña1,
              "Instagram", "", categoria);
            Dupla_UsuarioContrasenia segundadupla = new Dupla_UsuarioContrasenia(nombres[1], contraseña2,
              "Facebook", "", categoria);

            usuarioQueQueMeComparteContrasenia.AgregarDupla(primerdupla);
            usuarioQueQueMeComparteContrasenia.AgregarDupla(segundadupla);

            miGestor = usuarioQueQueMeComparteContrasenia.GestorCompartirContrasenia;

            GestorContraseniasCompartidas gestorAux = usuarioAlQueLeCompartenContrasenia.GestorCompartirContrasenia;

            miGestor.funcionCompartir(usuarioQueQueMeComparteContrasenia.ObtenerDuplas()[0], usuarioAlQueLeCompartenContrasenia);
            miGestor.funcionCompartir(usuarioQueQueMeComparteContrasenia.ObtenerDuplas()[1], usuarioAlQueLeCompartenContrasenia);

            List<string> listaEsperada = new List<string> { primerdupla.ToString(), segundadupla.ToString() };

            CollectionAssert.AreEquivalent(listaEsperada, miGestor.ConvertirContraseñasCompartidasConmigoAListaString(gestorAux.ObtenerContraseniasCompartidasConmigo()));
        }

        [TestMethod]
        public void UusarioQueDejaDeCompartirContrasenia()
        {

            Usuario usuarioAlQueCompartoContrasenia = new Usuario(nombres[1], "olapapu");
            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[2], "tranquilaso");

            Dupla_UsuarioContrasenia primerdupla = new Dupla_UsuarioContrasenia(nombres[2], contraseña2,
              "Instagram", "", categoria);
            Dupla_UsuarioContrasenia segundadupla = new Dupla_UsuarioContrasenia(nombres[1], contraseña3,
              "Facebook", "", categoria);

            usuarioQueComparteContrasenia.AgregarDupla(primerdupla);
            usuarioQueComparteContrasenia.AgregarDupla(segundadupla);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerDuplas()[0], usuarioAlQueCompartoContrasenia);
            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerDuplas()[1], usuarioAlQueCompartoContrasenia);
            miGestor.DejarDeCompartirContrasenia(usuarioQueComparteContrasenia.ObtenerDuplas()[0], usuarioAlQueCompartoContrasenia);


            Assert.IsFalse(miGestor.VerificarQueEstaSiendoCompartidaLaContraseniaConElUsuario(primerdupla, usuarioAlQueCompartoContrasenia));
        }

        [TestMethod]
        public void UsuarioQueLeDejanDeCompartirContrasenia()
        {

            Usuario usuarioAlQueCompartoContrasenia = new Usuario(nombres[1], "olapapu");
            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[2], "tranquilaso");

            Dupla_UsuarioContrasenia primerdupla = new Dupla_UsuarioContrasenia(nombres[2], contraseña2,
              "Instagram", "", categoria);
            Dupla_UsuarioContrasenia segundadupla = new Dupla_UsuarioContrasenia(nombres[1], contraseña3,
              "Facebook", "", categoria);

            usuarioQueComparteContrasenia.AgregarDupla(primerdupla);
            usuarioQueComparteContrasenia.AgregarDupla(segundadupla);


            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            GestorContraseniasCompartidas gestorAux = usuarioAlQueCompartoContrasenia.GestorCompartirContrasenia;

            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerDuplas()[0], usuarioAlQueCompartoContrasenia);
            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerDuplas()[1], usuarioAlQueCompartoContrasenia);
            miGestor.DejarDeCompartirContrasenia(usuarioQueComparteContrasenia.ObtenerDuplas()[1], usuarioAlQueCompartoContrasenia);

            List<string> listaEsperada = new List<string> { primerdupla.ToString() };
            CollectionAssert.AreEquivalent(listaEsperada, gestorAux.ConvertirContraseñasCompartidasConmigoAListaString(gestorAux.ObtenerContraseniasCompartidasConmigo()));
        }

        [TestMethod]
        public void ActualizarContraseñaQueComparto()
        {

            Usuario usuarioAlQueCompartoContrasenia = new Usuario(nombres[1], "olapapu");
            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[2], "tranquilaso");

            Dupla_UsuarioContrasenia primerdupla = new Dupla_UsuarioContrasenia(nombres[2], contraseña2,
              "Instagram", "", categoria);
            Dupla_UsuarioContrasenia segundadupla = new Dupla_UsuarioContrasenia(nombres[1], contraseña3,
              "Facebook", "", categoria);

            usuarioQueComparteContrasenia.AgregarDupla(primerdupla);
            usuarioQueComparteContrasenia.AgregarDupla(segundadupla);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;


            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerDuplas()[0], usuarioAlQueCompartoContrasenia);
            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerDuplas()[1], usuarioAlQueCompartoContrasenia);
            primerdupla.Contraseña.ActualizarContrasenia("nuevaPassword");

            List<string> listaEsperada = new List<string> { primerdupla.ToString(), segundadupla.ToString() };

            CollectionAssert.AreEquivalent(listaEsperada, miGestor.ConvertirContraseñasCompartidasPorMiAListaString(miGestor.ObtenerContraseniasCompartidasPorMi()));
        }

        [TestMethod]
        public void ActualizarContraseñaQueMeComparten()
        {
            string[] contraseniasCompartidasPorMi = { contrasenias[1], contrasenias[2] };

            Usuario usuarioAlQueCompartoContrasenia = new Usuario(nombres[1], "olapapu");
            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[2], "tranquilaso");

            Dupla_UsuarioContrasenia primerdupla = new Dupla_UsuarioContrasenia(nombres[2], contraseña2,
              "Instagram", "", categoria);
            Dupla_UsuarioContrasenia segundadupla = new Dupla_UsuarioContrasenia(nombres[1], contraseña3,
              "Facebook", "", categoria);

            usuarioQueComparteContrasenia.AgregarDupla(primerdupla);
            usuarioQueComparteContrasenia.AgregarDupla(segundadupla);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            GestorContraseniasCompartidas gestorAux = usuarioAlQueCompartoContrasenia.GestorCompartirContrasenia;

            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerDuplas()[0], usuarioAlQueCompartoContrasenia);
            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerDuplas()[1], usuarioAlQueCompartoContrasenia);
            segundadupla.Contraseña.ActualizarContrasenia("otraPassword");

            List<string> listaEsperada = new List<string> { primerdupla.ToString(), segundadupla.ToString() };
            CollectionAssert.AreEquivalent(listaEsperada, gestorAux.ConvertirContraseñasCompartidasConmigoAListaString(gestorAux.ObtenerContraseniasCompartidasConmigo()));
        }

        [TestMethod]
        [ExpectedException(typeof(Exepcion_InvalidUsuarioData))]
        public void CompartirLaMismaContraseniaConElMismoUsuario()
        {
            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[0], "queonda");
            Usuario usuarioAlQueCompartoContrasenia = new Usuario(nombres[2], "muymanso");
            Dupla_UsuarioContrasenia primerdupla = new Dupla_UsuarioContrasenia("fing@edu.com", contraseña1,
               "Instagram", "", categoria);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            usuarioQueComparteContrasenia.AgregarDupla(primerdupla);
            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerDuplas()[0], usuarioAlQueCompartoContrasenia);
            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerDuplas()[0], usuarioAlQueCompartoContrasenia);
            List<string> listaEsperada = new List<string> { primerdupla.ToString() };

            CollectionAssert.AreEquivalent(listaEsperada, miGestor.ConvertirContraseñasCompartidasPorMiAListaString(miGestor.ObtenerContraseniasCompartidasPorMi()));
        }

        [TestMethod]
        [ExpectedException(typeof(Exepcion_InvalidUsuarioData))]
        public void CompartirUnaContraseniaQueNoTengoEnMiLista()
        {
            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[0], "queonda");
            Usuario usuarioAlQueCompartoContrasenia = new Usuario(nombres[2], "muymanso");
            Dupla_UsuarioContrasenia primerdupla = new Dupla_UsuarioContrasenia("fing@edu.com", contraseña1,
               "Instagram", "", categoria);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            miGestor.funcionCompartir(primerdupla, usuarioAlQueCompartoContrasenia);
        }

        [TestMethod]
        public void CompartirUnaContraseniaCon2UsuariosDiferentes()
        {
            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[0], "queonda");
            Usuario primerUsuarioAlQueCompartoContrasenia = new Usuario(nombres[2], "muymanso");
            Usuario segundaUsuarioAlQueCompartoContrasenia = new Usuario(nombres[1], "kondacabron");

            Dupla_UsuarioContrasenia primerdupla = new Dupla_UsuarioContrasenia("fing@edu.com", contraseña1,
               "Instagram", "", categoria);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            usuarioQueComparteContrasenia.AgregarDupla(primerdupla);
            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerDuplas()[0], primerUsuarioAlQueCompartoContrasenia);
            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerDuplas()[0], segundaUsuarioAlQueCompartoContrasenia);
            List<Usuario> listaEsperada = new List<Usuario> { primerUsuarioAlQueCompartoContrasenia, segundaUsuarioAlQueCompartoContrasenia };
            List<Usuario> listaResultante = new List<Usuario>();
            listaResultante = miGestor.ObtenerContraseniasCompartidasPorMi()[primerdupla];

            CollectionAssert.AreEquivalent(listaEsperada, listaResultante);
        }
    }
}
