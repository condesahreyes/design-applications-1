using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using OblDiseño1;

namespace Pruebas
{
    [TestClass]
    public class ChequeadorDeDataBreachesTest
    {
        Usuario usuario;

        List<string> infoBreacheada;
        List<string> numeroDeTagetasBreachadas;
        string datoBreacheado_1;
        string datoBreacheado_2;
        string datoBreacheado_3;
        string datoBreacheado_4;
        List<Dupla_UsuarioContrasenia> duplasBreachadas;
        List<Tarjeta> targetasBreachadas;
        List<Object> entidadesComprometidas;
        ChequeadorDeDataBreaches chequeador;

        List<Dupla_UsuarioContrasenia> duplasFiltradas;
        List<Tarjeta> targetasFiltradas;

        public bool EsNuemroDeTargetaBalido(string posibleNumeroDeTargeta)
        {
            bool esValido = true;
            if (!(posibleNumeroDeTargeta.Length == 16))
            {
                esValido = false;
            }
            else
            {
                for (int i = 0; i < posibleNumeroDeTargeta.Length && esValido; i++)
                {
                    int codigoASCII = (int)posibleNumeroDeTargeta[i];
                    if (codigoASCII < 48 || codigoASCII > 57)
                    {
                        esValido = false;
                    }
                }
            }
            return esValido;
        }

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
            long numeroTarjeta_1 = 1234567812345678;
            long numeroTarjeta_2 = 7676767676767676;
            long numeroTarjeta_3 = 9999888877776666;
            long numeroTarjeta_4 = 0000999988887777;
            int codigoSeguridadTargeta_1 = 123;
            int codigoSeguridadTargeta_2 = 888;
            int codigoSeguridadTargeta_3 = 369;
            int codigoSeguridadTargeta_4 = 098;
            DateTime fechaVencimientoTargeta_1 = new DateTime(2030, 04, 20);
            DateTime fechaVencimientoTargeta_2 = new DateTime(2025, 07, 17);
            DateTime fechaVencimientoTargeta_3 = new DateTime(2030, 04, 20);
            DateTime fechaVencimientoTargeta_4 = new DateTime(2029, 05, 25);
            String notaTarjeta_1 = "Esta es una tarjeta para tests";
            String notaTarjeta_2 = "Esta tambien es una tarjeta para tests";
            String notaTarjeta_3 = "Esta tambien es otra tafjeta para rests";
            String notaTarjeta_4 = "Esta es una tarjeta muy seria";
            Tarjeta tarjetaEjemplo_1 = new Tarjeta(nombreTargeta_1, tipoTarjeta_1, numeroTarjeta_1, codigoSeguridadTargeta_1,
                                                 fechaVencimientoTargeta_1, categoriaEjemplo, notaTarjeta_1);
            Tarjeta tarjetaEjemplo_2 = new Tarjeta(nombreTargeta_2, tipoTarjeta_2, numeroTarjeta_2, codigoSeguridadTargeta_2,
                                                 fechaVencimientoTargeta_2, categoriaEjemplo, notaTarjeta_2);
            Tarjeta tarjetaEjemplo_3 = new Tarjeta(nombreTargeta_3, tipoTarjeta_3, numeroTarjeta_3, codigoSeguridadTargeta_3,
                                                 fechaVencimientoTargeta_3, categoriaEjemplo, notaTarjeta_3);
            Tarjeta tarjetaEjemplo_4 = new Tarjeta(nombreTargeta_4, tipoTarjeta_4, numeroTarjeta_4, codigoSeguridadTargeta_4,
                                                 fechaVencimientoTargeta_4, categoriaEjemplo, notaTarjeta_4);

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
            Dupla_UsuarioContrasenia duplaEjemplo_1 = new Dupla_UsuarioContrasenia(userNameDupla_1, passwordDupla_1, sitioDupla_1,
                                                                                 notaDupla_1, categoriaEjemplo);
            Dupla_UsuarioContrasenia duplaEjemplo_2 = new Dupla_UsuarioContrasenia(userNameDupla_2, passwordDupla_2, sitioDupla_2,
                                                                                 notaDupla_2, categoriaEjemplo);
            Dupla_UsuarioContrasenia duplaEjemplo_3 = new Dupla_UsuarioContrasenia(userNameDupla_3, passwordDupla_3, sitioDupla_3,
                                                                                 notaDupla_3, categoriaEjemplo);
            Dupla_UsuarioContrasenia duplaEjemplo_4 = new Dupla_UsuarioContrasenia(userNameDupla_4, passwordDupla_4, sitioDupla_4,
                                                                                 notaDupla_4, categoriaEjemplo);
            Dupla_UsuarioContrasenia duplaEjemplo_5 = new Dupla_UsuarioContrasenia(userNameDupla_5, passwordDupla_5, sitioDupla_5,
                                                                                 notaDupla_5, categoriaEjemplo);

            string nombreUsuario = "JuanEjemplez";
            string contraseniaUsuario = "aaaaaa";
            usuario = new Usuario(nombreUsuario, contraseniaUsuario);
            usuario.agregarCategoria(categoriaEjemplo);
            usuario.agregarDupla(duplaEjemplo_1);
            usuario.agregarDupla(duplaEjemplo_2);
            usuario.agregarDupla(duplaEjemplo_3);
            usuario.agregarDupla(duplaEjemplo_4);
            usuario.agregarDupla(duplaEjemplo_5);
            usuario.agregarTarjeta(tarjetaEjemplo_1);
            usuario.agregarTarjeta(tarjetaEjemplo_2);
            usuario.agregarTarjeta(tarjetaEjemplo_3);


            infoBreacheada = new List<string> { "Contracontra123.", "aadsfsafas", "trololololololo, lolololo", "1234567812345678" };
            numeroDeTagetasBreachadas = new List<string> { "1234567812345678" };
            datoBreacheado_1 = "Contracontra098,";
            datoBreacheado_2 = "ihlkuluiokik";
            datoBreacheado_3 = "lalalalalalaaaaaaaaaaaaaaaaaaa";
            datoBreacheado_4 = "0000999988887777";
            entidadesComprometidas = new List<Object> { duplaEjemplo_1, tarjetaEjemplo_1, numeroTarjeta_4 };

            chequeador = new ChequeadorDeDataBreaches(usuario);
        }

        [TestMethod]
        public void Alta_ChequeadorDeDataBreaches()
        {
            Assert.IsNotNull(chequeador);
        }

        [TestMethod]
        public void VerificarUsuario()
        {
            Assert.AreSame(usuario, chequeador.Usuario);
        }

        [TestMethod]
        public void VerificarListaDeContraseniasBreachadas()
        {
            chequeador.agregarBreach(infoBreacheada);
            CollectionAssert.AreEquivalent(infoBreacheada, chequeador.InfoBreachada);
        }

        [TestMethod]
        public void VerificarListaDeTarjetasBreachadas()
        {
            chequeador.agregarBreach(infoBreacheada);
            CollectionAssert.AreEquivalent(numeroDeTagetasBreachadas, chequeador.TarjetasBreachadas);
        }

        [TestMethod]
        public void VerificarDatoBrachadoAgregadoIndividualmente()
        {
            chequeador.agregarBreach(infoBreacheada);
            chequeador.agregarDatoBreachado(datoBreacheado_1);
            CollectionAssert.Contains(datoBreacheado_1, chequeador.InfoBreachada);
        } 
        
        [TestMethod]
        public void VerificarBreach()
        {
            chequeador.agregarBreach(infoBreacheada);
            chequeador.agregarDatoBreachado(datoBreacheado_1);
            chequeador.agregarDatoBreachado(datoBreacheado_2);
            chequeador.agregarDatoBreachado(datoBreacheado_3);
            chequeador.agregarDatoBreachado(datoBreacheado_4);
            CollectionAssert.AreEquivalent(entidadesComprometidas, chequeador.getEntidadesComprometidas());
        }
    }
}


