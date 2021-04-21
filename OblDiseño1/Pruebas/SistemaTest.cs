using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1;

namespace Pruebas
{
    [TestClass]
    public class SistemaTest
    {

        private Sistema sistema;

        private static string[] contrasenias = {"contrasenia123",
            "1234Contrasenia", "laContraseña"};

        private static string[] nombres = { "Hernán", "Santiago", "Rodrigo" };

        [TestInitialize]
        public void Setup()
        {
            this.sistema = new Sistema();
        }

        [TestMethod]
        public void AgregarUsuariosNuevos()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            for (int i = 0; i < nombres.Length; i++)
            {
                Usuario usuario = new Usuario(nombres[i], contrasenias[i]);
                sistema.AgregarUsuario(usuario);
                listaUsuarios.Add(usuario);
            }

            CollectionAssert.AreEquivalent(listaUsuarios, sistema.ObtenerUsuarios);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionObjetosRepetidos))]
        public void IntentarAgregarUsuariosRepetidos()
        {
            string nombreAux = nombres[0];

            Usuario usuario1 = new Usuario(nombres[0], contrasenias[0]);
            Usuario usuario2 = new Usuario(nombreAux, contrasenias[1]);

            sistema.AgregarUsuario(usuario1);
            sistema.AgregarUsuario(usuario2);
        }


    }
}
