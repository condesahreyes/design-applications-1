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

        private Categoria categoria;
        private Credencial credencial;
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

            credencial = new Credencial(nombres[1], contraseña1,
                nombreSitioDupla, notaDupla, categoria);
        }

        [TestMethod]
        public void ListarContraseñasQueComparto()
        {
            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[0], "queonda");
            Usuario usuarioAlQueCompartoContrasenia = new Usuario(nombres[2], "muymanso");

            Credencial primerCredencial = new Credencial("fing@edu.com", contraseña1,
               "Instagram", "", categoria);
            Credencial segundadupla = new Credencial("soydeort@ort.com.uy", contraseña2,
              "Facebook", "", categoria);


            usuarioQueComparteContrasenia.AgregarCredencial(primerCredencial);
            usuarioQueComparteContrasenia.AgregarCredencial(segundadupla);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerCredenciales()[0], usuarioAlQueCompartoContrasenia);
            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerCredenciales()[1], usuarioAlQueCompartoContrasenia);

            List<string> listaEsperada = new List<string> { primerCredencial.ToString(), segundadupla.ToString() };

            CollectionAssert.AreEquivalent(listaEsperada, miGestor.
                ConvertirContraseñasCompartidasPorMiAListaString(miGestor.ObtenerContraseniasCompartidasPorMi()));
        }

        [TestMethod]
        public void ListarContraseñasQueMeComparten()
        {

            Usuario usuarioQueQueMeComparteContrasenia = new Usuario(nombres[2], "tranquilaso");
            Usuario usuarioAlQueLeCompartenContrasenia = new Usuario(nombres[1], "olapapu");

            Credencial primerCredencial = new Credencial(nombres[2], contraseña1,
              "Instagram", "", categoria);
            Credencial segundaCredencial= new Credencial(nombres[1], contraseña2,
              "Facebook", "", categoria);

            usuarioQueQueMeComparteContrasenia.AgregarCredencial(primerCredencial);
            usuarioQueQueMeComparteContrasenia.AgregarCredencial(segundaCredencial);

            miGestor = usuarioQueQueMeComparteContrasenia.GestorCompartirContrasenia;

            GestorContraseniasCompartidas gestorAux = usuarioAlQueLeCompartenContrasenia.GestorCompartirContrasenia;

            miGestor.funcionCompartir(usuarioQueQueMeComparteContrasenia.ObtenerCredenciales()[0], usuarioAlQueLeCompartenContrasenia);
            miGestor.funcionCompartir(usuarioQueQueMeComparteContrasenia.ObtenerCredenciales()[1], usuarioAlQueLeCompartenContrasenia);

            List<string> listaEsperada = new List<string> { primerCredencial.ToString(), segundaCredencial.ToString() };

            CollectionAssert.AreEquivalent(listaEsperada, miGestor.
                ConvertirContraseñasCompartidasConmigoAListaString(gestorAux.ObtenerContraseniasCompartidasConmigo()));
        }

        [TestMethod]
        public void UusarioQueDejaDeCompartirContrasenia()
        {

            Usuario usuarioAlQueCompartoContrasenia = new Usuario(nombres[1], "olapapu");
            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[2], "tranquilaso");

            Credencial primerCredencial = new Credencial(nombres[2], contraseña2,
              "Instagram", "", categoria);
            Credencial segundadupla = new Credencial(nombres[1], contraseña3,
              "Facebook", "", categoria);

            usuarioQueComparteContrasenia.AgregarCredencial(primerCredencial);
            usuarioQueComparteContrasenia.AgregarCredencial(segundadupla);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerCredenciales()[0], usuarioAlQueCompartoContrasenia);
            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerCredenciales()[1], usuarioAlQueCompartoContrasenia);
            miGestor.DejarDeCompartirContrasenia(usuarioQueComparteContrasenia.ObtenerCredenciales()[0], usuarioAlQueCompartoContrasenia);


            Assert.IsFalse(miGestor.VerificarQueEstaSiendoCompartidaLaContraseniaConElUsuario(primerCredencial, usuarioAlQueCompartoContrasenia));
        }

        [TestMethod]
        public void UsuarioQueLeDejanDeCompartirContrasenia()
        {

            Usuario usuarioAlQueCompartoContrasenia = new Usuario(nombres[1], "olapapu");
            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[2], "tranquilaso");

            Credencial primerCredencial = new Credencial(nombres[2], contraseña2,
              "Instagram", "", categoria);
            Credencial segundadupla = new Credencial(nombres[1], contraseña3,
              "Facebook", "", categoria);

            usuarioQueComparteContrasenia.AgregarCredencial(primerCredencial);
            usuarioQueComparteContrasenia.AgregarCredencial(segundadupla);


            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            GestorContraseniasCompartidas gestorAux = usuarioAlQueCompartoContrasenia.GestorCompartirContrasenia;

            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerCredenciales()[0], usuarioAlQueCompartoContrasenia);
            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerCredenciales()[1], usuarioAlQueCompartoContrasenia);
            miGestor.DejarDeCompartirContrasenia(usuarioQueComparteContrasenia.ObtenerCredenciales()[1], usuarioAlQueCompartoContrasenia);

            List<string> listaEsperada = new List<string> { primerCredencial.ToString() };
            CollectionAssert.AreEquivalent(listaEsperada, gestorAux.ConvertirContraseñasCompartidasConmigoAListaString(gestorAux.ObtenerContraseniasCompartidasConmigo()));
        }

        [TestMethod]
        public void ActualizarContraseñaQueComparto()
        {

            Usuario usuarioAlQueCompartoContrasenia = new Usuario(nombres[1], "olapapu");
            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[2], "tranquilaso");

            Credencial primerCredencial = new Credencial(nombres[2], contraseña2,
              "Instagram", "", categoria);
            Credencial segundadupla = new Credencial(nombres[1], contraseña3,
              "Facebook", "", categoria);

            usuarioQueComparteContrasenia.AgregarCredencial(primerCredencial);
            usuarioQueComparteContrasenia.AgregarCredencial(segundadupla);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;


            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerCredenciales()[0], usuarioAlQueCompartoContrasenia);
            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerCredenciales()[1], usuarioAlQueCompartoContrasenia);
            primerCredencial.Contraseña.ActualizarContrasenia("nuevaPassword");

            List<string> listaEsperada = new List<string> { primerCredencial.ToString(), segundadupla.ToString() };

            CollectionAssert.AreEquivalent(listaEsperada, miGestor.ConvertirContraseñasCompartidasPorMiAListaString(miGestor.ObtenerContraseniasCompartidasPorMi()));
        }

        [TestMethod]
        public void ActualizarContraseñaQueMeComparten()
        {
            string[] contraseniasCompartidasPorMi = { contrasenias[1], contrasenias[2] };

            Usuario usuarioAlQueCompartoContrasenia = new Usuario(nombres[1], "olapapu");
            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[2], "tranquilaso");

            Credencial primerCredencial = new Credencial(nombres[2], contraseña2,
              "Instagram", "", categoria);
            Credencial segundadupla = new Credencial(nombres[1], contraseña3,
              "Facebook", "", categoria);

            usuarioQueComparteContrasenia.AgregarCredencial(primerCredencial);
            usuarioQueComparteContrasenia.AgregarCredencial(segundadupla);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            GestorContraseniasCompartidas gestorAux = usuarioAlQueCompartoContrasenia.GestorCompartirContrasenia;

            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerCredenciales()[0], usuarioAlQueCompartoContrasenia);
            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerCredenciales()[1], usuarioAlQueCompartoContrasenia);
            segundadupla.Contraseña.ActualizarContrasenia("otraPassword");

            List<string> listaEsperada = new List<string> { primerCredencial.ToString(), segundadupla.ToString() };
            CollectionAssert.AreEquivalent(listaEsperada, gestorAux.ConvertirContraseñasCompartidasConmigoAListaString(gestorAux.ObtenerContraseniasCompartidasConmigo()));
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionInvalidUsuarioData))]
        public void CompartirLaMismaContraseniaConElMismoUsuario()
        {
            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[0], "queonda");
            Usuario usuarioAlQueCompartoContrasenia = new Usuario(nombres[2], "muymanso");
            Credencial primerCredencial = new Credencial("fing@edu.com", contraseña1,
               "Instagram", "", categoria);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            usuarioQueComparteContrasenia.AgregarCredencial(primerCredencial);
            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerCredenciales()[0], usuarioAlQueCompartoContrasenia);
            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerCredenciales()[0], usuarioAlQueCompartoContrasenia);
            List<string> listaEsperada = new List<string> { primerCredencial.ToString() };

            CollectionAssert.AreEquivalent(listaEsperada, miGestor.ConvertirContraseñasCompartidasPorMiAListaString(miGestor.ObtenerContraseniasCompartidasPorMi()));
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionInvalidUsuarioData))]
        public void CompartirUnaContraseniaQueNoTengoEnMiLista()
        {
            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[0], "queonda");
            Usuario usuarioAlQueCompartoContrasenia = new Usuario(nombres[2], "muymanso");
            Credencial primerCredencial = new Credencial("fing@edu.com", contraseña1,
               "Instagram", "", categoria);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            miGestor.funcionCompartir(primerCredencial, usuarioAlQueCompartoContrasenia);
        }

        [TestMethod]
        public void CompartirUnaContraseniaCon2UsuariosDiferentes()
        {
            Usuario usuarioQueComparteContrasenia = new Usuario(nombres[0], "queonda");
            Usuario primerUsuarioAlQueCompartoContrasenia = new Usuario(nombres[2], "muymanso");
            Usuario segundaUsuarioAlQueCompartoContrasenia = new Usuario(nombres[1], "kondacabron");

            Credencial primerCredencial = new Credencial("fing@edu.com", contraseña1,
               "Instagram", "", categoria);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            usuarioQueComparteContrasenia.AgregarCredencial(primerCredencial);
            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerCredenciales()[0], primerUsuarioAlQueCompartoContrasenia);
            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerCredenciales()[0], segundaUsuarioAlQueCompartoContrasenia);
            List<Usuario> listaEsperada = new List<Usuario> { primerUsuarioAlQueCompartoContrasenia, segundaUsuarioAlQueCompartoContrasenia };
            List<Usuario> listaResultante = new List<Usuario>();
            listaResultante = miGestor.ObtenerContraseniasCompartidasPorMi()[primerCredencial];

            CollectionAssert.AreEquivalent(listaEsperada, listaResultante);
        }
    }
}
