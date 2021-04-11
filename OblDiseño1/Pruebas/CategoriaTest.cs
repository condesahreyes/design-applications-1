using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1;

namespace Pruebas
{

    [TestClass]
    public class CategoriaTest
    {

        private readonly string nombre1 = "Hernán";
        private readonly string nombre2 = "Rodrigo";
        private readonly string nombreLargo = "HernánNombreLargo";
        private readonly string nombreCorto = "Ro";

        Categoria categoria = new Categoria(nombreCat1);

        [TestMethod]
        public void AltaCategoriaTest()
        {
            Assert.AreEqual(nombre1, categoria.nombre)
        }

        [TestMethod]
        public void ModificacionCategoriaTest()
        {
            categoria.setNombre(nombre2);
            Assert.AreEqual(nombre2, categoria.nombre)
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCategoriaDataException))]
        public void AltaCategoriaNombreLargo()
        {
            Categoria nombreLargo = new Categoria(nombreLargo);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCategoriaDataException))]
        public void AltaCategoriaNombreCorto()
        {
            Categoria nombreCorto = new Categoria(nombreCorto);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCategoriaDataException))]
        public void ModificacionCategoriaNombreLargo()
        {
            categoria.setNombre(nombreLargo);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCategoriaDataException))]
        public void ModificacionCategoriaNombreCorto()
        {
            categoria.setNombre(nombreCorto);
        }
    }
}
