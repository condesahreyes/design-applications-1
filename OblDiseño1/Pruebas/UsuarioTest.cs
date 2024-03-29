﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using OblDiseño1.Entidades;
using OblDiseño1;
using System;

namespace Pruebas
{

    [TestClass]
    public class UsuarioTest
    {
        private static string notaCredencial;
        private static string nombreSitioCredencial;
        private static string nombresitioCredencialQueNoEsta;
        private static string nombreLargo;
        private static string contraseniaCorta;
        private static string contraseniaLarga;
        private static string contraseniaNoPresenteEnListaCredenciales;
        private static string numeroDeTarjetaNoPresenteEnListaTarjetas;

        private static string[] contrasenias = {"contrasenia123",
            "1234Contrasenia", "laContraseña"};

        private static string[] nombres = { "Hernán", "Santiago", "Rodrigo" };

        private static string[] nombresCategorias = {"Personal",
            "Trabajo", "Entretenimiento", "Estudios"};

        private static string[] nombresTarjetas = {"Visa",
            "Itau", "BBVA", "HSBC"};

        private static string[] tiposTarjetas = {"Visa gold",
            "Itau volar", "BBVA credito", "HSBC debito"};

        private static string[] numTarjetas = { "1234567891234567",
            "7894561234567894", "9876543219876543", "5462134567896543"};

        private static int[] codigosTarjetas = { 123, 321, 456, 789 };

        private List<Tarjeta> tarjetas;
        private List<Credencial> credenciales;
        private List<Categoria> categorias;

        private Usuario usuario;
        private Tarjeta tarjeta;
        private Categoria categoria;
        private Credencial dupla;
        private Contraseña contraseña;


        [TestInitialize]
        public void Setup()
        {
            notaCredencial = "";
            nombreSitioCredencial = "Instagram";
            nombresitioCredencialQueNoEsta = "Twitter";
            contraseniaCorta = "1234";
            contraseniaLarga = "contrasenia123456789012345";
            contraseniaNoPresenteEnListaCredenciales = "ContraseniaNoPrsente";
            numeroDeTarjetaNoPresenteEnListaTarjetas = "2000200020002000";
            nombreLargo = "Este es un nombre muy largo";

            credenciales = new List<Credencial>();
            tarjetas = new List<Tarjeta>();
            categorias = new List<Categoria>();

            usuario = new Usuario(nombres[0], contrasenias[0]);
            categoria = new Categoria(nombresCategorias[0]);
            tarjeta = new Tarjeta(nombresTarjetas[0], tiposTarjetas[0], numTarjetas[0],
                codigosTarjetas[0], new DateTime(2021, 12, 15), categoria, null);
            contraseña = new Contraseña(contrasenias[0]);
            dupla = new Credencial(nombres[1], contraseña,
                nombreSitioCredencial, notaCredencial, categoria);
        }

        [TestMethod]
        public void AltaUsuarioListasVacias()
        {
            Assert.IsNotNull(usuario);
        }

        [TestMethod]
        public void AltaUsuarioVerificarNombre()
        {
            Assert.AreEqual(nombres[0], usuario.Nombre);
        }

        [TestMethod]
        public void AltaUsuarioVerificarContrasenia()
        {
            Assert.AreEqual(contrasenias[0], usuario.Contrasenia);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionInvalidUsuarioData))]
        public void AltaUsuarioNombreVacio()
        {
            Usuario unUsuario = new Usuario("", contrasenias[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionInvalidUsuarioData))]
        public void AltaUsuarioNombreLargo()
        {
            Usuario unUsuario = new Usuario(nombreLargo, contrasenias[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionInvalidUsuarioData))]
        public void AltaUsuarioContraseniaCorta()
        {
            Usuario unUsuario = new Usuario(nombres[1], contraseniaCorta);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionInvalidUsuarioData))]
        public void AltaUsuarioContraseniaLarga()
        {
            Usuario unUsuario = new Usuario(nombres[1], contraseniaLarga);
        }

        [TestMethod]
        public void CambiarContrasenia()
        {
            usuario.ActualizarContrasenia(contrasenias[2]);

            Assert.AreEqual(contrasenias[2], usuario.Contrasenia);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionInvalidUsuarioData))]
        public void CambiarContraseniaCorta()
        {
            usuario.ActualizarContrasenia(contraseniaCorta);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionInvalidUsuarioData))]
        public void CambiarContraseniaLarga()
        {
            usuario.ActualizarContrasenia(contraseniaLarga);
        }

        [TestMethod]
        public void AgregarTarjetaPorPrimeraVez()
        {
            usuario.AgregarTarjeta(tarjeta);

            Assert.AreEqual(1, usuario.ObtenerTarjetas().Count);
        }

        [TestMethod]
        public void EliminarMiUnicaTarjeta()
        {
            usuario.AgregarTarjeta(tarjeta);
            usuario.EliminarTarjeta(tarjeta);

            Assert.AreEqual(0, usuario.ObtenerTarjetas().Count);
        }

        [TestMethod]
        public void AgregarDuplaPorPrimeraVez()
        {
            usuario.AgregarCredencial(dupla);

            Assert.AreEqual(1, usuario.ObtenerCredenciales().Count);
        }

        [TestMethod]
        public void EliminarMiUnicaDupla()
        {
            usuario.AgregarCredencial(dupla);
            usuario.EliminarCredencial(dupla);

            Assert.AreEqual(0, usuario.ObtenerCredenciales().Count);
        }

        [TestMethod]
        public void AgregarCategoriaPorPrimeraVez()
        {
            usuario.AgregarCategoria(categoria);

            Assert.AreEqual(1, usuario.ObtenerCategorias().Count);
        }

        [TestMethod]
        public void EliminarMiUnicaCategoria()
        {
            usuario.AgregarCategoria(categoria);
            usuario.EliminarCategoria(categoria);

            Assert.AreEqual(0, usuario.ObtenerCategorias().Count);
        }

        [TestMethod]
        public void ListarCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();

            for (int i = 0; i < nombresCategorias.Length; i++)
            {
                Categoria unaCategoria = new Categoria(nombresCategorias[i]);
                categorias.Add(unaCategoria);
                usuario.AgregarCategoria(unaCategoria);
            }

            CollectionAssert.AreEquivalent(categorias, usuario.ObtenerCategorias());
        }

        [TestMethod]
        public void ListarTarjetas()
        {
            List<Tarjeta> tarjetas = new List<Tarjeta>();

            for (int i = 0; i < nombresTarjetas.Length; i++)
            {
                Tarjeta unaTarjeta = new Tarjeta(nombresTarjetas[i], tiposTarjetas[i],
                numTarjetas[i], codigosTarjetas[i], new DateTime(2021, 12, 15), categoria, null); ;
                tarjetas.Add(unaTarjeta);
                usuario.AgregarTarjeta(unaTarjeta);
            }

            CollectionAssert.AreEquivalent(tarjetas, usuario.ObtenerTarjetas());
        }

        [TestMethod]
        public void ListarDuplas()
        {
            List<Credencial> duplas = new List<Credencial>();

            for (int i = 0; i < nombres.Length; i++)
            {
                Contraseña contra = new Contraseña(contrasenias[i]);
                Credencial unaDupla = new Credencial(nombres[i],
                    contra, "Instagram", "", categoria);
                duplas.Add(unaDupla);
                usuario.AgregarCredencial(unaDupla);
            }

            CollectionAssert.AreEquivalent(duplas, usuario.ObtenerCredenciales());
        }

        [TestMethod]
        public void ListarCategoriasTexto()
        {
            List<string> listarCategoriasPorMetodo = new List<string>();
            List<string> listaCategorias = new List<string>();

            for (int i = 0; i < nombresCategorias.Length; i++)
            {
                Categoria unaCategoria = new Categoria(nombresCategorias[i]);
                usuario.AgregarCategoria(unaCategoria);
                listaCategorias.Add("" + unaCategoria.Nombre);
            }

            listarCategoriasPorMetodo = usuario.ListarToStringDeMisCategorias();

            CollectionAssert.AreEquivalent(listaCategorias, listarCategoriasPorMetodo);
        }

        [TestMethod]
        public void ListarTarjetasTexto()
        {

            List<string> listarTarjetasPorMetodo = new List<string>();
            List<string> listaCategorias = new List<string>();

            for (int i = 0; i < nombresTarjetas.Length; i++)
            {
                Tarjeta unaTarjeta = new Tarjeta(nombresTarjetas[i], tiposTarjetas[i],
                numTarjetas[i], codigosTarjetas[i], new DateTime(2021, 12, 15), categoria, null);

                usuario.AgregarTarjeta(unaTarjeta);

                listaCategorias.Add("Nombre : " + unaTarjeta.Nombre + " Tipo: " + unaTarjeta.Tipo +
                " Numero: " + unaTarjeta.Numero + " Codigo de Seguridad: " +
                unaTarjeta.CodigoSeguridad + " Fecha de Vencimiento: " +
                unaTarjeta.FechaVencimiento + "Categoria: " + unaTarjeta.Categoria +
                "Nota: " + unaTarjeta.NotaOpcional);

            }

            listarTarjetasPorMetodo = usuario.ListarToStringDeMisTarjetas();

            CollectionAssert.AreEquivalent(listaCategorias, listarTarjetasPorMetodo);
        }

        [TestMethod]
        public void ListarDuplasTexto()
        {
            List<string> listarDuplasPorMetodo = new List<string>();
            List<string> listaDuplas = new List<string>();

            for (int i = 0; i < nombres.Length; i++)
            {
                Contraseña contra = new Contraseña(contrasenias[i]);
                Credencial unaDupla = new Credencial(nombres[i],
                    contra, "Instagram", "", categoria);

                usuario.AgregarCredencial(unaDupla);

                listaDuplas.Add("Nombre: " + unaDupla.NombreUsuario + " Contraseña: " + 
                    unaDupla.Contraseña.Contrasenia + " Nivel de seguridad: " + 
                    unaDupla.Contraseña.NivelSeguridadContrasenia + " Nombre sitio: " + 
                    unaDupla.NombreSitioApp + " Categoria: " + unaDupla.Categoria);
            }

            listarDuplasPorMetodo = usuario.ListarToStringDeMisDuplas();

            CollectionAssert.AreEquivalent(listaDuplas, listarDuplasPorMetodo);
        }

        [TestMethod]
        public void RevisarSiLaTarjetaEsMiaTest()
        {
            usuario.AgregarTarjeta(tarjeta);
            Assert.IsTrue(usuario.RevisarSiLaTarjetaEsMia(tarjeta.Numero));
        }

        [TestMethod]
        public void RevisarSiLaTarjetaNOEsMiaTest()
        {
            usuario.AgregarTarjeta(tarjeta);
            Assert.IsFalse(usuario.RevisarSiLaTarjetaEsMia(numeroDeTarjetaNoPresenteEnListaTarjetas));
        }

        [TestMethod]
        public void ObtenerTarjetaDeNumeroPresenteTest()
        {
            usuario.AgregarTarjeta(tarjeta);
            Tarjeta tarjetaEjemplo = tarjeta;
            Tarjeta tarjetaDeUsuario = usuario.ObtenerTarjetaDeNumero(tarjetaEjemplo.Numero);
            Assert.AreSame(tarjetaEjemplo, tarjetaDeUsuario);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionIntentoDeObtencionDeObjetoInexistente))]
        public void ObtenerTarjetaDeNumeroNOPresenteTest()
        {
            usuario.AgregarTarjeta(tarjeta);
            usuario.ObtenerTarjetaDeNumero(numeroDeTarjetaNoPresenteEnListaTarjetas);
        }

        [TestMethod]
        public void RevisarSiLaContraseniaEsMiaTest()
        {
            usuario.AgregarCredencial(dupla);
            Assert.IsTrue(usuario.RevisarSiLaContraseniaEsMia(contrasenias[0]));
        }

        [TestMethod]
        public void RevisarSiLaContraseniaNOEsMiaTest()
        {
            usuario.AgregarCredencial(dupla);
            Assert.IsFalse(usuario.RevisarSiLaTarjetaEsMia(contraseniaNoPresenteEnListaCredenciales));
        }

        [TestMethod]
        public void ObtenerDuplasConLaContraseniaTest()
        {
            usuario.AgregarCredencial(dupla);
            credenciales.Add(dupla);
            List<Credencial> listaDuplas = usuario.ObtenerDuplasConLaContrasenia(dupla.Contraseña.Contrasenia);
            CollectionAssert.AreEquivalent(credenciales, listaDuplas);
        }

        [TestMethod]
        public void ObtenerDuplasConContraseniaNOPresenteTest()
        {
            usuario.AgregarCredencial(dupla);
            List<Credencial> duplasConContraseniaNoPresente = new List<Credencial>();
            List<Credencial> duplasUsuario = usuario.ObtenerDuplasConLaContrasenia(contraseniaNoPresenteEnListaCredenciales);
            CollectionAssert.AreEquivalent(duplasConContraseniaNoPresente, duplasUsuario);
        }

        [TestMethod]
        public void RemoverDuplaExistente()
        {
            Contraseña contraseña1 = new Contraseña(contrasenias[0]);
            Contraseña contraseña2 = new Contraseña(contrasenias[0]);

            Credencial primerdupla = new Credencial("fing@edu.com", contraseña1,
               "Instagram", "", categoria);
            Credencial segundadupla = new Credencial("soydeort@ort.com.uy", contraseña2,
              "Facebook", "", categoria);
            usuario.AgregarCredencial(primerdupla);
            usuario.AgregarCredencial(segundadupla);
            usuario.RemoverDupla(primerdupla);

            List<Credencial> listaEsperada = new List<Credencial> { segundadupla };

            CollectionAssert.AreEquivalent(listaEsperada, usuario.ObtenerCredenciales());
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionInvalidUsuarioData))]
        public void AgregarDuplaExistente()
        {
            Contraseña contraseña1 = new Contraseña(contrasenias[0]);
            Credencial primerdupla = new Credencial("fing@edu.com", contraseña1,
               "Instagram", "", categoria);
            usuario.AgregarCredencial(primerdupla);
            usuario.AgregarCredencial(primerdupla);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionObjetosRepetidos))]
        public void AgregarTarjetaRepetida()
        {
            Tarjeta tarjetaConMismoNumero = new Tarjeta(nombresTarjetas[1], tiposTarjetas[1], numTarjetas[0],
                codigosTarjetas[1], new DateTime(2021, 12, 15), categoria, null);
            usuario.AgregarTarjeta(tarjeta);
            usuario.AgregarTarjeta(tarjetaConMismoNumero);
        }

        [TestMethod]
        public void VerificarQUeCombinacionNombreSitioEsata()
        {
            usuario.AgregarCategoria(categoria);
            usuario.AgregarCredencial(dupla);
            Assert.IsTrue(usuario.VerificarQueTengoCombinacionNombreSitio(nombres[1], nombreSitioCredencial));
        }

        [TestMethod]
        public void VerificarQUeCombinacionNombreSitioNOEsata()
        {
            usuario.AgregarCategoria(categoria);
            usuario.AgregarCredencial(dupla);
            Assert.IsFalse(usuario.VerificarQueTengoCombinacionNombreSitio(nombres[0], 
                nombresitioCredencialQueNoEsta));
        }

    }
}
