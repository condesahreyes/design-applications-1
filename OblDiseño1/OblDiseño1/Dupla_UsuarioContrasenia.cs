using System;
using System.Text;
using System.Collections;

namespace OblDiseño1
{
    public class Dupla_UsuarioContrasenia
    {

        public string NombreUsuario { get => nombreUsuario; set => ActualizarNombreUsuario(value);}

        public string Contrasenia { get => contrasenia; set => ActualizarContrasenia(value);}

        public string NombreSitioApp { get => nombreSitioApp; set => ActualizarNombreSitioApp(value);}

        public string TipoSitioOApp { get; set;}

        public string Nota { get => nota; set => ActualizarNota(value);}

        public Categoria Categoria { get; set;}

        public DateTime FechaUltimaModificacion { get; set;}

        public int NivelSeguridadContrasenia { get => nivelSeguridadContrasenia;}

        public bool DataBrench { get; set;}

        private const string caracteresNumericos = "0123456789";
        private const string caracteresMinusculas = "abcdefghijklmnopqrstuvwxyz";
        private const string caracteresMayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string caracteresEspeciales = " !\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";

        private string contrasenia;
        private string nombreUsuario;

        private const int CONTRASENIA_LARGO_MIN = 5;
        private const int CONTRASENIA_LARGO_MAX = 25;
        private const int NOMBRE_LARGO_MIN = 5;
        private const int NOMBRE_LARGO_MAX = 25;
        private const int SITIO_LARGO_MIN = 3;
        private const int SITIO_LARGO_MAX = 25;
        private const int NOTA_LARGO_MAX = 250;
        private int nivelSeguridadContrasenia;
        private string nombreSitioApp;
        private string nota;

        private static string[] caracteresPorPosicion = { caracteresMayusculas, 
            caracteresMinusculas, caracteresNumericos, caracteresEspeciales};

        public Dupla_UsuarioContrasenia(string unNombreUsuario, string unaContrasenia, 
            string unSitio, string laNota, Categoria laCategoria)
        {
            NombreUsuario = unNombreUsuario;
            Contrasenia = unaContrasenia;
            NombreSitioApp = unSitio;
            Nota = laNota;
            Categoria = laCategoria;
            FechaUltimaModificacion = DateTime.Today;
            nivelSeguridadContrasenia = CalcularSeguridad(contrasenia);
            DataBrench = false;
        }

        public void ActualizarNota(string unaNota)
        {
            int largoNota = unaNota.Length;

            if (largoNota > NOTA_LARGO_MAX)
                throw new Exepcion_DatosDeContraseniaInvalidos($"La nota debe contener " +
                    $"como maximo {NOTA_LARGO_MAX} caracteres");
            else
                nota = unaNota;
        }

        public void ActualizarNombreSitioApp(string unNombreSitioApp)
        {
            int largoNombre = unNombreSitioApp.Length;

            if (largoNombre < SITIO_LARGO_MIN || largoNombre > SITIO_LARGO_MAX)
                throw new Exepcion_DatosDeContraseniaInvalidos($"El nombre de usuario debe " +
                    $"contener entre {SITIO_LARGO_MIN} y {SITIO_LARGO_MAX} caracteres");
            else
                nombreSitioApp = unNombreSitioApp;
        }

        public void ActualizarNombreUsuario(string unNombreUsuario)
        {
            int largoNombre = unNombreUsuario.Length;

            if (largoNombre < NOMBRE_LARGO_MIN || largoNombre > NOMBRE_LARGO_MAX)
                throw new Exepcion_DatosDeContraseniaInvalidos($"El nombre de usuario debe " +
                    $"contener entre {NOMBRE_LARGO_MIN} y {NOMBRE_LARGO_MAX} caracteres");
            else
                nombreUsuario = unNombreUsuario;
        }

        public void ActualizarContrasenia(string unaContrasenia)
        {
            int largo = unaContrasenia.Length;

            if (EsLargoValidoContrasenia(largo) && largo != 0)
                throw new Exepcion_DatosDeContraseniaInvalidos($"Largo invalido: la contraseña debe" +
                    $" contener entre {CONTRASENIA_LARGO_MIN} y {CONTRASENIA_LARGO_MAX} caracteres");

            contrasenia = unaContrasenia;

            nivelSeguridadContrasenia = CalcularSeguridad(contrasenia);
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
            else if (tiposDeCaracteres[0] && tiposDeCaracteres[1])
                return 4;
            else if (tiposDeCaracteres[0] || tiposDeCaracteres[1])
                return 3;

            return -1;
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

        public static string GenerarContrasenia(int largo, bool[] caracteresRequeridos)
        {
            string contrasenia;

            if (EsLargoValidoContrasenia(largo))
                throw new Exepcion_DatosDeContraseniaInvalidos($"Largo invalido: la contraseña debe contener " +
                    $"entre {CONTRASENIA_LARGO_MIN} y {CONTRASENIA_LARGO_MAX} caracteres");
            else if (ContarTrues(caracteresRequeridos) == 0)
                throw new Exepcion_DatosDeContraseniaInvalidos("Debe seleccionar al menos un caracter");

            contrasenia = GenerarString(largo, caracteresRequeridos);

            return contrasenia;
        }

        private static int TipoDeUnCaracter(char caracter)
        {
            for (int i = 0; i < caracteresPorPosicion.Length; i++)
                if (caracteresPorPosicion[i].Contains(caracter.ToString()))
                    return i;

            return -1;
        }

        private static bool EsLargoValidoContrasenia(int largo)
        {
            return largo < CONTRASENIA_LARGO_MIN || largo > CONTRASENIA_LARGO_MAX;
        }

        private static int GenerarNumAlazar(int numMin, int numMax)
        {
            Random numRandom = new Random();
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
                int tiposDeCarateresRestantes = ContarTrues(caracteresFaltantes);
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

        private static int ContarTrues(bool[] array)
        {
            int cantidadDeTrues = 0;
            int largoArray = array.Length;

            for (int i = 0; i < largoArray; i++)
                if (array[i])
                    cantidadDeTrues++;

            return cantidadDeTrues;
        }

        private static string ConstruirStringPorLetra(bool[] esCaracteresRequeridos, ref bool[] esCaracteresFaltantes,
    string aSeguirGenerando)
        {
            bool generoUnCaracter = false;
            int numAlazaro = 0;

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

    }
}