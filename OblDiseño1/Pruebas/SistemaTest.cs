using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1;
using OblDiseño1.Entidades;

namespace Pruebas
{
    [TestClass]
    public class SistemaTest
    {

        private string nombreCategoria;
        private readonly string contraseniaDupla = "ContraSuperSegura123!!!";
        private readonly string numeroTarjeta = "1234123412341234";

        private static string[] contraseniasUsuario = {"contrasenia123",
            "1234Contrasenia", "laContraseña"};
        private static string[] nombresUsuario = { "Hernán", "Santiago", "Rodrigo" };

        private List<string> infoBreachada;

        private List<Credencial> duplasVulneradas;
        private List<Tarjeta> tarjetasVulneradas;

        private Categoria categoria1;

        private Sistema sistema;

        [TestInitialize]
        public void Setup()
        {
            nombreCategoria = "unaCategoria";
            categoria1 = new Categoria(nombreCategoria);

            Tarjeta tarjeta1 = CrearTarjeta();
            Credencial credencial1 = CrearCredencial();

            this.sistema = new Sistema();

            AgregarUsuario();

            sistema.ObtenerUsuarios()[0].AgregarCredencial(credencial1);
            sistema.ObtenerUsuarios()[0].AgregarTarjeta(tarjeta1);

            infoBreachada = new List<string>{ numeroTarjeta, contraseniaDupla };
            duplasVulneradas = new List<Credencial> { credencial1 };
            tarjetasVulneradas = new List<Tarjeta> { tarjeta1 };
        }

        private Credencial CrearCredencial()
        {
            string nombeUsuarioDupla = "JuanEjemplez";
            string notaDupla = "Una nota muy importante";
            string stioDupla = "www.ejemplo.com.uy";

            Contraseña contraseña = new Contraseña(contraseniaDupla);

            return new Credencial(nombeUsuarioDupla, contraseña,
                                                stioDupla, notaDupla, categoria1);
        }

        private Tarjeta CrearTarjeta()
        {
            string nombreTarjeta = "La VIZA";
            string tipoTarjeta = "VIZA";
            int codigoSeguriadadTarjeta = 123;
            DateTime fechaVencimientoRTarjeta = DateTime.Today;
            string notaTarjeta = "Una Tarjeta muy importnte";

            return new Tarjeta(nombreTarjeta, tipoTarjeta, numeroTarjeta, codigoSeguriadadTarjeta,
                                            fechaVencimientoRTarjeta, categoria1, notaTarjeta);
        }

        private void AgregarUsuario()
        {
            for (int i = 0; i < nombresUsuario.Length; i++)
            {
                Usuario usuario = new Usuario(nombresUsuario[i], contraseniasUsuario[i]);

                sistema.AgregarUsuario(nombresUsuario[i], contraseniasUsuario[i]);
            }
        }

        [TestMethod]
        public void AgregarUsuariosNuevos()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            for (int i = 0; i < nombresUsuario.Length; i++)
            {
                Usuario usuario = new Usuario(nombresUsuario[i], contraseniasUsuario[i]);
                listaUsuarios.Add(usuario);
            }

            List<Usuario> usuariosDesdeMetodo = sistema.ObtenerUsuarios();

            CollectionAssert.AreEqual(listaUsuarios, usuariosDesdeMetodo);
        }

        [TestMethod]
        public void DevolverUnUsuario()
        {
            Usuario usuarioQueQuiero = new Usuario(nombresUsuario[0], contraseniasUsuario[0]); ;
            Usuario usuarioObtenido = sistema.DevolverUsuario(usuarioQueQuiero.Nombre);

            Assert.AreEqual(usuarioQueQuiero, usuarioObtenido);
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectNotFoundException))]
        public void NoExisteUsuario()
        {
            Usuario usuarioQueQuiero = new Usuario("Un nombre", "unaContrasenia");
            Usuario usuariosObtenido = sistema.DevolverUsuario(usuarioQueQuiero.Nombre);
        }

        [TestMethod]
        public void IngresoSistena()
        {
            bool puedoIngresar = sistema.PuedoIngresarAlSistema(nombresUsuario[0], contraseniasUsuario[0]);

            Assert.AreEqual(true, puedoIngresar);
        }

        [TestMethod]
        public void NoIngresarAlSistenaErrorContraseniaYNombre()
        {
            bool puedoIngresar = sistema.PuedoIngresarAlSistema("Hernán", "contraseña");

            Assert.AreEqual(false, puedoIngresar);
        }

        [TestMethod]
        public void NoIngresarContraseniaIncorrecta()
        {
            bool puedoIngresar = sistema.PuedoIngresarAlSistema(nombresUsuario[0], "contraseñaMal");

            Assert.AreEqual(false, puedoIngresar);
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectNotFoundException))]
        public void NoIngresarNombreUsuarioIncorrecto()
        {
            bool puedoIngresar = sistema.PuedoIngresarAlSistema("Diego", contraseniasUsuario[0]);
        }

        [TestMethod]
        public void ObtenerDuplasVulneradasTest()
        {
            Usuario usu = sistema.ObtenerUsuarios()[0];
            List<Credencial> credencialesVulneradas = sistema.ObtenerDataBreachesCredenciales(ref usu, infoBreachada);

            CollectionAssert.AreEquivalent(duplasVulneradas, credencialesVulneradas);
        }

        [TestMethod]
        public void ObtenerTarjetasVulneradasTest()
        {
            Usuario usu = sistema.ObtenerUsuarios()[0];
            List<Tarjeta> entidesVulneradas = sistema.ObtenerDataBreachesTarjetas(ref usu, infoBreachada);

            CollectionAssert.AreEquivalent(tarjetasVulneradas, entidesVulneradas);
        }
    }
}
