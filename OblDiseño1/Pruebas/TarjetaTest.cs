using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1;

namespace Pruebas
{
    [TestClass]
    public class TarjetaTest
    {

        Categoria categoria = new Categoria("Personal");
        string nombre = "Rodri";
        string tipo = "Visa";
        long numero = 1876322167154328;
        int codigoSeguridad = 241;
        DateTime fechaVencimiento = new DateTime(2024, 10, 05);
        Tarjeta tarjetaEsperada = new Tarjeta(nombre, tipo, numero, codigoSeguridad, fechaVencimiento, categoria,"");



        [TestMethod]
        public void Alta_Tarjeta_Test()
        {
            Assert.AreEqual(tarjetaEsperada, new Tarjeta().altaTarjeta("Rodri", "Visa", 1876322167154328, 241, new DateTime(2024, 10, 05), "Personal",""));
        }

        [TestMethod]
        [ExpectedException(typeof(TarjetaNumeroIncorrectoException))]
        public void Alta_Tarjeta_NumeroIncorrecto_Test() 
        {
            Tarjeta tarjetaNumeroIncoreccto = new Tarjeta().altaTarjeta(nombre, tipo, 8371635461, codigoSeguridad, fechaVencimiento, categoria,"");
            
        }


        public void Modificar_Tarjeta_Test() 
        {
            Tarjeta tarjetaResultante = new Tarjeta("Hernan","MasterCard",8471998674553411,789, new DateTime(2024, 10, 05),"Trabajo","");
            tarjeta.modificarTarjeta(nombre, tipo, numero, codigoSeguridad, fechaVencimiento, categoria, "");
            Assert.AreEqual(tarjetaEsperada, tarjetaResultante);
        }

        public void Baja_Tarjeta_Test() 
        {
            Tarjeta tarjetaABorrar = new Tarjeta(nombre, tipo, numero, codigoSeguridad, fechaVencimiento, categoria, "");
            tarjetaABorrar.bajaTarjeta();
            Assert.IsNull(tarjetaABorrar);
        }











    }
}
