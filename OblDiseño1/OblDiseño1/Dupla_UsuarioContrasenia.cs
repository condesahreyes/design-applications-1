using System;
using System.Text;
using System.Collections;

namespace OblDiseño1
{
    public class Dupla_UsuarioContrasenia
    {
        //private static readonly string caracteresEspecialesAceptados = " !\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
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
        

        CARACTERES ACEPTADOS:
            Letras Mayusculas ---------> "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
                                          ASCII code 65 to 90 (inclusive)

            Letras Minusculas ---------> "abcdefghijklmnopqrstuvwxyz"
                                          ASCII code 97 to 122 (inclusive)

            Digitos (numeros) ---------> "0123456789"
                                          ASCII code 48 to 57 (inclusive)

            Caracteres Especiales -----> " !\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
                                          ASCII code 32 to 47 (inclusive) &&
                                          ASCII code 58 to 64 (inclusive) &&
                                          ASCII code 91 to 96 (inclusive) &&
                                          ASCII code 123 to 126 (inclusive)
            
        */

        /*
        Resumen:
                Retorna un int correspondiente al nivel de seguridad de una contrasenia
                recibida como parametro

        Parametros:
                Un "string"

        Retorno:
                un int cuyo valor es igual a la cantidad de trues pasados por parametro 
                Ej:
                    contarTrues(False, False, False, False) --> retorna 0
                    contarTrues(True, True, False, False) ----> retorna 2
                    contarTrues(True, True, False, True) -----> retorna 3
                    contarTrues(True, True, True, True) ------> retorna 4
        */
        public static int calcularSeguridad(string password) 
        {
            int nivelDeSeguridad;
            int pswLength = password.Length;
            bool[] tiposDeCaracteres = getTiposDeCaracteresContenidos(password);
            if (pswLength < 8) 
            {
                nivelDeSeguridad = 1;
            }
            else if (pswLength <= 14) 
            {
                nivelDeSeguridad = 2;
            }
            else if (!(tiposDeCaracteres[0] && tiposDeCaracteres[1])) //tieneMayusculas(password) && tieneMinusculas(password)
            {
                nivelDeSeguridad = 3;
            }
            else if (!(tiposDeCaracteres[2] && tiposDeCaracteres[3])) //tieneNumeros(password) && tieneSimbolos(password)
            {
                nivelDeSeguridad = 4;
            }
            else 
            {
                nivelDeSeguridad = 5;
            }

            return nivelDeSeguridad;
        }

        /*
       Resumen:
               Recibe parametros que indican los equerimientos de la contrasenia deseada.
               Si son validos devuelde una contrasenia que cumple con dichos requerimientos.
               De no serlo, tira una exepcion acorde

       Parametros:
               largo --------------> la cantidad de caracteres presentes en la contrasenia (si < 1, tira una exeption)

               incluirMayus -------> si es "true", la contrasenia contendra al menos una letra en Mayusculas
                                     si es "false", la contrasenia contendra 0 (cero) letras Mayusculas

               incluirMinus -------> si es "true", la contrasenia contendra al menos una letra en Minuscula
                                     si es "false", la contrasenia contendra 0 (cero) letras Minusculas

               incluirDigitos -----> si es "true", la contrasenia contendra al menos un Digito (numero)
                                     si es "false", la contrasenia contendra no contrndra Digitos (numeros)

               incluirEspeciales --> si es "true", la contrasenia contendra al menos un caracter Especial
                                     si es "false", la contrasenia contendra 0 (cero) caracteres Especiales

       Retorno:
               Si los parametros no son validos: tira una exepcion
                          Posibles parametros no validos:
                                   * si: (largo < 1) ---> la contrasenia tiene que tener al menos un caracters

                                   * si: !(incluirMayus || incluirMinus || incluirDigitos || incluirEspeciales) == true
                                                     ---> la contrasenia solo puede contener caracteres de los 4 tipos
                                                          correspodientes a ese variable, por lo que al menos una tiene 
                                                          que se true.

                                   * si: largo es menor a la cantidad de parametros booleanos en verdadero
                                                     ---> es imposible incluir mas tipos de caracteres que caracteres.

               Si los parametros son validos:
                           Retorna un string de Length == largo, que contiene al menos un caracter cada tipo 
                           correspondiente a el/los parametro/s booleano/s ingresados en "true"
       */
        public static string generarContrasenia(int largo, bool incluirMayus, bool incluirMinus, bool incluirDigitos, bool incluirEspeciales)
        {
            String contrasenia;

            if(largo <= 0) 
            {
                throw new Exepcion_DatosDeContraseniaInvalidos("Largo invalido: una contrasenia debe tener al menos un caracter");
            }
            else if (!(incluirMayus || incluirMinus || incluirDigitos || incluirEspeciales))
            {
                throw new Exepcion_DatosDeContraseniaInvalidos("Requerimientos invalidos: una contrasenia debe contener al menos un tipo de caracter");
            }
            else if(largo < contarTrues(incluirMayus, incluirMinus, incluirDigitos, incluirEspeciales))
            {
                throw new Exepcion_DatosDeContraseniaInvalidos("Requerimientos invalidos: el largo de la contrasenia debe ser mayor o igual a la cantidad de tipos de caracteres deseados");
            }
            else 
            {
                contrasenia = generarPlantilla(largo, incluirMayus, incluirMinus, incluirDigitos, incluirEspeciales);
            }
            return contrasenia;
        }


        /*
        Resumen:
                El metodo "generarContrasenia" habia quedado demaciado extenso, por lo
                que se extrajo a este metodo la logica de generar el string contrasenia,
                mientras que en "generarContrasenia" se dejaron los checkeos.

        Parametros:
                Identico que generarContrasenia 

        Retorno:
                Identico que generarContrasenia, pero sin las Exeption, ya que este metodo
                solo se llama una vez que ya esta chekeado que los parametros sean validos.
        */
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

        /*
        Resumen:
                Incrementa en 1 el parametro "numero", y en caso que despues de quede valiendo igual
                o mas que una cota superior, lo iguala a una cota inferior.

        Parametros:
                numero -------> el int que se desea incremetar
                cotaInferior -> la cota inferior
                cotaSuperior -> la cota superior

        Retorno:
                si (numero + 1) < cotaSuperior --> cotaSuperior
                si (numero + 1) >= cotaSuperior -> cotaInferior
        */
        private static int masMasCircular(int numero, int cotaInferior, int cotaSuperior)
        {
            int toReturn = numero + 1;
            if (toReturn >= cotaSuperior) toReturn = cotaInferior;
            return toReturn;
        }

        /*
        Resumen:
                Devuelve la cantidad de "true" pasados por parameteo

        Parametros:
                4 booleanos

        Retorno:
                un int cuyo valor es igual a la cantidad de trues pasados por parametro 
                Ej:
                    contarTrues(False, False, False, False) --> retorna 0
                    contarTrues(True, True, False, False) ----> retorna 2
                    contarTrues(True, True, False, True) -----> retorna 3
                    contarTrues(True, True, True, True) ------> retorna 4
        */
        private static int contarTrues(bool b1, bool b2, bool b3, bool b4) 
        {
            int cantidadDeTrues = 0;
            if (b1) cantidadDeTrues++;
            if (b2) cantidadDeTrues++;
            if (b3) cantidadDeTrues++;
            if (b4) cantidadDeTrues++;
            return cantidadDeTrues;
        } 


        /*
        Resumen:
                Devuelve los distiontos tipos de caracteres presentes en un string
                Tipos de caracteres: Matusculas, Minusculas, Numeros (o digitos), Especiales

        Parametros:
                Un string

        Retorno:
                Un array de bool de largo 4, cuyos indices indican si el correspondiente tipo de caracter 
                se encuentra en el parametro.
                
                Ej: getTiposDeCaracteresContenidos(parametroStr)
                    arrayBool[0] == true -> si solo si parametroStr contiene al menos una Mayuscula
                    arrayBool[1] == true -> si solo si parametroStr contiene al menos una Minuscula
                    arrayBool[2] == true -> si solo si parametroStr contiene al menos un Numero (Digito)
                    arrayBool[3] == true -> si solo si parametroStr contiene al menos un caracter Especial
         */
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

        /*
         * getTiposDeCaracteresContenidos reemplazo a todos estos, metodos
         * (los deje aca por si llegan a ser necesarios en un futuro)
         
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
         */
    }
}