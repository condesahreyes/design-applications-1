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
        private readonly int cantidadContraseniasNARANJAS = 3;
        private readonly int cantidadContraseniasAMARILLAS = 0;
        private readonly int cantidadContraseniasVERDE_CLARAS = 2;
        private readonly int cantidadContraseniasVERDE_OSCURAS = 4;
        private Usuario usuario;
        private List<Dupla_UsuarioContrasenia> contraseniasROJAS;
        private List<Dupla_UsuarioContrasenia> contraseniasNARANJAS;
        private List<Dupla_UsuarioContrasenia> contraseniasAMARILLAS;
        private List<Dupla_UsuarioContrasenia> contraseniasVERDE_CLARAS;
        private List<Dupla_UsuarioContrasenia> contraseniasVERDE_OSCURAS;
        
        [TestInitialize]
        public void SetUp()
        {
            string nombreCategoria = "SuperCategoria";
            Categoria categoriaEjemplo = new Categoria(nombreCategoria);

            

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
            string passwordDupla_1 = "Contracontra123.";            //VO
            string passwordDupla_2 = "Contracontra123.";            //VO
            string passwordDupla_3 = "c*ntra7witterrrrrrrrrrr";     //VO
            string passwordDupla_4 = "1234567a1";                   //N
            string passwordDupla_5 = "ContraTwitter45.";            //VO
            string passwordDupla_6 = "aaaaa";                       //R
            string passwordDupla_7 = "AAAAAA*";                     //N
            string passwordDupla_8 = "12-*SAAaa.";                  //N
            string passwordDupla_9 = "aaaaaaaaaa";                  //N 
            string passwordDupla_10 = "oooooooooooooo7*Ooooooo";    //VO
            string passwordDupla_11 = "aaaaaaaaaaaaaaAAAAAAAAA";    //VC
            string passwordDupla_12 = "a*1A2";                      //R
            string passwordDupla_13 = "ALALALALALALALALALALAL";     //VC
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
                passwordDupla_1, sitioDupla_1, notaDupla_1, categoriaEjemplo);

            Dupla_UsuarioContrasenia duplaEjemplo_2 = new Dupla_UsuarioContrasenia(userNameDupla_2,
                passwordDupla_2, sitioDupla_2, notaDupla_2, categoriaEjemplo);

            Dupla_UsuarioContrasenia duplaEjemplo_3 = new Dupla_UsuarioContrasenia(userNameDupla_3,
                passwordDupla_3, sitioDupla_3, notaDupla_3, categoriaEjemplo);

            Dupla_UsuarioContrasenia duplaEjemplo_4 = new Dupla_UsuarioContrasenia(userNameDupla_4,
                passwordDupla_4, sitioDupla_4, notaDupla_4, categoriaEjemplo);

            Dupla_UsuarioContrasenia duplaEjemplo_5 = new Dupla_UsuarioContrasenia(userNameDupla_5,
                passwordDupla_5, sitioDupla_5, notaDupla_5, categoriaEjemplo);

            Dupla_UsuarioContrasenia duplaEjemplo_6 = new Dupla_UsuarioContrasenia(userNameDupla_6,
                passwordDupla_6, sitioDupla_6, notaDupla_6, categoriaEjemplo);

            Dupla_UsuarioContrasenia duplaEjemplo_7 = new Dupla_UsuarioContrasenia(userNameDupla_7,
                passwordDupla_7, sitioDupla_7, notaDupla_7, categoriaEjemplo);

            Dupla_UsuarioContrasenia duplaEjemplo_8 = new Dupla_UsuarioContrasenia(userNameDupla_8,
                passwordDupla_8, sitioDupla_8, notaDupla_8, categoriaEjemplo);

            Dupla_UsuarioContrasenia duplaEjemplo_9 = new Dupla_UsuarioContrasenia(userNameDupla_9,
                passwordDupla_9, sitioDupla_9, notaDupla_9, categoriaEjemplo);

            Dupla_UsuarioContrasenia duplaEjemplo_10 = new Dupla_UsuarioContrasenia(userNameDupla_10,
                passwordDupla_10, sitioDupla_10, notaDupla_10, categoriaEjemplo);

            Dupla_UsuarioContrasenia duplaEjemplo_11 = new Dupla_UsuarioContrasenia(userNameDupla_11,
                passwordDupla_11, sitioDupla_11, notaDupla_11, categoriaEjemplo);

            Dupla_UsuarioContrasenia duplaEjemplo_12 = new Dupla_UsuarioContrasenia(userNameDupla_12,
                passwordDupla_12, sitioDupla_12, notaDupla_12, categoriaEjemplo);

            Dupla_UsuarioContrasenia duplaEjemplo_13 = new Dupla_UsuarioContrasenia(userNameDupla_13,
                passwordDupla_13, sitioDupla_13, notaDupla_13, categoriaEjemplo);

            string nombreUsuario = "JuanEjemplez";
            string contraseniaUsuario = "aaaaaa";
            usuario = new Usuario(nombreUsuario, contraseniaUsuario);
            usuario.AgregarCategoria(categoriaEjemplo);
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
            Assert.AreEqual(reporte.numeroContrasROJO, cantidadContraseniasROJAS);
        }

        [TestMethod]
        public void CantidadContraseniasNARANJAS()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(reporte.numeroContrasNARANJA, cantidadContraseniasNARANJAS);
        }

        [TestMethod]
        public void CantidadContraseniasAMARILLAS()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(reporte.numeroContrasAMARILLO, cantidadContraseniasAMARILLAS);
        }
        
        [TestMethod]
        public void CantidadContraseniasVERDE_CLARAS()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(reporte.numeroContrasVERDE_CLARO, cantidadContraseniasVERDE_CLARAS);
        }

        [TestMethod]
        public void CantidadContraseniasVERDE_OSCURAS()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(reporte.numeroContrasVERDE_OSCURO, cantidadContraseniasVERDE_OSCURAS);
        }

        [TestMethod]
        public void ListaContrasenias_ROJAS()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(reporte.ListaROJO, contraseniasROJAS);
        }

        [TestMethod]
        public void ListaContrasenias_NARANJAS()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(reporte.ListaNARANJA, contraseniasNARANJAS);
        }

        [TestMethod]
        public void ListaContrasenias_AMARILLAS()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(reporte.ListaAMARILLO, contraseniasAMARILLAS);
        }

        [TestMethod]
        public void ListaContrasenias_VERDE_CLARAS()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(reporte.ListaVERDE_CLARO, contraseniasVERDE_CLARAS);
        }

        [TestMethod]
        public void ListaContrasenias_VERDE_OSCURAS()
        {
            ReporteSeguridadContrasenias reporte = usuario.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(reporte.ListaVERDE_OSCURO, contraseniasVERDE_OSCURAS);
        }
    }
}
