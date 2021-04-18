using System;
using System.Text;
using System.Collections;

namespace OblDiseño1
{
    public class Dupla_UsuarioContrasenia
    {
        const string caracteresNumericos = "0123456789";
        const string caracteresMinusculas = "abcdefghijklmnopqrstuvwxyz";
        const string caracteresMayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string caracteresEspeciales = " !\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
        private static string[] caracteresPorPosicion = { caracteresMayusculas, caracteresMinusculas,
            caracteresNumericos, caracteresEspeciales};
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

        public string NombreUsuario { get => nombreUsuario; set => actualizarNombreUsuario(value); }
        public string Contrasenia { get => contrasenia; set => actualizarContrasenia(value); }
        public string NombreSitioApp { get => nombreSitioApp; set => actualizarNombreSitioApp(value); }
        public string TipoSitioOApp { get; set; }
        public string Nota { get => nota; set => actualizarNota(value); }

        public Categoria Categoria { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }

        public int NivelSeguridadContrasenia { get => nivelSeguridadContrasenia; }

        public bool DataBrench { get; set; }

        public Dupla_UsuarioContrasenia(string unNombreUsuario, string unaContrasenia, string unSitio, string laNota, Categoria laCategoria)
        {
            NombreUsuario = unNombreUsuario;
            Contrasenia = unaContrasenia;
            NombreSitioApp = unSitio;
            Nota = laNota;
            Categoria = laCategoria;
            FechaUltimaModificacion = DateTime.Today;
            nivelSeguridadContrasenia = calcularSeguridad(contrasenia);
            DataBrench = false;
        }

        public static int calcularSeguridad(string unaContrasenia)
        {
            int contraseniaLargo = unaContrasenia.Length;
            bool[] tiposDeCaracteres = getTiposCaracteresContenidos(unaContrasenia);
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

        public void actualizarNota(string unaNota)
        {
            int largoNota = unaNota.Length;
            if (largoNota > 250)
                throw new Exepcion_DatosDeContraseniaInvalidos($"La nota debe contener como maximo" +
                    $"{NOTA_LARGO_MAX} caracteres");
            else
                nota = unaNota;
        }

        public void actualizarNombreSitioApp(string unNombreSitioApp)
        {
            int largoNombre = unNombreSitioApp.Length;
            if (largoNombre < 3 || largoNombre > 25)
                throw new Exepcion_DatosDeContraseniaInvalidos($"El nombre de usuario debe contener entre" +
                    $"{SITIO_LARGO_MIN} y {SITIO_LARGO_MAX} caracteres");
            else
                nombreSitioApp = unNombreSitioApp;
        }

        public void actualizarNombreUsuario(string unNombreUsuario)
        {
            int largoNombre = unNombreUsuario.Length;
            if (largoNombre < 5 || largoNombre > 25)
                throw new Exepcion_DatosDeContraseniaInvalidos($"El nombre de usuario debe contener entre" +
                    $"{NOMBRE_LARGO_MIN} y {NOMBRE_LARGO_MAX} caracteres");
            else
                nombreUsuario = unNombreUsuario;
        }

        private static bool esLargoValidoContrasenia(int largo)
        {
            return largo < CONTRASENIA_LARGO_MIN || largo > CONTRASENIA_LARGO_MAX;
        }

        public void actualizarContrasenia(string unaContrasenia)
        {
            int largo = unaContrasenia.Length;
            if (esLargoValidoContrasenia(largo) && largo != 0)
                throw new Exepcion_DatosDeContraseniaInvalidos($"Largo invalido: la contraseña debe contener " +
                    $"entre {CONTRASENIA_LARGO_MIN} y {CONTRASENIA_LARGO_MAX} caracteres");
            contrasenia = unaContrasenia;
            nivelSeguridadContrasenia = calcularSeguridad(contrasenia);
        }

        public static string generarContrasenia(int largo, bool[] caracteresRequeridos)
        {
            string contrasenia;
            if (esLargoValidoContrasenia(largo))
                throw new Exepcion_DatosDeContraseniaInvalidos($"Largo invalido: la contraseña debe contener " +
                    $"entre {CONTRASENIA_LARGO_MIN} y {CONTRASENIA_LARGO_MAX} caracteres");
            else if (contarTrues(caracteresRequeridos) == 0)
                throw new Exepcion_DatosDeContraseniaInvalidos("Debe seleccionar al menos un caracter");
            contrasenia = generarString(largo, caracteresRequeridos);
            return contrasenia;
        }

        private static int contarTrues(bool[] array)
        {
            int cantidadDeTrues = 0;
            int largoArray = array.Length;
            for (int i = 0; i < largoArray; i++)
                if (array[i])
                    cantidadDeTrues++;
            return cantidadDeTrues;
        }

        public static int generarNumAlazar(int numMin, int numMax)
        {
            Random numRandom = new Random();
            int num = numRandom.Next(numMin, numMax);
            return num;
        }

        private static string devolverCaracterAlazar(string cadena)
        {
            return cadena[generarNumAlazar(0, cadena.Length)].ToString();
        }

        private static string construirStringPorLetra(bool[] caracteresRequeridos, ref bool[] caracteresFaltantes,
            string aSeguirGenerando)
        {
            bool genero = false;
            int numAlazaro = 0;
            while (!genero)
            {
                numAlazaro = generarNumAlazar(0, 4);
                if (caracteresRequeridos[numAlazaro])
                {
                    genero = true;
                    string caracterGenerado = devolverCaracterAlazar(caracteresPorPosicion[numAlazaro]);
                    caracteresFaltantes[numAlazaro] = false;
                    aSeguirGenerando += caracterGenerado;
                }
            }

            return aSeguirGenerando;
        }

        private static bool[] copiarArrayBool(bool[] array)
        {
            int largoArray = array.Length;
            bool[] arrayGenerado = new bool[largoArray];
            for (int i = 0; i < largoArray; i++)
                arrayGenerado[i] = array[i];
            return arrayGenerado;
        }

        private static string generarString(int largoString, bool[] caracteresRequeridos)
        {

            string stringGenerado = "";

            bool[] caracteresFaltantes = copiarArrayBool(caracteresRequeridos);

            while (largoString > 0)
            {
                stringGenerado = construirStringPorLetra(caracteresRequeridos, ref caracteresFaltantes, stringGenerado);
                int tiposDeCarateresRestantes = contarTrues(caracteresFaltantes);
                if (tiposDeCarateresRestantes + 1 == largoString)
                    caracteresRequeridos = caracteresFaltantes;
                largoString--;
            }

            return stringGenerado;
        }

        private static int tipoDeUnCaracter(char caracter)
        {
            for (int i = 0; i < caracteresPorPosicion.Length; i++)
                if (caracteresPorPosicion[i].Contains(caracter.ToString()))
                    return i;
            return -1;
        }

        public static bool[] getTiposCaracteresContenidos(string str)
        {
            char caracterDelString;
            int tipoCaracter;
            bool[] tiposDeCaracteres = new bool[caracteresPorPosicion.Length];
            for (int i = 0; i < str.Length; i++)
            {
                caracterDelString = str[i];
                tipoCaracter = tipoDeUnCaracter(caracterDelString);
                if (tipoCaracter != -1)
                    tiposDeCaracteres[tipoCaracter] = true;

            }

            return tiposDeCaracteres;
        }
    }
}