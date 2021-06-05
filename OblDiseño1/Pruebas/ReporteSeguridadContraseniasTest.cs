using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using OblDiseño1;
using OblDiseño1.Entidades;

namespace Pruebas
{

    [TestClass]
    public class ReporteSeguridadContraseniasTest
    {
        const int nivelRojo = 1;
        const int nivelNaranja = 2;
        const int nivelAmarrillo = 3;
        const int nivelVerdeClaro = 4;
        const int nivelVerdeOscuro = 5;

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


        FuncionalidadReporte funcionalidad;

        [TestInitialize]
        public void SetUp()
        {
            string nombreCategoria_1 = "SuperCategoria";
            categoria_SuperCategoria = new Categoria(nombreCategoria_1);

            string nombreCategoria_2 = "UltraCategoria";
            categoria_UltraCategoria = new Categoria(nombreCategoria_2);

            string[] nombreUsuarios = { "JuanJuanJuan", "JuanFacebook", "JuanTwitter", "JuanTwitter2",
                        "JuanTwitter3", "JuanTwitter4", "JuanTwitter5","JuanTwitter6", "JuanTwitter7",
                                    "JuanTwitter8", "JuanTwitter9", "JuanTwitter10", "JuanTwitter11"};

            string[] contrasenias = { "Contracontra123.", "Contracontra123.", "C*ntra7witterrrrrrrrrrr",
            "1234567a1", "ContraTwitter45.", "aaaaa", "AAAAAA**-", "12-*SAAaa.", "aaaaaaaaaa",
            "oooooooooooooo7*Ooooooo", "aaaaaaaaaaaaaaAAAAAAAAA", "a*1A2", "ALALALALALALALALALALaL"};

            string[] sitios = {"ejemplo.ej.edu.uy", "facebook.com", "twitter.com", "twitter.com",
                        "twitter.com", "twitter.com", "twitter.com", "twitter.com", "twitter.com",
                                       "twitter.com", "twitter.com", "twitter.com", "twitter.com",  };

            string[] notas = { "Esta es una dupla de ejemplo", "Tengo que esperar 90 dias para que se borre",
                "Hacer una cuenta aca fue el peor error de mi vida", "Hice esta porque me suspendieron la otra",
                "Hice esta porque me suspendieron la de respuesto",
                "Hice esta porque me suspendieron el respuesto de la de repuesto",
                "Hice esta porque me suspendieron el repuesto del repuesto de la de repuesto",
                "Hice esta porque me suspendieron el repuesto del repuesto del repuesto de la de repuesto",
                "Perdi la cuenta de cuantos repuesto llevo", "Y me tuve que hacer otra",
                "Ojala me dieran un punto en Disenio de Aplicacion por cada cuenta que me suspendieron",
                "Otra mas", "La ultima, lo juro"};

            Contraseña contraseña1 = new Contraseña(contrasenias[0]);
            Contraseña contraseña2 = new Contraseña(contrasenias[1]);
            Contraseña contraseña3 = new Contraseña(contrasenias[2]);
            Contraseña contraseña4 = new Contraseña(contrasenias[3]);
            Contraseña contraseña5 = new Contraseña(contrasenias[4]);
            Contraseña contraseña6 = new Contraseña(contrasenias[5]);
            Contraseña contraseña7 = new Contraseña(contrasenias[6]);
            Contraseña contraseña8 = new Contraseña(contrasenias[7]);
            Contraseña contraseña9 = new Contraseña(contrasenias[8]);
            Contraseña contraseña10 = new Contraseña(contrasenias[9]);
            Contraseña contraseña11 = new Contraseña(contrasenias[10]);
            Contraseña contraseña12 = new Contraseña(contrasenias[11]);
            Contraseña contraseña13 = new Contraseña(contrasenias[12]);

            Dupla_UsuarioContrasenia duplaEjemplo_1 = new Dupla_UsuarioContrasenia(nombreUsuarios[0],
                contraseña1, sitios[0], notas[0], categoria_SuperCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_2 = new Dupla_UsuarioContrasenia(nombreUsuarios[1],
                contraseña2, sitios[1], notas[1], categoria_SuperCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_3 = new Dupla_UsuarioContrasenia(nombreUsuarios[2],
                contraseña3, sitios[2], notas[2], categoria_SuperCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_4 = new Dupla_UsuarioContrasenia(nombreUsuarios[3],
                contraseña4, sitios[3], notas[3], categoria_UltraCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_5 = new Dupla_UsuarioContrasenia(nombreUsuarios[4],
                contraseña5, sitios[4], notas[4], categoria_SuperCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_6 = new Dupla_UsuarioContrasenia(nombreUsuarios[5],
                contraseña6, sitios[5], notas[5], categoria_SuperCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_7 = new Dupla_UsuarioContrasenia(nombreUsuarios[6],
                contraseña7, sitios[6], notas[6], categoria_SuperCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_8 = new Dupla_UsuarioContrasenia(nombreUsuarios[7],
                contraseña8, sitios[7], notas[7], categoria_UltraCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_9 = new Dupla_UsuarioContrasenia(nombreUsuarios[8],
                contraseña9, sitios[8], notas[8], categoria_UltraCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_10 = new Dupla_UsuarioContrasenia(nombreUsuarios[9],
                contraseña10, sitios[9], notas[9], categoria_SuperCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_11 = new Dupla_UsuarioContrasenia(nombreUsuarios[10],
                contraseña11, sitios[10], notas[10], categoria_UltraCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_12 = new Dupla_UsuarioContrasenia(nombreUsuarios[11],
                contraseña12, sitios[11], notas[11], categoria_UltraCategoria);

            Dupla_UsuarioContrasenia duplaEjemplo_13 = new Dupla_UsuarioContrasenia(nombreUsuarios[12],
                contraseña13, sitios[12], notas[12], categoria_UltraCategoria);

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

            contraseniasROJAS = new List<Dupla_UsuarioContrasenia> { duplaEjemplo_6, duplaEjemplo_12 };
            contraseniasNARANJAS = new List<Dupla_UsuarioContrasenia> { duplaEjemplo_4, duplaEjemplo_7,
                                                                        duplaEjemplo_8, duplaEjemplo_9};
            contraseniasAMARILLAS = new List<Dupla_UsuarioContrasenia> { };
            contraseniasVERDE_CLARAS = new List<Dupla_UsuarioContrasenia> { duplaEjemplo_11, duplaEjemplo_13 };
            contraseniasVERDE_OSCURAS = new List<Dupla_UsuarioContrasenia> { duplaEjemplo_1, duplaEjemplo_2,
                                                                             duplaEjemplo_3, duplaEjemplo_5,
                                                                             duplaEjemplo_10};

            funcionalidad = new FuncionalidadReporte(usuario);
        }


        [TestMethod]
        public void CantidadContraseniasROJAS()
        {
            reporte reporte = funcionalidad.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(cantidadContraseniasROJAS, reporte.duplasPorSeguridad[nivelRojo].cantidad);
        }

        [TestMethod]
        public void CantidadContraseniasNARANJAS()
        {
            reporte reporte = funcionalidad.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(cantidadContraseniasNARANJAS, reporte.duplasPorSeguridad[nivelNaranja].cantidad);
        }

        [TestMethod]
        public void CantidadContraseniasAMARILLAS()
        {
            reporte reporte = funcionalidad.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(cantidadContraseniasAMARILLAS, reporte.duplasPorSeguridad[nivelAmarrillo].cantidad);
        }

        [TestMethod]
        public void CantidadContraseniasVERDE_CLARAS()
        {
            reporte reporte = funcionalidad.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(cantidadContraseniasVERDE_CLARAS, reporte.duplasPorSeguridad[nivelVerdeClaro].cantidad);
        }

        [TestMethod]
        public void CantidadContraseniasVERDE_OSCURAS()
        {
            reporte reporte = funcionalidad.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(cantidadContraseniasVERDE_OSCURAS, reporte.duplasPorSeguridad[nivelVerdeOscuro].cantidad);
        }

        [TestMethod]
        public void ListaContrasenias_ROJAS()
        {
            reporte reporte = funcionalidad.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(contraseniasROJAS, reporte.duplasPorSeguridad[nivelRojo].unaListaDuplas);
        }

        [TestMethod]
        public void ListaContrasenias_NARANJAS()
        {
            reporte reporte = funcionalidad.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(contraseniasNARANJAS, reporte.duplasPorSeguridad[nivelNaranja].unaListaDuplas);
        }

        [TestMethod]
        public void ListaContrasenias_AMARILLAS()
        {
            reporte reporte = funcionalidad.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(contraseniasAMARILLAS, reporte.duplasPorSeguridad[nivelAmarrillo].unaListaDuplas);
        }

        [TestMethod]
        public void ListaContrasenias_VERDE_CLARAS()
        {
            reporte reporte = funcionalidad.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(contraseniasVERDE_CLARAS, reporte.duplasPorSeguridad[nivelVerdeClaro].unaListaDuplas);
        }

        [TestMethod]
        public void ListaContrasenias_VERDE_OSCURAS()
        {
            reporte reporte = funcionalidad.ObtenerReporteSeguridadContrasenias();
            CollectionAssert.AreEquivalent(contraseniasVERDE_OSCURAS, reporte.duplasPorSeguridad[nivelVerdeOscuro].unaListaDuplas);
        }

        [TestMethod]
        public void CantiadadContraseniasROJO_Categoria_SuperCategoria()
        {
            reporte reporte = funcionalidad.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(cantidadContraseniasROJAS_enSuperCategoria,
                reporte.duplasPorCategoria[categoria_SuperCategoria.Nombre][nivelRojo]);
        }

        [TestMethod]
        public void CantiadadContraseniasNARANJA_Categoria_SuperCategoria()
        {
            reporte reporte = funcionalidad.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(cantidadContraseniasNARANJAS_enSuperCategoria,
                reporte.duplasPorCategoria[categoria_SuperCategoria.Nombre][nivelNaranja]);
        }

        [TestMethod]
        public void CantiadadContraseniasAMARILLO_Categoria_SuperCategoria()
        {
            reporte reporte = funcionalidad.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(cantidadContraseniasAMARILLAS_enSuperCategoria,
                reporte.duplasPorCategoria[categoria_SuperCategoria.Nombre][nivelAmarrillo]);
        }

        [TestMethod]
        public void CantiadadContraseniasVERDE_CLARO_Categoria_SuperCategoria()
        {
            reporte reporte = funcionalidad.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(cantidadContraseniasVERDE_CLARAS_enSuperCategoria,
                reporte.duplasPorCategoria[categoria_SuperCategoria.Nombre][nivelVerdeClaro]);
        }

        [TestMethod]
        public void CantiadadContraseniasVERDE_OSCURO_Categoria_SuperCategoria()
        {
            reporte reporte = funcionalidad.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(cantidadContraseniasVERDE_OSCURAS_enSuperCategoria,
                reporte.duplasPorCategoria[categoria_SuperCategoria.Nombre][nivelVerdeOscuro]);
        }

        [TestMethod]
        public void CantiadadContraseniasROJO_Categoria_UltraCategoria()
        {
            reporte reporte = funcionalidad.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(cantidadContraseniasROJAS_enUltraCategoria,
                reporte.duplasPorCategoria[categoria_UltraCategoria.Nombre][nivelRojo]);
        }

        [TestMethod]
        public void CantiadadContraseniasNARANJA_Categoria_UltraCategoria()
        {
            reporte reporte = funcionalidad.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(cantidadContraseniasNARANJAS_enUltraCategoria,
                reporte.duplasPorCategoria[categoria_UltraCategoria.Nombre][nivelNaranja]);
        }

        [TestMethod]
        public void CantiadadContraseniasAMARILLO_Categoria_UltraCategoria()
        {
            reporte reporte = funcionalidad.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(cantidadContraseniasAMARILLAS_enUltraCategoria,
                reporte.duplasPorCategoria[categoria_UltraCategoria.Nombre][nivelAmarrillo]);
        }

        [TestMethod]
        public void CantiadadContraseniasVERDE_CLARO_Categoria_UltraCategoriaa()
        {
            reporte reporte = funcionalidad.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(cantidadContraseniasVERDE_CLARAS_enUltraCategoria,
                reporte.duplasPorCategoria[categoria_UltraCategoria.Nombre][nivelVerdeClaro]);
        }

        [TestMethod]
        public void CantiadadContraseniasVERDE_OSCURO_Categoria_UltraCategoria()
        {
            reporte reporte = funcionalidad.ObtenerReporteSeguridadContrasenias();
            Assert.AreEqual(cantidadContraseniasVERDE_OSCURAS_enUltraCategoria,
                reporte.duplasPorCategoria[categoria_UltraCategoria.Nombre][nivelVerdeOscuro]);
        }

    }
}
