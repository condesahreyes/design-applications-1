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
                sistema.AgregarUsuario(nombres[i], contrasenias[i]);
                listaUsuarios.Add(usuario);
            }

            List<Usuario> usuariosDesdeMetodo = sistema.ObtenerUsuarios();

            CollectionAssert.AreEqual(listaUsuarios, usuariosDesdeMetodo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionObjetosRepetidos))]
        public void IntentarAgregarUsuariosRepetidos()
        {
            string nombreAux = nombres[0];

            sistema.AgregarUsuario(nombres[0], contrasenias[0]);
            sistema.AgregarUsuario(nombreAux, contrasenias[1]);
        }

        [TestMethod]
        public void DevolverUnUsuario()
        {
            Usuario usuarioQueQuiero = null;

            for (int i = 0; i < nombres.Length; i++)
            {
                Usuario usuario = new Usuario(nombres[i], contrasenias[i]);

                if (usuarioQueQuiero == null)
                    usuarioQueQuiero = usuario;

                sistema.AgregarUsuario(nombres[i], contrasenias[i]);
            }

            Usuario usuarioObtenido = sistema.DevolverUsuario(usuarioQueQuiero.Nombre);

            Assert.AreEqual(usuarioQueQuiero, usuarioObtenido);
        }

        [TestMethod]
        public void NoExisteUsuario()
        {
            Usuario usuarioQueQuiero = new Usuario(nombres[0], contrasenias[0]);

            for (int i = 1; i < nombres.Length; i++)
            {
                Usuario usuario = new Usuario(nombres[i], contrasenias[i]);

                sistema.AgregarUsuario(nombres[i], contrasenias[i]);
            }

            Usuario usuarioObtenido = sistema.DevolverUsuario(usuarioQueQuiero.Nombre);

            Assert.AreNotEqual(usuarioQueQuiero, usuarioObtenido);
        }

    }
}
