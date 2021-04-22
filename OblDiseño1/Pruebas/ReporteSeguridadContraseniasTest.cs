using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using OblDiseño1;

namespace Pruebas
{
    [TestClass]
    public class ReporteSeguridadContraseniasTest
    {
        private readonly int nivelSeguridadROJO = 1;
        private readonly int nivelSeguridadNARANJA = 2;
        private readonly int nivelSeguridadAMARRILLO = 3;
        private readonly int nivelSeguridadVERDE_CLARO = 4;
        private readonly int nivelSeguridadVERDE_OSCURO = 5;
        private readonly int cantidadContraseniasROJAS = 2;
        private readonly int cantidadContraseniasNARANJAS = 4;
        private readonly int cantidadContraseniasAMARILLAS = 0;
        private readonly int cantidadContraseniasVERDE_CLARAS = 2;
        private readonly int cantidadContraseniasVERDE_OSCURAS = 5;
        private Usuario usuario;
        private List<Dupla_UsuarioContrasenia> contraseniasROJAS;
        private List<Dupla_UsuarioContrasenia> contraseniasNARANJAS;
        private List<Dupla_UsuarioContrasenia> contraseniasAMARILLAS;
        private List<Dupla_UsuarioContrasenia> contraseniasVERDE_CLARAS;
        private List<Dupla_UsuarioContrasenia> contraseniasVERDE_OSCURAS;

        private Categoria categoria_SuperCategoria;
        private Categoria categoria_UltraCategoria;
        private readonly int cantidadContraseniasROJAS_enSuperCategoria = 1;
        private readonly int cantidadContraseniasNARANJAS_enSuperCategoria = 1;
        private readonly int cantidadContraseniasAMARILLAS_enSuperCategoria = 0;
        private readonly int cantidadContraseniasVERDE_CLARAS_enSuperCategoria = 0;
        private readonly int cantidadContraseniasVERDE_OSCURAS_enSuperCategoria = 5;
        private readonly int cantidadContraseniasROJAS_enUltraCategoria = 1;
        private readonly int cantidadContraseniasNARANJAS_enUltraCategoria = 3;
        private readonly int cantidadContraseniasAMARILLAS_enUltraCategoria = 0;
        private readonly int cantidadContraseniasVERDE_CLARAS_enUltraCategoria = 2;
        private readonly int cantidadContraseniasVERDE_OSCURAS_enUltraCategoria = 0;



        [TestInitialize]
        public void SetUp()
        {
            string nombreCategoria_1 = "SuperCategoria";
            categoria_SuperCategoria = new Categoria(nombreCategoria_1);

            string nombreCategoria_2 = "UltraCategoria";
            categoria_UltraCategoria = new Categoria(nombreCategoria_2);



            string userNameDupla_1 = "JuanJuanJuan";
            string userNameDupla_2 = "JuanFacebook";
            string userNameDupla_3 = "JuanTwitter";
            string userNameDupla_4 = "JuanTwitter2";
            string userNameDupla_5 = "JuanTwitter3";
            string userNameDupla_6 = "JuanTwitter4";
            string userNameDupla_7 = "JuanTwitter5";
            string userNameDupla_8 = "JuanTwitter6";
            string userNameDupla_9 = "JuanTwitter7";
            string userNameDupla_10 = "JuanTwitter8";
            string userNameDupla_11 = "JuanTwitter9";
            string userNameDupla_12 = "JuanTwitter10";
            string userNameDupla_13 = "JuanTwitter11";
            string passwordDupla_1 = "Contracontra123.";            //VO --categoriaEjemplo_1
            string passwordDupla_2 = "Contracontra123.";            //VO --categoriaEjemplo_1
            string passwordDupla_3 = "C*ntra7witterrrrrrrrrrr";     //VO --categoriaEjemplo_1
            string passwordDupla_4 = "1234567a1";                   //N  --categoriaEjemplo_2
            string passwordDupla_5 = "ContraTwitter45.";            //VO --categoriaEjemplo_1
            string passwordDupla_6 = "aaaaa";                       //R  --categoriaEjemplo_1
            string passwordDupla_7 = "AAAAAA**-";                   //N  --categoriaEjemplo_1
            string passwordDupla_8 = "12-*SAAaa.";                  //N  --categoriaEjemplo_2
            string passwordDupla_9 = "aaaaaaaaaa";                  //N  --categoriaEjemplo_2
            string passwordDupla_10 = "oooooooooooooo7*Ooooooo";    //VO --categoriaEjemplo_1
            string passwordDupla_11 = "aaaaaaaaaaaaaaAAAAAAAAA";    //VC --categoriaEjemplo_2
            string passwordDupla_12 = "a*1A2";                      //R  --categoriaEjemplo_2
            string passwordDupla_13 = "ALALALALALALALALALALaL";     //VC --categoriaEjemplo_2
            string sitioDupla_1 = "ejemplo.ej.edu.uy";
            string sitioDupla_2 = "facebook.com";
            string sitioDupla_3 = "twitter.com";
            string sitioDupla_4 = "twitter.com";
            string sitioDupla_5 = "twitter.com";
            string sitioDupla_6 = "twitter.com";
            string sitioDupla_7 = "twitter.com";
            string sitioDupla_8 = "twitter.com";
            string sitioDupla_9 = "twitter.com";
            string sitioDupla_10 = "twitter.com";
            string sitioDupla_11 = "twitter.com";
            string sitioDupla_12 = "twitter.com";
            string sitioDupla_13 = "twitter.com";
            string notaDupla_1 = "Esta es una dupla de ejemplo";
            string notaDupla_2 = "Tengo que esperar 90 dias para que se borre";
            string notaDupla_3 = "Hacer una cuenta aca fue el peor error de mi vida";
            string notaDupla_4 = "Hice esta porque me suspendieron la otra";
            string notaDupla_5 = "Hice esta porque me suspendieron la de respuesto";
            string notaDupla_6 = "Hice esta porque me suspendieron el respuesto de la de repuesto";
            string notaDupla_7 = "Hice esta porque me suspendieron el repuesto del repuesto de la de repuesto";
            string notaDupla_8 = "Hice esta porque me suspendieron el repuesto del repuesto del repuesto de la de repuesto";
            string notaDupla_9 = "Perdi la cuenta de cuantos repuesto llevo";
            string notaDupla_10 = "Y me tuve que hacer otra";
            string notaDupla_11 = "Ojala me dieran un punto en Disenio de Aplicacion por cada cuenta que me suspendieron";
            string notaDupla_12 = "Otra mas";
            string notaDupla_13 = "La ultima, lo juro";

            Dupla_UsuarioContrasenia duplaEjemplo_1 = new Dupla_UsuarioContrasenia(userNameDupla_1,
                passwordDupla_1, sitioDupla_1, notaDupla_1, categoria_SuperCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_2 = new Dupla_UsuarioContrasenia(userNameDupla_2,
                passwordDupla_2, sitioDupla_2, notaDupla_2, categoria_SuperCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_3 = new Dupla_UsuarioContrasenia(userNameDupla_3,
                passwordDupla_3, sitioDupla_3, notaDupla_3, categoria_SuperCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_4 = new Dupla_UsuarioContrasenia(userNameDupla_4,
                passwordDupla_4, sitioDupla_4, notaDupla_4, categoria_UltraCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_5 = new Dupla_UsuarioContrasenia(userNameDupla_5,
                passwordDupla_5, sitioDupla_5, notaDupla_5, categoria_SuperCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_6 = new Dupla_UsuarioContrasenia(userNameDupla_6,
                passwordDupla_6, sitioDupla_6, notaDupla_6, categoria_SuperCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_7 = new Dupla_UsuarioContrasenia(userNameDupla_7,
                passwordDupla_7, sitioDupla_7, notaDupla_7, categoria_SuperCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_8 = new Dupla_UsuarioContrasenia(userNameDupla_8,
                passwordDupla_8, sitioDupla_8, notaDupla_8, categoria_UltraCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_9 = new Dupla_UsuarioContrasenia(userNameDupla_9,
                passwordDupla_9, sitioDupla_9, notaDupla_9, categoria_UltraCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_10 = new Dupla_UsuarioContrasenia(userNameDupla_10,
                passwordDupla_10, sitioDupla_10, notaDupla_10, categoria_SuperCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_11 = new Dupla_UsuarioContrasenia(userNameDupla_11,
                passwordDupla_11, sitioDupla_11, notaDupla_11, categoria_UltraCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_12 = new Dupla_UsuarioContrasenia(userNameDupla_12,
                passwordDupla_12, sitioDupla_12, notaDupla_12, categoria_UltraCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_13 = new Dupla_UsuarioContrasenia(userNameDupla_13,
                passwordDupla_13, sitioDupla_13, notaDupla_13, categoria_UltraCategoria);

            string nombreUsuario = "JuanEjemplez";
            string contraseniaUsuario = "aaaaaa";
            usuario = new Usuario(nombreUsuario, contraseniaUsuario);
            usuario.AgregarCategoria(categoria_SuperCategoria);
            usuario.AgregarCategoria(categoria_UltraCategoria);
            usuario.AgregarDupla(duplaEjemplo_1);
            usuario.AgregarDupla(duplaEjemplo_2);
            usuario.AgregarDupla(duplaEjemplo_3);
            usuario.AgregarDupla(duplaEjemplo_4);
            usuario.AgregarDupla(duplaEjemplo_5);
            usuario.AgregarDupla(duplaEjemplo_6);
            usuario.AgregarDupla(duplaEjemplo_7);
            usuario.AgregarDupla(duplaEjemplo_8);
            usuario.AgregarDupla(duplaEjemplo_9);
            usuario.AgregarDupla(duplaEjemplo_10);
            usuario.AgregarDupla(duplaEjemplo_11);
            usuario.AgregarDupla(duplaEjemplo_12);
            usuario.AgregarDupla(duplaEjemplo_13);

            contraseniasROJAS = new List<Dupla_UsuarioContrasenia>{ duplaEjemplo_6, duplaEjemplo_12};
            contraseniasNARANJAS = new List<Dupla_UsuarioContrasenia> { duplaEjemplo_4, duplaEjemplo_7, 
                                                                        duplaEjemplo_8, duplaEjemplo_9};
            contraseniasAMARILLAS = new List<Dupla_UsuarioContrasenia> { };
            contraseniasVERDE_CLARAS = new List<Dupla_UsuarioContrasenia> { duplaEjemplo_11, duplaEjemplo_13};
            contraseniasVERDE_OSCURAS = new List<Dupla_UsuarioContrasenia> { duplaEjemplo_1, duplaEjemplo_2,
                                                                             duplaEjemplo_3, duplaEjemplo_5, 
                                                                             duplaEjemplo_10};

        }

        [TestMethod]
        public void CantidadContraseniasROJAS()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(cantidadContraseniasROJAS, reporte.numeroContrasROJO);
        }

        [TestMethod]
        public void CantidadContraseniasNARANJAS()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(cantidadContraseniasNARANJAS, reporte.numeroContrasNARANJA);
        }

        [TestMethod]
        public void CantidadContraseniasAMARILLAS()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(cantidadContraseniasAMARILLAS, reporte.numeroContrasAMARILLO);
        }
        
        [TestMethod]
        public void CantidadContraseniasVERDE_CLARAS()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(cantidadContraseniasVERDE_CLARAS, reporte.numeroContrasVERDE_CLARO);
        }

        [TestMethod]
        public void CantidadContraseniasVERDE_OSCURAS()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(cantidadContraseniasVERDE_OSCURAS, reporte.numeroContrasVERDE_OSCURO);
        }

        [TestMethod]
        public void ListaContrasenias_ROJAS()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(contraseniasROJAS, reporte.ListaROJO);
        }

        [TestMethod]
        public void ListaContrasenias_NARANJAS()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(contraseniasNARANJAS, reporte.ListaNARANJA);
        }

        [TestMethod]
        public void ListaContrasenias_AMARILLAS()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(contraseniasAMARILLAS, reporte.ListaAMARILLO);
        }

        [TestMethod]
        public void ListaContrasenias_VERDE_CLARAS()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(contraseniasVERDE_CLARAS, reporte.ListaVERDE_CLARO);
        }

        [TestMethod]
        public void ListaContrasenias_VERDE_OSCURAS()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(contraseniasVERDE_OSCURAS, reporte.ListaVERDE_OSCURO);
        }

        [TestMethod]
        public void CantiadadContraseniasROJO_Categoria_SuperCategoria()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(cantidadContraseniasROJAS_enSuperCategoria, 
                reporte.obtenerCategoria(categoria_SuperCategoria.Nombre).cantidadROJO);
        }

        [TestMethod]
        public void CantiadadContraseniasNARANJA_Categoria_SuperCategoria()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(cantidadContraseniasNARANJAS_enSuperCategoria,
                reporte.obtenerCategoria(categoria_SuperCategoria.Nombre).cantidadNARANJA);
        }

        [TestMethod]
        public void CantiadadContraseniasAMARILLO_Categoria_SuperCategoria()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(cantidadContraseniasAMARILLAS_enSuperCategoria,
                reporte.obtenerCategoria(categoria_SuperCategoria.Nombre).cantidadAMARILLO);
        }

        [TestMethod]
        public void CantiadadContraseniasVERDE_CLARO_Categoria_SuperCategoria()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(cantidadContraseniasVERDE_CLARAS_enSuperCategoria,
                reporte.obtenerCategoria(categoria_SuperCategoria.Nombre).cantidadVERDE_CLARO);
        }

        [TestMethod]
        public void CantiadadContraseniasVERDE_OSCURO_Categoria_SuperCategoria()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(cantidadContraseniasVERDE_OSCURAS_enSuperCategoria,
                reporte.obtenerCategoria(categoria_SuperCategoria.Nombre).cantidadVERDE_OSCURO);
        }


        [TestMethod]
        public void CantiadadContraseniasROJO_Categoria_UltraCategoria()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(cantidadContraseniasROJAS_enUltraCategoria,
                reporte.obtenerCategoria(categoria_UltraCategoria.Nombre).cantidadROJO);
        }

        [TestMethod]
        public void CantiadadContraseniasNARANJA_Categoria_UltraCategoria()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(cantidadContraseniasNARANJAS_enUltraCategoria,
                reporte.obtenerCategoria(categoria_UltraCategoria.Nombre).cantidadNARANJA);
        }

        [TestMethod]
        public void CantiadadContraseniasAMARILLO_Categoria_UltraCategoria()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(cantidadContraseniasAMARILLAS_enUltraCategoria,
                reporte.obtenerCategoria(categoria_UltraCategoria.Nombre).cantidadAMARILLO);
        }

        [TestMethod]
        public void CantiadadContraseniasVERDE_CLARO_Categoria_UltraCategoriaa()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(cantidadContraseniasVERDE_CLARAS_enUltraCategoria,
                reporte.obtenerCategoria(categoria_UltraCategoria.Nombre).cantidadVERDE_CLARO);
        }

        [TestMethod]
        public void CantiadadContraseniasVERDE_OSCURO_Categoria_UltraCategoria()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(cantidadContraseniasVERDE_OSCURAS_enUltraCategoria,
                reporte.obtenerCategoria(categoria_UltraCategoria.Nombre).cantidadVERDE_OSCURO);
        }




    }
}
