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

        private Sistema sistema;

        private string nombreCategoria;
        private string nombeUsuarioDupla;
        private string contraseniaDupla;
        private string notaDupla;
        private string stioDupla;
        private string nombreTarjeta;
        private string tipoTarjeta;
        private string numeroTarjeta;
        private int codigoSeguriadadTarjeta;
        private DateTime fechaVencimientoRTarjeta;
        private string notaTarjeta;
        private List<string> infoBreachada;
        private List<Object> entidadesVulneradas;
        private List<Object> duplasVulneradas;
        private List<Object> tarjetasVulneradas;

        private static string[] contraseniasUsuario = {"contrasenia123",
            "1234Contrasenia", "laContraseña"};

        private static string[] nombresUsuario = { "Hernán", "Santiago", "Rodrigo" };

        [TestInitialize]
        public void Setup()
        {
            nombreCategoria = "unaCategoria";
            Categoria categoria1 = new Categoria(nombreCategoria);

            nombeUsuarioDupla = "JuanEjemplez";
            contraseniaDupla = "ContraSuperSegura123!!!";
            notaDupla = "Una nota muy importante";
            stioDupla = "www.ejemplo.com.uy";
            Contraseña contraseña = new Contraseña(nombeUsuarioDupla);
            Dupla_UsuarioContrasenia dupla1 = new Dupla_UsuarioContrasenia(nombeUsuarioDupla, contraseña,
                                                stioDupla, notaDupla, categoria1); 
            
            nombreTarjeta = "La VIZA";
            tipoTarjeta = "VIZA";
            numeroTarjeta = "1234123412341234";
            codigoSeguriadadTarjeta = 123;
            fechaVencimientoRTarjeta = DateTime.Today;
            notaTarjeta = "Una Tarjeta muy importnte";
            Tarjeta tarjeta1 = new Tarjeta(nombreTarjeta, tipoTarjeta, numeroTarjeta, codigoSeguriadadTarjeta,
                                            fechaVencimientoRTarjeta, categoria1, notaTarjeta);

            infoBreachada = new List<string>{ numeroTarjeta, contraseniaDupla };
            entidadesVulneradas = new List<Object> { dupla1, tarjeta1};
            duplasVulneradas = new List<Object> { dupla1 };
            tarjetasVulneradas = new List<Object> { tarjeta1 };

            this.sistema = new Sistema();

            for (int i = 0; i < nombresUsuario.Length; i++)
            {
                Usuario usuario = new Usuario(nombresUsuario[i], contraseniasUsuario[i]);

                sistema.AgregarUsuario(nombresUsuario[i], contraseniasUsuario[i]);
            }
            sistema.ObtenerUsuarios()[0].AgregarDupla(dupla1);
            sistema.ObtenerUsuarios()[0].AgregarTarjeta(tarjeta1);
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
            List<Object>[] entidesVulneradas = sistema.ObtenerDataBreaches(ref usu, infoBreachada);

            CollectionAssert.AreEquivalent(duplasVulneradas, entidesVulneradas[1]);
        }

        [TestMethod]
        public void ObtenerTarjetasVulneradasTest()
        {
            Usuario usu = sistema.ObtenerUsuarios()[0];
            List<Object>[] entidesVulneradas = sistema.ObtenerDataBreaches(ref usu, infoBreachada);

            CollectionAssert.AreEquivalent(tarjetasVulneradas, entidesVulneradas[0]);
        }
    }
}
