using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblDiseño1;

namespace Pruebas
{
    [TestClass]
    public class Dupla_UsuarioContraseniaTest
    {
        private static string userName;
        private static string userPssw;
        private static string sitio;
        //private readonly string tipo = "SitioWeb";
        private static string nota;

        private static string nombreCategoria;
        Categoria categoria;
           
        private static DateTime ultimaModificacion = DateTime.Today;
        //Otra forma:Anio mes dia
        //new DateTime(2021, 04, 13);

        //Estos no se ingresan, se calculan/establecen por defecto, asi que solo declaramos estas solo se van a
        // usar para los Asset
        private static int nivelSeguridad = 5;
        private static bool dataBrench = false;


        private readonly static int largoInseguro = 6;
        private readonly static int largoSeguridadMedia = 10;
        private readonly static int largoSeguro = 18;
        private readonly static bool incluirMayus = true;
        private readonly static bool incluirMinus = true;
        private readonly static bool incluirDigitos = true;
        private readonly static bool incluirEspeciales = true;

        private readonly static int nivelSeguridadContraseniaRoja = 1;
        private readonly static int nivelSeguridadContraseniaNaranja = 2;
        private readonly static int nivelSeguridadContraseniaAmarilla = 3;
        private readonly static int nivelSeguridadContraseniaVerdeClaro = 4;
        private readonly static int nivelSeguridadContraseniaVerdeOscuro = 5;

        Dupla_UsuarioContrasenia newDupla;


        [TestInitialize]
        public void Setup() 
        {
            userName = "JuanEjemplo";
            userPssw = "aSD0v89ha+sfunv/*av";
            sitio = "sitio.ejemplo.uy";
            //private readonly string tipo = "SitioWeb";
            nota = "Esto es una nota para el test";

            nombreCategoria = "CategoriaEjemplo";
            categoria = new Categoria(nombreCategoria);


            ultimaModificacion = DateTime.Today;
            //Otra forma:Anio mes dia
            //new DateTime(2021, 04, 13);

            //Estos no se ingresan, se calculan/establecen por defecto, asi que solo declaramos estas solo se van a
            // usar para los Asset
            nivelSeguridad = 5;
            dataBrench = false;


            newDupla = new Dupla_UsuarioContrasenia(userName, userPssw, sitio, nota, categoria);
        }


    /* REFERENCIAS:

    NIVELES DE SEGURIDAD:
    ● (1) Rojo: Contraseña con largo menor a 8 caracteres. 
    ● (2) Naranja: Contraseña con largo entre 8 y 14 caracteres. 
    ● (3) Amarillo: Contraseña con largo mayor a 14 caracteres, sólo mayúsculas o minúsculas. 
    ● (4) Verde Claro: Contraseña con largo mayor a 14 caracteres, con mayúsculas y minúsculas. 
    ● (5) Verde Oscuro: Contraseña con largo mayor a 14 caracteres, con mayúsculas, minúsculas, números y símbolos.

    VARIABLES de "Dupla_UsuarioContrasenia":
    - userDupla: String
    - pssDupla: String
    - nombreSitioApp: String
    - tipoSitioOApp: String
    - nota: String

    - categoria: Categoria
    - fechaUltimaModificacion: DateTime

    - nivelSeguridadPss: Int

    - dataBrench: Bool
    */


    public bool[] getTiposDeCaracteresContenidos(String str) 
        {
            bool contieneMayusculas = false;
            bool contieneMinusculas = false;
            bool contieneDigitos = false;
            bool contineeEspeciales = false;
            for (int i = 0; i < str.Length && !contieneMayusculas; i++)
            {
                int codigoASCII = (int)str[i];
                if (codigoASCII >= 65 && codigoASCII <= 90)
                {
                    contieneMayusculas = true;
                }
                else if (codigoASCII >= 97 && codigoASCII <= 122)
                {
                    contieneMinusculas = true;
                }
                else if (codigoASCII >= 48 && codigoASCII <= 57)
                {
                    contieneDigitos = true;
                }
                else if ((codigoASCII >= 32 && codigoASCII <= 47) || (codigoASCII >= 58 && codigoASCII <= 64)
                    || (codigoASCII >= 91 && codigoASCII <= 96) || (codigoASCII >= 123 && codigoASCII <= 126))
                {
                    contineeEspeciales = true;
                }
            }

            /*
             toReturn[0] == true -> si str contiene mayusculas
             toReturn[1] == true -> si str contiene minusculas
             toReturn[2] == true -> si str contiene dijitos
             toReturn[3] == true -> si str contiene especiales
            */

            bool[] toReturn = {contieneMayusculas, contieneMinusculas, contieneDigitos, contineeEspeciales};
            return toReturn;
        }

        [TestMethod]
        public void Alta_DuplaUsuarioContrasenia()
        {
            Assert.IsNotNull(newDupla);
        }

        [TestMethod]
        public void Alta_Verificacion_Datos_DuplaUsuarioContrasenia()
        { 
            Assert.AreEqual(userName, newDupla.usernameDupla);
            Assert.AreEqual(userPssw, newDupla.pssDupla);
            Assert.AreEqual(sitio, newDupla.nombreSitioApp);
            //Assert.AreEqual(tipo, newDupla.tipoSitioOApp);
            Assert.AreEqual(nota, newDupla.nota);
            Assert.AreEqual(nivelSeguridad, newDupla.nivelSeguridadPss);
            Assert.AreEqual(dataBrench, newDupla.dataBrench);
            Assert.AreEqual(ultimaModificacion, newDupla.fechaUltimaModificacion);
            Assert.AreEqual(categoria, newDupla.categoria);
        }

        [TestMethod]
        public void ModificacionDatos_DuplaUsuarioContrasenia()
        {
            //Estos son los campos que el usuario puede modificar
            string newUserName = "PedroEjemplo";
            string newPassword = "aaaaa";
            string newSitio = "otroStioDeEjemplo.edu.uy";
            string newNota = "mala contrasenia";
            Categoria newCategoria = new Categoria("Categoria De Ejemplo 2");

            DateTime nuevaUltimaModificacion = new DateTime(2021, 03, 29);

            //Estos se infiero de los anteriores
            int newNivelSeguridad = 1;
       

            newDupla.usernameDupla = newUserName;
            newDupla.pssDupla = newPassword;
            newDupla.nombreSitioApp = newSitio;
            newDupla.nota = newNota;
            newDupla.categoria = newCategoria;
            newDupla.fechaUltimaModificacion = nuevaUltimaModificacion;

            Assert.AreEqual(newUserName, newDupla.usernameDupla);
            Assert.AreEqual(newPassword, newDupla.pssDupla);
            Assert.AreEqual(newSitio, newDupla.nombreSitioApp);
            //Assert.AreEqual(tipo, newDupla.tipoSitioOApp);
            Assert.AreEqual(newNota, newDupla.nota);
            Assert.AreEqual(newNivelSeguridad, newDupla.nivelSeguridadPss);
            Assert.AreEqual(nuevaUltimaModificacion, newDupla.fechaUltimaModificacion);
            Assert.AreEqual(newCategoria, newDupla.categoria);
        }



        [TestMethod]
        public void GeneracionDeContrasenia_LargoCorrecto() 
        {
            string contraseniaDeLargoInseguro = Dupla_UsuarioContrasenia.generarContrasenia(largoInseguro, incluirMayus, incluirMinus, incluirDigitos, incluirEspeciales);
            Assert.AreEqual(largoInseguro, contraseniaDeLargoInseguro.Length);
        }

        [TestMethod]
        public void GeneracionDeContrasenia_CaracteresCorrectos() 
        {
            string contraseniaParaTestearCaracteres = Dupla_UsuarioContrasenia.generarContrasenia(largoInseguro, incluirMayus, !incluirMinus, incluirDigitos, incluirEspeciales);
            bool[] tiposDeCaracteresContenidos = getTiposDeCaracteresContenidos(contraseniaParaTestearCaracteres);
            Assert.IsTrue(tiposDeCaracteresContenidos[0] && !tiposDeCaracteresContenidos[1] && tiposDeCaracteresContenidos[2] && tiposDeCaracteresContenidos[3]);
        }

        [TestMethod]
        public void GeneracionDeContrasenia_SeguiridadRoja()
        {
            string contraseniaRoja = "2b+2B+"; //Length == 6
            int nivelSeguridad_contrRoja = Dupla_UsuarioContrasenia.calcularSeguridad(contraseniaRoja);
            Assert.AreEqual(nivelSeguridadContraseniaRoja, nivelSeguridad_contrRoja);
        }

        [TestMethod]
        public void GeneracionDeContrasenia_SeguiridadNaranja()
        {
            string contraseniaNaranja = "Ashen0ne++"; //Length == 10
            int nivelSeguridad_contrNaranja = Dupla_UsuarioContrasenia.calcularSeguridad(contraseniaNaranja);
            Assert.AreEqual(nivelSeguridadContraseniaNaranja, nivelSeguridad_contrNaranja);
        }

        [TestMethod]
        public void GeneracionDeContrasenia_SeguiridadAmarilla()
        {
            string contraseniaAmarilla = "4ST0RA_GREAT-SWORD"; //Length == 18
            int nivelSeguridad_contrAmarilla = Dupla_UsuarioContrasenia.calcularSeguridad(contraseniaAmarilla);
            Assert.AreEqual(nivelSeguridadContraseniaAmarilla, nivelSeguridad_contrAmarilla);
        }

        [TestMethod]
        public void GeneracionDeContrasenia_SeguiridadVerdeClaro()
        {
            string contraseniaVerdeClaro = "AncientGearChosGiant10";
            int nivelSeguridad_contrVerdeClaro = Dupla_UsuarioContrasenia.calcularSeguridad(contraseniaVerdeClaro);
            Assert.AreEqual(nivelSeguridadContraseniaVerdeClaro, nivelSeguridad_contrVerdeClaro);
        }

        [TestMethod]
        public void GeneracionDeContrasenia_SeguiridadVerdeOscuro()
        {
            string contraseniaVerdeOscuro = "AaBbCcDdEeFfGg123+-*";
            int nivelSeguridad_contrVerdeOscuro = Dupla_UsuarioContrasenia.calcularSeguridad(contraseniaVerdeOscuro);
            Assert.AreEqual(nivelSeguridadContraseniaVerdeOscuro, nivelSeguridad_contrVerdeOscuro);
        }


        [TestMethod]
        public void Baja_DuplaUsuarioContrasenia()
        {
            newDupla.darDeBaja_Dupla();
            Assert.IsNull(newDupla);
        }
    }
}
