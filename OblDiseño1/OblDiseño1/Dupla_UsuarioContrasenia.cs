using System;
using System.Text;
using System.Collections;

namespace OblDiseño1
{
    public class Dupla_UsuarioContrasenia
    {
        private static readonly string caracteresEspecialesAceptados = " !\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
        private string usernameDupla;
        private string pssDupla;
        private string nombreSitioApp;
        private string tipoSitioOApp;
        private string nota;

        private Categoria categoria;
        private DateTime fechaUltimaModificacion;

        private int nivelSeguridadPss;

        private bool dataBrench;


        public Dupla_UsuarioContrasenia(string userName, string userPssw, string sitio, string laNota, Categoria laCategoria)
        {
            usernameDupla = userName;
            pssDupla = userPssw;
            nombreSitioApp = sitio;
            //tipoSitioOApp: String
            nota = laNota;

            categoria = laCategoria;
            fechaUltimaModificacion = DateTime.Today;

            nivelSeguridadPss = calcularSeguridad(pssDupla);

            dataBrench = false;
        }


        public string UsernameDupla { get => usernameDupla; set => usernameDupla = value; }
        public string PssDupla { get => pssDupla; set => setNuevaPassword(value); }
        public string NombreSitioApp { get => nombreSitioApp; set => nombreSitioApp = value; }
        public string TipoSitioOApp { get => tipoSitioOApp; set => tipoSitioOApp = value; }
        public string Nota { get => nota; set => nota = value; }

        public Categoria Categoria { get => categoria; set => categoria = value; }
        public DateTime FechaUltimaModificacion { get => fechaUltimaModificacion; set => fechaUltimaModificacion = value; }

        public int NivelSeguridadPss { get => nivelSeguridadPss; private set => actualizarNivelDeSeguridad(); }

        public bool DataBrench { get => dataBrench; set => dataBrench = value; }

        public void setNuevaPassword(string nuevaPassword)
        {
            pssDupla = nuevaPassword;
            actualizarNivelDeSeguridad();
        }

        private void actualizarNivelDeSeguridad()
        {
            nivelSeguridadPss = calcularSeguridad(pssDupla);
        }

        /* REFERENCIAS:

        NIVELES DE SEGURIDAD:
        ● (1) Rojo: Contraseña con largo menor a 8 caracteres. 
        ● (2) Naranja: Contraseña con largo entre 8 y 14 caracteres. 
        ● (3) Amarillo: Contraseña con largo mayor a 14 caracteres, sólo mayúsculas o minúsculas. 
        ● (4) Verde Claro: Contraseña con largo mayor a 14 caracteres, con mayúsculas y minúsculas. 
        ● (5) Verde Oscuro: Contraseña con largo mayor a 14 caracteres, con mayúsculas, minúsculas, números y símbolos.
    
        */

        public static int calcularSeguridad(string password) 
        {
            int nivelDeSeguridad;
            int pswLength = password.Length;
            if (pswLength < 8) 
            {
                nivelDeSeguridad = 1;
            }
            else if (pswLength <= 14) 
            {
                nivelDeSeguridad = 2;
            }
            else if (!(tieneMayusculas(password) && tieneMinusculas(password))) 
            {
                nivelDeSeguridad = 3;
            }
            else if (!(tieneNumeros(password) && tieneSimbolos(password))) 
            {
                nivelDeSeguridad = 4;
            }
            else 
            {
                nivelDeSeguridad = 5;
            }

            return nivelDeSeguridad;
        }

        public static string generarContrasenia(int largo, bool incluirMayus, bool incluirMinus, bool incluirDigitos, bool incluirEspeciales)
        {
            String contrasenia;

            if(largo <= 0) 
            {
                throw new Exception("Largo invalido: una contrasenia debe tener al menos un caracter");
            }
            else if (!(incluirMayus || incluirMinus || incluirDigitos || incluirEspeciales))
            {
                throw new Exception("Requerimientos invalidos: una contrasenia debe contener al menos un tipo de caracter");
            }
            else if(largo < contarTrues(incluirMayus, incluirMinus, incluirDigitos, incluirEspeciales))
            {
                throw new Exception("Requerimientos invalidos: el largo de la contrasenia debe ser mayor o igual a la cantidad de tipos de caracteres deseados");
            }
            else 
            {
                contrasenia = generarPlantilla(largo, incluirMayus, incluirMinus, incluirDigitos, incluirEspeciales);
            }
            return contrasenia;
        }

        
    
        private static string generarPlantilla(int largo, bool incluirMayus, bool incluirMinus, bool incluirDigitos, bool incluirEspeciales)
        {
            string especialesPool = " !\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
            string numPool = "0123456789";
            string minusPool = "abcdefghijklmnopqrstuvwxyz";
            string mayusPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int tiposDeCarateresRequeridos = contarTrues(incluirMayus, incluirMinus, incluirDigitos, incluirEspeciales);
            int tiposDeCaracteresPorAgregar = tiposDeCarateresRequeridos;
            int caracteresPorAgregar = largo;

            StringBuilder plantilla = new StringBuilder();
            Random generadorNumRandom = new Random();
            int sueloDeRandom = 0;

            int incluidos = 0;
            string[] referencia = new string[tiposDeCarateresRequeridos];
            bool[] referenciaBool = new bool[tiposDeCarateresRequeridos];
            if (incluirMayus) 
            {
                referencia[incluidos] = "Mayus";
                referenciaBool[incluidos] = false;
                incluidos++;
            } 
            if (incluirMinus)
            {
                referencia[incluidos] = "Minus";
                referenciaBool[incluidos] = false;
                incluidos++;
            }
            if (incluirDigitos)
            {
                referencia[incluidos] = "Digitos";
                referenciaBool[incluidos] = false;
                incluidos++;
            }
            if (incluirEspeciales)
            {
                referencia[incluidos] = "Especiales";
                referenciaBool[incluidos] = false;
            }


            for(int i = 0; i < largo; i++)
            {
                if(caracteresPorAgregar > tiposDeCaracteresPorAgregar) 
                {
                    int aIncluir = generadorNumRandom.Next(sueloDeRandom, tiposDeCarateresRequeridos);
                    string toAppend;
                    switch (referencia[aIncluir])
                    {
                        case "Mayus":
                            toAppend = Char.ToString(mayusPool[generadorNumRandom.Next(sueloDeRandom, mayusPool.Length)]);
                            plantilla.Append(toAppend);
                            break;
                        case "Minus":
                            toAppend = Char.ToString(minusPool[generadorNumRandom.Next(sueloDeRandom, minusPool.Length)]);
                            plantilla.Append(toAppend);
                            break;
                        case "Digitos":
                            toAppend = Char.ToString(numPool[generadorNumRandom.Next(sueloDeRandom, numPool.Length)]);
                            plantilla.Append(toAppend);
                            break;
                        case "Especiales":
                            toAppend = Char.ToString(especialesPool[generadorNumRandom.Next(sueloDeRandom, especialesPool.Length)]);
                            plantilla.Append(toAppend);
                            break;
                        default:
                            break;
                    }   
                    caracteresPorAgregar--;            
                    if (!referenciaBool[aIncluir])
                    {
                        tiposDeCaracteresPorAgregar--;
                        referenciaBool[aIncluir] = true;
                    }
                }
                else
                {
                    int aIncluir = generadorNumRandom.Next(sueloDeRandom, tiposDeCarateresRequeridos);
                    while (referenciaBool[aIncluir])
                    {
                        aIncluir = masMasCircular(aIncluir, sueloDeRandom, tiposDeCarateresRequeridos);
                    }
                    string toAppend;
                    switch (referencia[aIncluir])
                    {
                        case "Mayus":
                            toAppend = Char.ToString(mayusPool[generadorNumRandom.Next(sueloDeRandom, mayusPool.Length)]);
                            plantilla.Append(toAppend);
                            break;
                        case "Minus":
                            toAppend = Char.ToString(minusPool[generadorNumRandom.Next(sueloDeRandom, minusPool.Length)]);
                            plantilla.Append(toAppend);
                            break;
                        case "Digitos":
                            toAppend = Char.ToString(numPool[generadorNumRandom.Next(sueloDeRandom, numPool.Length)]);
                            plantilla.Append(toAppend);
                            break;
                        case "Especiales":
                            toAppend = Char.ToString(especialesPool[generadorNumRandom.Next(sueloDeRandom, especialesPool.Length)]);
                            plantilla.Append(toAppend);
                            break;
                        default:
                            break;
                    }
                    caracteresPorAgregar--;
                    tiposDeCaracteresPorAgregar--;
                    referenciaBool[aIncluir] = true;
                }
            }

            return plantilla.ToString();
        }

        private static int masMasCircular(int numero, int cotaInferior, int cotaSuperior)
        {
            int toReturn = numero + 1;
            if (toReturn >= cotaSuperior) toReturn = cotaInferior;
            return toReturn;
        }

        private static int contarTrues(bool b1, bool b2, bool b3, bool b4) 
        {
            int cantidadDeTrues = 0;
            if (b1) cantidadDeTrues++;
            if (b2) cantidadDeTrues++;
            if (b3) cantidadDeTrues++;
            if (b4) cantidadDeTrues++;
            return cantidadDeTrues;
        } 

        private static bool tieneMayusculas(string str)
        {
            bool hayMayusculas = false;
            for (int i = 0; i < str.Length; i++)
            {
                int codigoASCII = (int)str[i];
                if (codigoASCII >= 65 && codigoASCII <= 90)
                {
                    hayMayusculas = true;
                }
            }
            return hayMayusculas;
        }

        private static bool tieneMinusculas(string str) 
        {
            bool hayMinusculas = false;
            for (int i = 0; i < str.Length; i++)
            {
                int codigoASCII = (int)str[i];
                if (codigoASCII >= 97 && codigoASCII <= 122)
                {
                    hayMinusculas = true;
                }
            }
            return hayMinusculas;
        }

        private static bool tieneNumeros(string str) 
        {
            bool hayNumeros = false;

            for (int i = 0; i < str.Length; i++)
            {
                int codigoASCII = (int)str[i];
                if (codigoASCII >= 48 && codigoASCII <= 57)
                {
                    hayNumeros = true;
                }
            }

            return hayNumeros;
        }

        private static bool tieneSimbolos(string str)
        {
            bool haySimbolos = false;

            for (int i = 0; i < str.Length; i++)
            {
                int codigoASCII = (int)str[i];
                if ((codigoASCII >= 32 && codigoASCII <= 47) || (codigoASCII >= 58 && codigoASCII <= 64)
                    || (codigoASCII >= 91 && codigoASCII <= 96) || (codigoASCII >= 123 && codigoASCII <= 126))
                {
                    haySimbolos = true;
                }
            }

            return haySimbolos;
        }

        public static bool[] getTiposDeCaracteresContenidos(String str)
        {
            bool contieneMayusculas = false;
            bool contieneMinusculas = false;
            bool contieneDigitos = false;
            bool contineeEspeciales = false;
            for (int i = 0; i < str.Length; i++)
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

            bool[] toReturn = { contieneMayusculas, contieneMinusculas, contieneDigitos, contineeEspeciales };
            return toReturn;
        }
    }
}