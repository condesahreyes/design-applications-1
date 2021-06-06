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

        private Usuario usuario;

        private FuncionalidadReporte funcionalidad;

        private Categoria categoria_SuperCategoria;
        private Categoria categoria_UltraCategoria;

        private List<Dupla_UsuarioContrasenia> contraseniasROJAS;
        private List<Dupla_UsuarioContrasenia> contraseniasNARANJAS;
        private List<Dupla_UsuarioContrasenia> contraseniasAMARILLAS;
        private List<Dupla_UsuarioContrasenia> contraseniasVERDE_CLARAS;
        private List<Dupla_UsuarioContrasenia> contraseniasVERDE_OSCURAS;

        private readonly int nivelRojo = 1;
        private readonly int nivelNaranja = 2;
        private readonly int nivelAmarrillo = 3;
        private readonly int nivelVerdeClaro = 4;
        private readonly int nivelVerdeOscuro = 5;

        private readonly int cantidadContraseniasROJAS = 2;
        private readonly int cantidadContraseniasNARANJAS = 4;
        private readonly int cantidadContraseniasAMARILLAS = 0;
        private readonly int cantidadContraseniasVERDE_CLARAS = 2;
        private readonly int cantidadContraseniasVERDE_OSCURAS = 5;

        private readonly int cantidadContraseniasROJAS_enSuperCategoria = 0;
        private readonly int cantidadContraseniasNARANJAS_enSuperCategoria = 2;
        private readonly int cantidadContraseniasAMARILLAS_enSuperCategoria = 0;
        private readonly int cantidadContraseniasVERDE_CLARAS_enSuperCategoria = 2;
        private readonly int cantidadContraseniasVERDE_OSCURAS_enSuperCategoria = 3;

        private readonly int cantidadContraseniasROJAS_enUltraCategoria = 2;
        private readonly int cantidadContraseniasNARANJAS_enUltraCategoria = 2;
        private readonly int cantidadContraseniasAMARILLAS_enUltraCategoria = 0;
        private readonly int cantidadContraseniasVERDE_CLARAS_enUltraCategoria = 0;
        private readonly int cantidadContraseniasVERDE_OSCURAS_enUltraCategoria = 2;

        private readonly string[] nombreUsuarios = { "JuanJuanJuan", "JuanFacebook", "JuanTwitter", "JuanTwitter2",
                        "JuanTwitter3", "JuanTwitter4", "JuanTwitter5","JuanTwitter6", "JuanTwitter7",
                                    "JuanTwitter8", "JuanTwitter9", "JuanTwitter10", "JuanTwitter11"};

        private readonly string[] contrasenias = { "Contracontra123.", "Contracontra123.", "C*ntra7witterrrrrrrrrrr",
            "1234567a1", "ContraTwitter45.", "aaaaa", "AAAAAA**-", "12-*SAAaa.", "aaaaaaaaaa",
            "oooooooooooooo7*Ooooooo", "aaaaaaaaaaaaaaAAAAAAAAA", "a*1A2", "ALALALALALALALALALALaL"};

        private readonly string[] sitios = {"ejemplo.ej.edu.uy", "facebook.com", "twitter.com", "twitter.com",
                        "twitter.com", "twitter.com", "twitter.com", "twitter.com", "twitter.com",
                                       "twitter.com", "twitter.com", "twitter.com", "twitter.com",  };

        private readonly string[] notas = { "Esta es una dupla de ejemplo", "Tengo que esperar 90 dias para que se borre",
                "Hacer una cuenta aca fue el peor error de mi vida", "Hice esta porque me suspendieron la otra",
                "Hice esta porque me suspendieron la de respuesto",
                "Hice esta porque me suspendieron el respuesto de la de repuesto",
                "Hice esta porque me suspendieron el repuesto del repuesto de la de repuesto",
                "Hice esta porque me suspendieron el repuesto del repuesto del repuesto de la de repuesto",
                "Perdi la cuenta de cuantos repuesto llevo", "Y me tuve que hacer otra",
                "Ojala me dieran un punto en Disenio de Aplicacion por cada cuenta que me suspendieron",
                "Otra mas", "La ultima, lo juro"};


        [TestInitialize]
        public void SetUp()
        {
            string nombreCategoria_1 = "SuperCategoria";
            categoria_SuperCategoria = new Categoria(nombreCategoria_1);

            string nombreCategoria_2 = "UltraCategoria";
            categoria_UltraCategoria = new Categoria(nombreCategoria_2);

            string nombreUsuario = "JuanEjemplez";
            string contraseniaUsuario = "aaaaaa";
            usuario = new Usuario(nombreUsuario, contraseniaUsuario);
            usuario.AgregarCategoria(categoria_SuperCategoria);
            usuario.AgregarCategoria(categoria_UltraCategoria);

            CrearCredenciales();
            CargarListasContraseniasPorNiveles();

            funcionalidad = new FuncionalidadReporte(usuario);
        }

        private void CrearCredenciales()
        {
            for (int i = 0; i < nombreUsuarios.Length; i++)
            {
                Dupla_UsuarioContrasenia unaCredencial;

                Contraseña contraseña = new Contraseña(contrasenias[i]);

                if(i%2==0)
                    unaCredencial = new Dupla_UsuarioContrasenia(nombreUsuarios[i],
                        contraseña, sitios[i], notas[i], categoria_SuperCategoria);
                else
                    unaCredencial = new Dupla_UsuarioContrasenia(nombreUsuarios[i],
                         contraseña, sitios[i], notas[i], categoria_UltraCategoria);

                usuario.AgregarDupla(unaCredencial);
            }
        }

        private void CargarListasContraseniasPorNiveles()
        {
            List<Dupla_UsuarioContrasenia> listaDuplas = usuario.ObtenerDuplas();

            contraseniasROJAS = new List<Dupla_UsuarioContrasenia> { listaDuplas[5], listaDuplas[11] };
            contraseniasNARANJAS = new List<Dupla_UsuarioContrasenia> { listaDuplas[3], listaDuplas[6],
                                                                        listaDuplas[7], listaDuplas[8]};
            contraseniasAMARILLAS = new List<Dupla_UsuarioContrasenia> { };
            contraseniasVERDE_CLARAS = new List<Dupla_UsuarioContrasenia> { listaDuplas[10], listaDuplas[12] };
            contraseniasVERDE_OSCURAS = new List<Dupla_UsuarioContrasenia> { listaDuplas[0], listaDuplas[1],
                                                                             listaDuplas[2], listaDuplas[4],
                                                                             listaDuplas[9] };
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
