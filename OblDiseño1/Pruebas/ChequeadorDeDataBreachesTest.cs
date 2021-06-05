using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using OblDiseño1;
using OblDiseño1.Entidades;

namespace Pruebas
{
    [TestClass]
    public class ChequeadorDeDataBreachesTest
    {

        private Usuario usuario;

        private List<string> infoBreacheada;
        private List<string> contraseniaDeDuplaBreachada;
        private List<string> numeroTagetaBreachada;
        private List<string> breachVacio;
        private List<Object> duplaBreachada;
        private List<Object> tarjetaBreachada;
        private List<Object> entidadesVulneradas;

        private ChequeadorDeDataBreaches chequeador;

        private const int numTarjeta = 0; 
        private const int numDupla = 1;
        [TestInitialize]
        public void Setup()
        {
            string nombreCategoria = "SuperCategoria";
            Categoria categoriaEjemplo = new Categoria(nombreCategoria);

            string nombreTargeta_1 = "Tarjeta_1";
            string nombreTargeta_2 = "Tarjeta_2";
            string nombreTargeta_3 = "Tarjeta_3";
            string nombreTargeta_4 = "Tarjeta_4";
            string tipoTarjeta_1 = "Visa";
            string tipoTarjeta_2 = "OCA";
            string tipoTarjeta_3 = "MasterCard";
            string tipoTarjeta_4 = "McDonalds";

            string numeroTarjeta_1 = "1234567812345678";
            string numeroTarjeta_2 = "7676767676767676";
            string numeroTarjeta_3 = "9999888877776666";
            string numeroTarjeta_4 = "1000999988887777";

            int codigoSeguridadTargeta_1 = 123;
            int codigoSeguridadTargeta_2 = 888;
            int codigoSeguridadTargeta_3 = 369;
            int codigoSeguridadTargeta_4 = 198;

            DateTime fechaVencimientoTargeta_1 = new DateTime(2030, 04, 20);
            DateTime fechaVencimientoTargeta_2 = new DateTime(2025, 07, 17);
            DateTime fechaVencimientoTargeta_3 = new DateTime(2030, 04, 20);
            DateTime fechaVencimientoTargeta_4 = new DateTime(2029, 05, 25);

            String notaTarjeta_1 = "Esta es una tarjeta para tests";
            String notaTarjeta_2 = "Esta tambien es una tarjeta para tests";
            String notaTarjeta_3 = "Esta tambien es otra tafjeta para rests";
            String notaTarjeta_4 = "Esta es una tarjeta muy seria";

            Tarjeta tarjetaEjemplo_1 = new Tarjeta(nombreTargeta_1, tipoTarjeta_1,
                numeroTarjeta_1, codigoSeguridadTargeta_1, fechaVencimientoTargeta_1,
                categoriaEjemplo, notaTarjeta_1);

            Tarjeta tarjetaEjemplo_2 = new Tarjeta(nombreTargeta_2, tipoTarjeta_2,
                numeroTarjeta_2, codigoSeguridadTargeta_2, fechaVencimientoTargeta_2,
                categoriaEjemplo, notaTarjeta_2);

            Tarjeta tarjetaEjemplo_3 = new Tarjeta(nombreTargeta_3, tipoTarjeta_3,
                numeroTarjeta_3, codigoSeguridadTargeta_3, fechaVencimientoTargeta_3,
                categoriaEjemplo, notaTarjeta_3);

            Tarjeta tarjetaEjemplo_4 = new Tarjeta(nombreTargeta_4, tipoTarjeta_4,
                numeroTarjeta_4, codigoSeguridadTargeta_4, fechaVencimientoTargeta_4,
                categoriaEjemplo, notaTarjeta_4);

            string userNameDupla_1 = "JuanJuanJuan";
            string userNameDupla_2 = "JuanFacebook";
            string userNameDupla_3 = "JuanTwitter";
            string userNameDupla_4 = "JuanTwitter2";
            string userNameDupla_5 = "JuanTwitter3";
            string passwordDupla_1 = "Contracontra123.";
            string passwordDupla_2 = "Contracontra123.";
            string passwordDupla_3 = "ContraTwitter23.";
            string passwordDupla_4 = "1234567812345678";
            string passwordDupla_5 = "ContraTwitter45.";
            string sitioDupla_1 = "ejemplo.ej.edu.uy";
            string sitioDupla_2 = "facebook.com";
            string sitioDupla_3 = "twitter.com";
            string sitioDupla_4 = "twitter.com";
            string sitioDupla_5 = "twitter.com";
            string notaDupla_1 = "Esta es una dupla de ejemplo";
            string notaDupla_2 = "Tengo que esperar 90 dias para que se borre";
            string notaDupla_3 = "Hacer una cuenta aca fue el peor error de mi vida";
            string notaDupla_4 = "Hice esta porque me suspendieron la otra";
            string notaDupla_5 = "Hice esta porque me suspendieron la de respuesto";

            Contraseña contraseña1 = new Contraseña(passwordDupla_1);
            Contraseña contraseña2 = new Contraseña(passwordDupla_2);
            Contraseña contraseña3 = new Contraseña(passwordDupla_3);
            Contraseña contraseña4 = new Contraseña(passwordDupla_4);
            Contraseña contraseña5 = new Contraseña(passwordDupla_5);

            Dupla_UsuarioContrasenia duplaEjemplo_1 = new Dupla_UsuarioContrasenia(userNameDupla_1,
                contraseña1, sitioDupla_1, notaDupla_1, categoriaEjemplo);

            Dupla_UsuarioContrasenia duplaEjemplo_2 = new Dupla_UsuarioContrasenia(userNameDupla_2,
                contraseña2, sitioDupla_2, notaDupla_2, categoriaEjemplo);

            Dupla_UsuarioContrasenia duplaEjemplo_3 = new Dupla_UsuarioContrasenia(userNameDupla_3,
                contraseña3, sitioDupla_3, notaDupla_3, categoriaEjemplo);

            Dupla_UsuarioContrasenia duplaEjemplo_4 = new Dupla_UsuarioContrasenia(userNameDupla_4,
                contraseña4, sitioDupla_4, notaDupla_4, categoriaEjemplo);

            Dupla_UsuarioContrasenia duplaEjemplo_5 = new Dupla_UsuarioContrasenia(userNameDupla_5,
                contraseña5, sitioDupla_5, notaDupla_5, categoriaEjemplo);

            string nombreUsuario = "JuanEjemplez";
            string contraseniaUsuario = "aaaaaa";
            usuario = new Usuario(nombreUsuario, contraseniaUsuario);
            usuario.AgregarCategoria(categoriaEjemplo);
            usuario.AgregarDupla(duplaEjemplo_1);
            usuario.AgregarDupla(duplaEjemplo_2);
            usuario.AgregarDupla(duplaEjemplo_3);
            usuario.AgregarDupla(duplaEjemplo_4);
            usuario.AgregarDupla(duplaEjemplo_5);
            usuario.AgregarTarjeta(tarjetaEjemplo_1);
            usuario.AgregarTarjeta(tarjetaEjemplo_2);
            usuario.AgregarTarjeta(tarjetaEjemplo_3);
            usuario.AgregarTarjeta(tarjetaEjemplo_4);


            breachVacio = new List<string>{ };
            infoBreacheada = new List<string> { "Contracontra123.", "aadsfsafas", "abcdefghijklm, " +
                "lolololo", "1234567812345678", "9999888877776666" };
            numeroTagetaBreachada = new List<string> { "9999888877776666" };
            contraseniaDeDuplaBreachada = new List<string> { "ContraTwitter23." };
            duplaBreachada = new List<Object> { duplaEjemplo_3 };
            tarjetaBreachada = new List<Object> { tarjetaEjemplo_3 };
            entidadesVulneradas = new List<Object> { duplaEjemplo_1, duplaEjemplo_2, duplaEjemplo_4, 
                tarjetaEjemplo_1, tarjetaEjemplo_3 };

            chequeador = new ChequeadorDeDataBreaches(usuario);
        }

        [TestMethod]
        public void AltaChequearDataBreaches()
        {
            Assert.IsNotNull(chequeador);
        }

        [TestMethod]
        public void VerificarUsuario()
        {
            Assert.AreSame(usuario, chequeador.usuario);
        }
        
        [TestMethod]
        public void VerificarVulneradosVacio()
        {
            int elementosBreacheados = 0;
            List <Object> entidadesBreachadas = chequeador.ObtenerEntidadesVulneradas(breachVacio)[numTarjeta];
            entidadesBreachadas.AddRange(chequeador.ObtenerEntidadesVulneradas(breachVacio)[numDupla]);

            Assert.AreEqual(elementosBreacheados, entidadesBreachadas.Count);
        }

        [TestMethod]
        public void VerificarVulneradosTarjeta()
        {
            List<Object> entidadesBreachadas = chequeador.ObtenerEntidadesVulneradas(numeroTagetaBreachada)[numTarjeta];

            CollectionAssert.AreEqual(entidadesBreachadas, tarjetaBreachada);
        }

        [TestMethod]
        public void VerificarVulneradosDupla()
        {
            List<Object> entidadesBreachadas = chequeador.ObtenerEntidadesVulneradas(contraseniaDeDuplaBreachada)[numDupla];

            CollectionAssert.AreEqual(entidadesBreachadas, duplaBreachada);
        }

        [TestMethod]
        public void VerificarVulnerados()
        {
            List<Object> entidadesBreachadas = chequeador.ObtenerEntidadesVulneradas(infoBreacheada)[numDupla];
            entidadesBreachadas.AddRange(chequeador.ObtenerEntidadesVulneradas(infoBreacheada)[numTarjeta]);

            CollectionAssert.AreEquivalent(entidadesBreachadas, entidadesVulneradas);
        }
    }
}


