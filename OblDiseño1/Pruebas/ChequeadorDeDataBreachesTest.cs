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
        private List<Credencial> credencialBracheada;
        private List<Credencial> credencialesBracheadas;
        private List<Tarjeta> tarjetaBreachada;
        private List<Tarjeta> tarjetasBreachadas;

        private ChequeadorDeDataBreaches chequeador;


        private static string nombreCategoria = "SuperCategoria";
        private readonly Categoria categoriaEjemplo = new Categoria(nombreCategoria);

        private readonly string[] nombresUsuarios = { "JuanJuanJuan", "JuanFacebook",
                "JuanTwitter", "JuanTwitter2", "JuanTwitter3" };
        private readonly string[] contrasenias = { "Contracontra123.", "Contracontra123..",
                "ContraTwitter23.", "ContraTwitter45.", "1234567812345678"};
        private readonly string[] sitios = { "aulas.ort.edu.uy", "facebook.com", "twitter.com",
                "instagram.com", "tiktok.com" };
        private readonly string[] notas = { "Esta es una credencial de ejemplo", "Contraseña de facebook",
                "Contraseña de twitter", "Contraseña de instagram", "Cuenta secundaria"};
        private readonly string[] nombreTarjetas = { "Tarjeta_1", "Tarjeta_2", "Tarjeta_3", "Tarjeta_4" };
        private readonly string[] tipoTarjetas = { "Visa", "OCA", "MasterCard", "McDonalds" };
        private readonly string[] numeroTarjetas = { "1234567812345678", "7676767676767676",
            "9999888877776666", "1000999988887777" };
        private readonly string[] notaTarjetas = { "Esta es una tarjeta para tests", "Nota",
            "Otra nota", "Mi tarjeta" };

        private readonly int[] codigoSeguridadTarjetas = { 123, 888, 369, 198 };

        DateTime[] fechaVencimientoTarjetas = { new DateTime(2030, 04, 20), new DateTime(2025, 07, 17),
                new DateTime(2030, 04, 20), new DateTime(2029, 05, 25)};

        [TestInitialize]
        public void Setup()
        {
            credencialesBracheadas = new List<Credencial>();
            tarjetasBreachadas = new List<Tarjeta>();

            string nombreUsuario = "JuanEjemplez";
            string contraseniaUsuario = "aaaaaa";

            usuario = new Usuario(nombreUsuario, contraseniaUsuario);

            usuario.AgregarCategoria(categoriaEjemplo);
            CargarTarjetasAlUsuario();
            CargarCredencialesAlUsuario();

            breachVacio = new List<string> { };
            infoBreacheada = new List<string> { "Contracontra123.", "aadsfsafas", "abcdefghijklm",
                "lolololo", "1234567812345678", "9999888877776666"};
            contraseniaDeDuplaBreachada = new List<string> { "ContraTwitter23." };
            numeroTagetaBreachada = new List<string> { "9999888877776666" };

            chequeador = new ChequeadorDeDataBreaches(usuario);
        }

        private void CargarTarjetasAlUsuario()
        {
            for (int i = 0; i < nombreTarjetas.Length; i++)
            {
                Tarjeta miTarjeta = new Tarjeta(nombreTarjetas[i], tipoTarjetas[i], numeroTarjetas[i],
                    codigoSeguridadTarjetas[i], fechaVencimientoTarjetas[i], categoriaEjemplo, notaTarjetas[i]);
                usuario.AgregarTarjeta(miTarjeta);

                if (i == 0 || i == 2)
                    tarjetasBreachadas.Add(miTarjeta);
                if (i == 2)
                    tarjetaBreachada = new List<Tarjeta> { miTarjeta };
            }
        }

        private void CargarCredencialesAlUsuario()
        {
            for (int i = 0; i < nombresUsuarios.Length; i++)
            {
                Contraseña contraseña = new Contraseña(contrasenias[i]);
                Credencial credencial = new Credencial(nombresUsuarios[i],
                    contraseña, sitios[i], notas[i], categoriaEjemplo);
                if (i == 2)
                    credencialBracheada = new List<Credencial> { credencial };
                else if (i % 2 == 0 || i == 0)
                    credencialesBracheadas.Add(credencial);

                usuario.AgregarCredencial(credencial);
            }
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
            List<Tarjeta> entidadesBreachadas = chequeador.ObtenerTarjetasVulneradas(breachVacio);

            Assert.AreEqual(elementosBreacheados, entidadesBreachadas.Count);
        }

        [TestMethod]
        public void VerificarVulneradosVacioCredencial()
        {
            int elementosBreacheados = 0;
            List<Credencial> entidadesBreachadas = 
                chequeador.ObtenerCredencialesVulneradas(breachVacio);

            Assert.AreEqual(elementosBreacheados, entidadesBreachadas.Count);
        }

        [TestMethod]
        public void VerificarVulneradoTarjeta()
        {
            List<Tarjeta> entidadesBreachadas = chequeador.ObtenerTarjetasVulneradas(numeroTagetaBreachada);

            CollectionAssert.AreEqual(entidadesBreachadas, tarjetaBreachada);
        }

        [TestMethod]
        public void VerificarVulneradoCredencial()
        {
            List<Credencial> entidadesBreachadas = 
                chequeador.ObtenerCredencialesVulneradas(contraseniaDeDuplaBreachada);

            CollectionAssert.AreEqual(entidadesBreachadas, credencialBracheada);
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
            List<Credencial> entidadesBreachadas = 
                chequeador.ObtenerCredencialesVulneradas(infoBreacheada);

            CollectionAssert.AreEqual(entidadesBreachadas, credencialesBracheadas);
        }
    }
}


