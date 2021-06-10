using System;
using System.Text;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace OblDiseño1.Entidades
{
    public class Contraseña
    {
        public string Contrasenia { get => contrasenia; set => ActualizarContrasenia(value); }
        public int NivelSeguridadContrasenia { set; get; }

        private const string caracteresEspeciales = " !\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
        private const string caracteresMayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string caracteresMinusculas = "abcdefghijklmnopqrstuvwxyz";
        private const string caracteresNumericos = "0123456789";

        private static string[] caracteresPorPosicion = { caracteresMayusculas,
            caracteresMinusculas, caracteresNumericos, caracteresEspeciales};

        private const int CONTRASENIA_LARGO_MAX = 25;
        private const int CONTRASENIA_LARGO_MIN = 5;

        private static Random numRandom = new Random();

        private string contrasenia;


        public Contraseña() { } 
        public Contraseña(string unaContrasenia)
        {
            Contrasenia = unaContrasenia;
            NivelSeguridadContrasenia = CalcularSeguridad(contrasenia);
        }

        public void ActualizarContrasenia(string unaContrasenia)
        {
            int largo = unaContrasenia.Length;

            if (EsLargoInvalidoContrasenia(largo))
                throw new ExepcionDatosDeContraseniaInvalidos($"Largo invalido: la contraseña debe" +
                    $" contener entre {CONTRASENIA_LARGO_MIN} y {CONTRASENIA_LARGO_MAX} caracteres");
            else
            {
                this.contrasenia = unaContrasenia;
                NivelSeguridadContrasenia = CalcularSeguridad(contrasenia);
            }
        }

        private static bool EsLargoInvalidoContrasenia(int largo)
        {
            return largo < CONTRASENIA_LARGO_MIN || largo > CONTRASENIA_LARGO_MAX;
        }

        public static int CalcularSeguridad(string unaContrasenia)
        {
            int contraseniaLargo = unaContrasenia.Length;
            bool[] tiposDeCaracteres = ObtenerTiposCaracteresContenidos(unaContrasenia);

            if (contraseniaLargo < 8)
                return 1;
            else if (contraseniaLargo <= 14)
                return 2;
            else if (tiposDeCaracteres[0] && tiposDeCaracteres[1] && tiposDeCaracteres[2] && tiposDeCaracteres[3])
                return 5;
            else if (EsVerdeClaro(tiposDeCaracteres))
                return 4;
            else if (tiposDeCaracteres[0] || tiposDeCaracteres[1] || tiposDeCaracteres[2] || tiposDeCaracteres[3])
                return 3;

            return -1;
        }

        public static bool EsVerdeClaro(bool[] tiposDeCaracteres)
        {
            return (tiposDeCaracteres[0] && tiposDeCaracteres[1]) ||
            (tiposDeCaracteres[0] && tiposDeCaracteres[1] && tiposDeCaracteres[2]) ||
            (tiposDeCaracteres[0] && tiposDeCaracteres[1] && tiposDeCaracteres[3]) ||
            (tiposDeCaracteres[1] && tiposDeCaracteres[2] && tiposDeCaracteres[3]) ||
            (tiposDeCaracteres[0] && tiposDeCaracteres[2] && tiposDeCaracteres[3]);
        }

        public static bool[] ObtenerTiposCaracteresContenidos(string str)
        {
            char caracterDelString;
            int tipoCaracter;
            bool[] tiposDeCaracteres = new bool[caracteresPorPosicion.Length];

            for (int i = 0; i < str.Length; i++)
            {
                caracterDelString = str[i];
                tipoCaracter = TipoDeUnCaracter(caracterDelString);

                if (tipoCaracter != -1)
                    tiposDeCaracteres[tipoCaracter] = true;
            }

            return tiposDeCaracteres;
        }

        private static int TipoDeUnCaracter(char caracter)
        {
            for (int i = 0; i < caracteresPorPosicion.Length; i++)
                if (caracteresPorPosicion[i].Contains(caracter.ToString()))
                    return i;

            return -1;
        }

        public static string GenerarContrasenia(int largo, bool[] caracteresRequeridos)
        {
            string contrasenia;

            if (EsLargoInvalidoContrasenia(largo))
                throw new ExepcionDatosDeContraseniaInvalidos($"Largo invalido: la contraseña debe contener " +
                    $"entre {CONTRASENIA_LARGO_MIN} y {CONTRASENIA_LARGO_MAX} caracteres");
            else if (ContarCantidadDeCaracteresFaltantes(caracteresRequeridos) == 0)
                throw new ExepcionDatosDeContraseniaInvalidos("Debe seleccionar al menos un caracter");

            contrasenia = GenerarString(largo, caracteresRequeridos);

            return contrasenia;
        }

        private static int GenerarNumAlazar(int numMin, int numMax)
        {
            int num = numRandom.Next(numMin, numMax);
            return num;
        }

        private static string GenerarString(int largoString, bool[] caracteresRequeridos)
        {

            string stringGenerado = "";

            bool[] caracteresFaltantes = CopiarArrayBool(caracteresRequeridos);

            while (largoString > 0)
            {
                stringGenerado = ConstruirStringPorLetra(caracteresRequeridos, ref caracteresFaltantes, stringGenerado);
                int tiposDeCarateresRestantes = ContarCantidadDeCaracteresFaltantes(caracteresFaltantes);
                if (tiposDeCarateresRestantes + 1 == largoString)
                    caracteresRequeridos = caracteresFaltantes;
                largoString--;
            }

            return stringGenerado;
        }

        private static bool[] CopiarArrayBool(bool[] array)
        {
            int largoArray = array.Length;
            bool[] arrayGenerado = new bool[largoArray];

            for (int i = 0; i < largoArray; i++)
                arrayGenerado[i] = array[i];

            return arrayGenerado;
        }

        private static int ContarCantidadDeCaracteresFaltantes(bool[] tipoCaracteresFaltantes)
        {
            int cantidadCaracteresFaltantes = 0;
            int largoArray = tipoCaracteresFaltantes.Length;

            for (int i = 0; i < largoArray; i++)
                if (tipoCaracteresFaltantes[i])
                    cantidadCaracteresFaltantes++;

            return cantidadCaracteresFaltantes;
        }

        private static string ConstruirStringPorLetra(bool[] esCaracteresRequeridos,
            ref bool[] esCaracteresFaltantes, string aSeguirGenerando)
        {
            bool generoUnCaracter = false;
            int numAlazaro ;

            while (!generoUnCaracter)
            {
                numAlazaro = GenerarNumAlazar(0, 4);

                if (esCaracteresRequeridos[numAlazaro])
                {
                    generoUnCaracter = true;
                    string caracterGenerado = DevolverCaracterAlazar(caracteresPorPosicion[numAlazaro]);
                    esCaracteresFaltantes[numAlazaro] = false;
                    aSeguirGenerando += caracterGenerado;
                }
            }
            return aSeguirGenerando;
        }

        private static string DevolverCaracterAlazar(string cadena)
        {
            return cadena[GenerarNumAlazar(0, cadena.Length)].ToString();
        }

        public override string ToString()
        {
            return ("Contraseña: " + this.contrasenia + " Nivel de seguridad: " +this.NivelSeguridadContrasenia);
        }
    }
}