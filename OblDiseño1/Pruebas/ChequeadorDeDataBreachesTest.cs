using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using OblDiseño1;

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
        private List<Dupla_UsuarioContrasenia> duplaBreachada;
        private List<Dupla_UsuarioContrasenia> duplasBreachadas;
        private List<Tarjeta> tarjetaBreachada;
        private List<Tarjeta> tarjetasBreachadas;

        private ChequeadorDeDataBreaches chequeador;

        private const int numTarjeta = 0; 
        private const int numDupla = 1; 
        [TestInitialize]
        public void Setup()
        {
            duplasBreachadas = new List<Dupla_UsuarioContrasenia>();
            tarjetasBreachadas = new List<Tarjeta>();

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

            string[] nombresUsuarios = { "JuanJuanJuan", "JuanFacebook",
                "JuanTwitter", "JuanTwitter2", "JuanTwitter3" };
            string[] contrasenias = { "Contracontra123.", "Contracontra123..",
                "ContraTwitter23.", "ContraTwitter45.", "1234567812345678"};
            string[] sitios = { "aulas.ort.edu.uy", "facebook.com", "twitter.com",
                "instagram.com", "tiktok.com" };
            string[] notas = { "Esta es una credencial de ejemplo", "Contraseña de facebook",
                "Contraseña de twitter", "Contraseña de instagram", "Cuenta secundaria"};

            string nombreUsuario = "JuanEjemplez";
            string contraseniaUsuario = "aaaaaa";

            usuario = new Usuario(nombreUsuario, contraseniaUsuario);
            usuario.AgregarCategoria(categoriaEjemplo);

            for (int i = 0; i < nombresUsuarios.Length; i++)
            {
                Dupla_UsuarioContrasenia credencial = new Dupla_UsuarioContrasenia(nombresUsuarios[i],
                    contrasenias[i], sitios[i], notas[i], categoriaEjemplo);
                if (i == 2)
                    duplaBreachada = new List<Dupla_UsuarioContrasenia> { credencial };
                else if (i % 2 == 0 || i==0)
                    duplasBreachadas.Add(credencial);

                usuario.AgregarDupla(credencial);
            }

            usuario.AgregarTarjeta(tarjetaEjemplo_1);
            usuario.AgregarTarjeta(tarjetaEjemplo_2);
            usuario.AgregarTarjeta(tarjetaEjemplo_3);
            usuario.AgregarTarjeta(tarjetaEjemplo_4);

            tarjetasBreachadas.Add(tarjetaEjemplo_1);
            tarjetasBreachadas.Add(tarjetaEjemplo_3);

            breachVacio = new List<string>{ };
            infoBreacheada = new List<string> { "Contracontra123.", "aadsfsafas", "abcdefghijklm, " +
                "lolololo", "1234567812345678", "9999888877776666"};
            numeroTagetaBreachada = new List<string> { "9999888877776666" };
            contraseniaDeDuplaBreachada = new List<string> { "ContraTwitter23." };

            tarjetaBreachada = new List<Tarjeta> { tarjetaEjemplo_3 };

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
        public void VerificarVulneradosVacioTarjeta()
        {
            int elementosBreacheados = 0;
            List <Tarjeta> entidadesBreachadas = chequeador.ObtenerTarjetasVulneradas(breachVacio);

            Assert.AreEqual(elementosBreacheados, entidadesBreachadas.Count);
        }

        [TestMethod]
        public void VerificarVulneradosVacioCredencial()
        {
            int elementosBreacheados = 0;
            List<Dupla_UsuarioContrasenia> entidadesBreachadas = chequeador.ObtenerCredencialesVulneradas(breachVacio);

            Assert.AreEqual(elementosBreacheados, entidadesBreachadas.Count);
        }

        [TestMethod]
        public void VerificarVulneradoTarjeta()
        {
            List<Tarjeta> entidadesBreachadas = chequeador.ObtenerTarjetasVulneradas(numeroTagetaBreachada);

            CollectionAssert.AreEqual(entidadesBreachadas, tarjetaBreachada);
        }

        [TestMethod]
        public void VerificarVulneradoDupla()
        {
            List<Dupla_UsuarioContrasenia> entidadesBreachadas = chequeador.ObtenerCredencialesVulneradas(contraseniaDeDuplaBreachada);

            CollectionAssert.AreEqual(entidadesBreachadas, duplaBreachada);
        }

        [TestMethod]
        public void VerificarVulneradosTarjeta()
        {
            List<Tarjeta> entidadesBreachadas = chequeador.ObtenerTarjetasVulneradas(infoBreacheada);

            CollectionAssert.AreEqual(entidadesBreachadas, tarjetasBreachadas);
        }

        [TestMethod]
        public void VerificarVulneradosDupla()
        {
            List<Dupla_UsuarioContrasenia> entidadesBreachadas = chequeador.ObtenerCredencialesVulneradas(infoBreacheada);

            CollectionAssert.AreEqual(entidadesBreachadas, duplasBreachadas);
        }

    }
}


