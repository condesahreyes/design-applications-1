using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1;
using System;

namespace Pruebas
{

    [TestClass]
    public class CategoriaTest
    {

        private static readonly string nombre1 = "Personal";
        private static readonly string nombre2 = "Trabajo";
        private static readonly string nombreLargo = "CategoriaTiempoLibre";
        private static readonly string nombreCorto = "Ro";
        private readonly string mensajeNombreIncorrecto = "El nombre debe tener entre 3 y 15 caracteres";

        Categoria categoria = new Categoria(nombre1);

        [TestMethod]
        public void AltaCategoriaTest()
        {
            Assert.AreEqual(nombre1, categoria.Nombre);
        }

        [TestMethod]
        public void ModificacionCategoriaTest()
        {
            categoria.ActualizarNombre(nombre2);
            Assert.AreEqual(nombre2, categoria.Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(Exepcion_InvalidCategoriaData))]
        public void AltaCategoriaNombreLargo()
        {
                Categoria nombreLargoCat = new Categoria(nombreLargo);
        }

        [TestMethod]
        [ExpectedException(typeof(Exepcion_InvalidCategoriaData))]
        public void AltaCategoriaNombreCorto()
        {
            Categoria nombreCortoCat = new Categoria(nombreCorto);
        }

        [TestMethod]
        [ExpectedException(typeof(Exepcion_InvalidCategoriaData))]
        public void ModificacionCategoriaNombreLargo()
        {
            categoria.ActualizarNombre(nombreLargo);
        }

        [TestMethod]
        [ExpectedException(typeof(Exepcion_InvalidCategoriaData))]
        public void ModificacionCategoriaNombreCorto()
        {
            categoria.ActualizarNombre(nombreCorto);
        }
    }
}
