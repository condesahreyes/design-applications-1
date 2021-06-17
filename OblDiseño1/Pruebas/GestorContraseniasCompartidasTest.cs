using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using OblDiseño1.Entidades;
using System.Text;
using OblDiseño1;
using System;

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
        private Contraseña contraseña1;
        private Contraseña contraseña2;
        private Contraseña contraseña3;
        private GestorContraseniasCompartidas miGestor;

        [TestInitialize]
        public void Setup()
        {
            InicializarDatos();
            CrearContraseñas();
            CrearCredencial();
        }
        
        private void InicializarDatos()
        {
            notaDupla = "";
            nombreSitioDupla = "Instagram";
        }

        private void CrearContraseñas()
        {
            contraseña1 = new Contraseña(contrasenias[0]);
            contraseña2 = new Contraseña(contrasenias[1]);
            contraseña3 = new Contraseña(contrasenias[2]);
        }

        private void CrearCredencial()
        {
            credencial = new Credencial(nombres[1], contraseña1,
                        nombreSitioDupla, notaDupla, categoria);
        }

        [TestMethod]
        public void ListarContraseñasQueComparto()
        {
            Usuario usuarioQueComparteContrasenia = CrearUnUsuario(nombres[0], "queonda");
            Usuario usuarioAlQueCompartoContrasenia = CrearUnUsuario(nombres[2], "muymanso");

            Credencial primerCredencial = new Credencial("fing@edu.com", contraseña1,
               "Instagram", "", categoria);
            Credencial segundadupla = new Credencial("soydeort@ort.com.uy", contraseña2,
              "Facebook", "", categoria);

            usuarioQueComparteContrasenia.AgregarCredencial(primerCredencial);
            usuarioQueComparteContrasenia.AgregarCredencial(segundadupla);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            CompartirContraseña(ref miGestor, ref usuarioQueComparteContrasenia, 
                ref usuarioAlQueCompartoContrasenia, 0, 1);

            List<string> listaEsperada = new List<string> { primerCredencial.ToString(), 
                segundadupla.ToString() };

            CollectionAssert.AreEquivalent(listaEsperada, miGestor.
                ConvertirContraseñasCompartidasPorMiAListaString
                (miGestor.ObtenerContraseniasCompartidasPorMi()));
        }

        [TestMethod]
        public void ListarContraseñasQueMeComparten()
        {
            Usuario usuarioQueQueMeComparteContrasenia = CrearUnUsuario(nombres[2], "tranquilaso");
            Usuario usuarioAlQueLeCompartenContrasenia = CrearUnUsuario(nombres[1], "olapapu");

            Credencial primerCredencial = new Credencial(nombres[2], contraseña1,
              "Instagram", "", categoria);
            Credencial segundaCredencial= new Credencial(nombres[1], contraseña2,
              "Facebook", "", categoria);

            usuarioQueQueMeComparteContrasenia.AgregarCredencial(primerCredencial);
            usuarioQueQueMeComparteContrasenia.AgregarCredencial(segundaCredencial);

            miGestor = usuarioQueQueMeComparteContrasenia.GestorCompartirContrasenia;

            GestorContraseniasCompartidas gestorAux = usuarioAlQueLeCompartenContrasenia.
                GestorCompartirContrasenia;

            CompartirContraseña(ref miGestor, ref usuarioQueQueMeComparteContrasenia, ref usuarioAlQueLeCompartenContrasenia, 0, 1);

            List<string> listaEsperada = new List<string> { primerCredencial.ToString(), 
                segundaCredencial.ToString() };

            CollectionAssert.AreEquivalent(listaEsperada, miGestor.
                ConvertirContraseñasCompartidasConmigoAListaString(gestorAux.
                ObtenerContraseniasCompartidasConmigo()));
        }

        [TestMethod]
        public void UusarioQueDejaDeCompartirContrasenia()
        {
            Usuario usuarioAlQueCompartoContrasenia = CrearUnUsuario(nombres[1], "olapapu");
            Usuario usuarioQueComparteContrasenia = CrearUnUsuario(nombres[2], "tranquilaso");

            Credencial primerCredencial = new Credencial(nombres[2], contraseña2,
              "Instagram", "", categoria);
            Credencial segundadupla = new Credencial(nombres[1], contraseña3,
              "Facebook", "", categoria);

            usuarioQueComparteContrasenia.AgregarCredencial(primerCredencial);
            usuarioQueComparteContrasenia.AgregarCredencial(segundadupla);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            CompartirContraseña(ref miGestor, ref usuarioQueComparteContrasenia, ref usuarioAlQueCompartoContrasenia, 0, 1);

            miGestor.DejarDeCompartirContrasenia(usuarioQueComparteContrasenia.ObtenerCredenciales()[0], usuarioAlQueCompartoContrasenia);

            Assert.IsFalse(miGestor.VerificarQueEstaSiendoCompartidaLaContraseniaConElUsuario(primerCredencial, usuarioAlQueCompartoContrasenia));
        }

        [TestMethod]
        public void UsuarioQueLeDejanDeCompartirContrasenia()
        {
            Usuario usuarioAlQueCompartoContrasenia = CrearUnUsuario(nombres[1], "olapapu");
            Usuario usuarioQueComparteContrasenia = CrearUnUsuario(nombres[2], "tranquilaso");

            Credencial primerCredencial = new Credencial(nombres[2], contraseña2,
              "Instagram", "", categoria);
            Credencial segundadupla = new Credencial(nombres[1], contraseña3,
              "Facebook", "", categoria);

            usuarioQueComparteContrasenia.AgregarCredencial(primerCredencial);
            usuarioQueComparteContrasenia.AgregarCredencial(segundadupla);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            GestorContraseniasCompartidas gestorAux = usuarioAlQueCompartoContrasenia.GestorCompartirContrasenia;

            CompartirContraseña(ref miGestor, ref usuarioQueComparteContrasenia, ref usuarioAlQueCompartoContrasenia, 0, 1);

            miGestor.DejarDeCompartirContrasenia(usuarioQueComparteContrasenia.
                ObtenerCredenciales()[1], usuarioAlQueCompartoContrasenia);

            List<string> listaEsperada = new List<string> { primerCredencial.ToString() };
            CollectionAssert.AreEquivalent(listaEsperada, gestorAux.
                ConvertirContraseñasCompartidasConmigoAListaString(gestorAux.ObtenerContraseniasCompartidasConmigo()));
        }

        [TestMethod]
        public void ActualizarContraseñaQueComparto()
        {
            Usuario usuarioAlQueCompartoContrasenia = CrearUnUsuario(nombres[1], "olapapu");
            Usuario usuarioQueComparteContrasenia = CrearUnUsuario(nombres[2], "tranquilaso");

            Credencial primerCredencial = new Credencial(nombres[2], contraseña2,
              "Instagram", "", categoria);
            Credencial segundadupla = new Credencial(nombres[1], contraseña3,
              "Facebook", "", categoria);

            usuarioQueComparteContrasenia.AgregarCredencial(primerCredencial);
            usuarioQueComparteContrasenia.AgregarCredencial(segundadupla);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            CompartirContraseña(ref miGestor, ref usuarioQueComparteContrasenia, ref usuarioAlQueCompartoContrasenia, 0, 1);

            primerCredencial.Contraseña.ActualizarContrasenia("nuevaPassword");

            List<string> listaEsperada = new List<string> { primerCredencial.ToString(), segundadupla.ToString() };

            CollectionAssert.AreEquivalent(listaEsperada, miGestor.
                ConvertirContraseñasCompartidasPorMiAListaString(miGestor.ObtenerContraseniasCompartidasPorMi()));
        }

        [TestMethod]
        public void ActualizarContraseñaQueMeComparten()
        {
            Usuario usuarioAlQueCompartoContrasenia = CrearUnUsuario(nombres[1], "olapapu");
            Usuario usuarioQueComparteContrasenia = CrearUnUsuario(nombres[2], "tranquilaso");

            Credencial primerCredencial = new Credencial(nombres[2], contraseña2,
              "Instagram", "", categoria);
            Credencial segundadupla = new Credencial(nombres[1], contraseña3,
              "Facebook", "", categoria);

            usuarioQueComparteContrasenia.AgregarCredencial(primerCredencial);
            usuarioQueComparteContrasenia.AgregarCredencial(segundadupla);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            GestorContraseniasCompartidas gestorAux = usuarioAlQueCompartoContrasenia.GestorCompartirContrasenia;

            CompartirContraseña(ref miGestor, ref usuarioQueComparteContrasenia, ref usuarioAlQueCompartoContrasenia, 0, 1);

            segundadupla.Contraseña.ActualizarContrasenia("otraPassword");

            List<string> listaEsperada = new List<string> { primerCredencial.ToString(), segundadupla.ToString() };
            CollectionAssert.AreEquivalent(listaEsperada, gestorAux.
                ConvertirContraseñasCompartidasConmigoAListaString(gestorAux.ObtenerContraseniasCompartidasConmigo()));
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionInvalidUsuarioData))]
        public void CompartirLaMismaContraseniaConElMismoUsuario()
        {
            Usuario usuarioQueComparteContrasenia = CrearUnUsuario(nombres[0], "queonda");
            Usuario usuarioAlQueCompartoContrasenia = CrearUnUsuario(nombres[2], "muymanso");

            Credencial primerCredencial = new Credencial("fing@edu.com", contraseña1,
               "Instagram", "", categoria);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            usuarioQueComparteContrasenia.AgregarCredencial(primerCredencial);

            CompartirContraseña(ref miGestor, ref usuarioQueComparteContrasenia, 
                ref usuarioAlQueCompartoContrasenia, 0, 0);

            List<string> listaEsperada = new List<string> { primerCredencial.ToString() };

            CollectionAssert.AreEquivalent(listaEsperada, miGestor.
                ConvertirContraseñasCompartidasPorMiAListaString(miGestor.ObtenerContraseniasCompartidasPorMi()));
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionInvalidUsuarioData))]
        public void CompartirUnaContraseniaQueNoTengoEnMiLista()
        {
            Usuario usuarioQueComparteContrasenia = CrearUnUsuario(nombres[0], "queonda");
            Usuario usuarioAlQueCompartoContrasenia = CrearUnUsuario(nombres[2], "muymanso");

            Credencial primerCredencial = new Credencial("fing@edu.com", contraseña1,
               "Instagram", "", categoria);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            miGestor.funcionCompartir(primerCredencial, usuarioAlQueCompartoContrasenia);
        }

        [TestMethod]
        public void CompartirUnaContraseniaCon2UsuariosDiferentes()
        {
            Usuario usuarioQueComparteContrasenia = CrearUnUsuario(nombres[0], "queonda");
            Usuario primerUsuarioAlQueCompartoContrasenia = CrearUnUsuario(nombres[2], "muymanso");
            Usuario segundaUsuarioAlQueCompartoContrasenia = CrearUnUsuario(nombres[1], "kondacabron");

            Credencial primerCredencial = new Credencial("fing@edu.com", contraseña1,
               "Instagram", "", categoria);

            miGestor = usuarioQueComparteContrasenia.GestorCompartirContrasenia;

            usuarioQueComparteContrasenia.AgregarCredencial(primerCredencial);

            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerCredenciales()[0], primerUsuarioAlQueCompartoContrasenia);
            miGestor.funcionCompartir(usuarioQueComparteContrasenia.ObtenerCredenciales()[0], segundaUsuarioAlQueCompartoContrasenia);
            List<Usuario> listaEsperada = new List<Usuario> { primerUsuarioAlQueCompartoContrasenia, segundaUsuarioAlQueCompartoContrasenia};
            List<Usuario> listaResultante = new List<Usuario>();
            listaResultante = miGestor.ObtenerContraseniasCompartidasPorMi()[primerCredencial];

            CollectionAssert.AreEquivalent(listaEsperada, listaResultante);
        }

        private Usuario CrearUnUsuario(string nombre, string contraseña)
        {
            return new Usuario(nombre, contraseña);
        }

        private void CompartirContraseña(ref GestorContraseniasCompartidas miGestor, ref Usuario queComparte, 
            ref Usuario alQueComparte, int pos1, int pos2)
        {
            miGestor.funcionCompartir(queComparte.ObtenerCredenciales()[pos1], alQueComparte);
            miGestor.funcionCompartir(queComparte.ObtenerCredenciales()[pos2], alQueComparte);
        }
    }
}