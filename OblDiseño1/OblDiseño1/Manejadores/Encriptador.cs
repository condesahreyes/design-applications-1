using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using OblDiseño1.Interfaces;
using System.IO;

namespace OblDiseño1.Manejadores
{
    public class Encriptador : IEncriptado
    {
        private readonly byte[] vectorDeInicializacion = new byte[16];
                                            // 12345678901234567890123456789012        
        //private const string llaveEjemplo = "CbBVkf5ceFQVzgWHRRmCReYkgNt8X9MlKUaOUpbvm+w=";
        private const string llaveEjemplo = "I¨àæ[\u009bk)®ö\u008c][\u0096Ú\u0083e\u0002Y\u0017}¨+Cék\u001aéõlx·";
        //                                  "I¨àæ[\u009bk)®ö\u008c][\u0096Ú\u0083e\u0002Y\u0017}¨+Cék\u001aéõlx·"
        //                                   123456     78901     234     56     78     90     1234567     89012
        public string LlaveEjemplo { get => llaveEjemplo; }

        public Encriptador()
        {

        }

        public string Desencriptar(string textoEncriptado, string llave)
        {   
            //byte[] buffer = ConventirDeStringABYTE(textoEncriptado);
            byte[] buffer = Encoding.Default.GetBytes(textoEncriptado);

            using (Aes aes = Aes.Create())
            {
                //aes.Key = ConventirDeStringABYTE(llave);
                aes.Key = Encoding.Default.GetBytes(llave);
                aes.IV = vectorDeInicializacion;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }   
        }

        public string Encriptar(string textoAEncriptar, string llave)
        {
            byte[] iv = vectorDeInicializacion;
            byte[] contraseniaEncriptada;

            using (Aes aes = Aes.Create())
            {
                //byte[] keyAux = ConventirDeStringABYTE(llave);
                byte[] keyAux = Encoding.Default.GetBytes(llave);
                aes.Key = keyAux;
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(textoAEncriptar);
                        }

                        contraseniaEncriptada = memoryStream.ToArray();
                    }
                }
            }

            //return ConventirDeByteASTRING(contraseniaEncriptada);
            return Encoding.Default.GetString(contraseniaEncriptada);
        }


        public string GenerarLlave()
        {
            string llave;
            using (Aes aes = Aes.Create())
            {
                aes.GenerateKey();
                byte[] llaveEnBytes = aes.Key;

                //llave = Convert.ToBase64String(llaveEnBytes);
                //llave = ConventirDeByteASTRING(llaveEnBytes);
                llave = Encoding.Default.GetString(llaveEnBytes);
            }
            return llave;
        }

        private byte[] ConventirDeStringABYTE(string aCombertir)
        {
            int tamanioLlaveAES_valido = 32;
            byte[] retorno = new byte[tamanioLlaveAES_valido];
            for(int i = 0; i < aCombertir.Length; i++)
            {
                retorno[i] = (byte)aCombertir[i];
            }
            return retorno;
        }

        private string ConventirDeByteASTRING(byte[] aCombertir)
        {
            int tamanioLlaveAES_valido = 32;

            char[] retornoAux = new char[tamanioLlaveAES_valido];

            for (int i = 0; i < aCombertir.Length; i++)
            {
                retornoAux[i] = (char)aCombertir[i];
            }
            return new string(retornoAux);
        }

        private byte[] ConventirEncriptadoDeStringABYTE(string aCombertir)
        {
            int tamanioLlaveAES_valido = 16;
            byte[] retorno = new byte[tamanioLlaveAES_valido];
            for (int i = 0; i < aCombertir.Length; i++)
            {
                retorno[i] = (byte)aCombertir[i];
            }
            return retorno;
        }



        private string ConventirEncriptadoDeByteASTRING(byte[] aCombertir)
        {
            int tamanioLlaveAES_valido = 32;

            char[] retornoAux = new char[tamanioLlaveAES_valido];

            for (int i = 0; i < aCombertir.Length; i++)
            {
                retornoAux[i] = (char)aCombertir[i];
            }
            return new string(retornoAux);
        }
    }
}


/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using OblDiseño1.Interfaces;
using System.IO;

namespace OblDiseño1.Manejadores
{
    public class Encriptador : IEncriptado
    {
        private readonly byte[] vectorDeInicializacion = new byte[16];
        // 12345678901234567890123456789012        
        //private const string llaveEjemplo = "CbBVkf5ceFQVzgWHRRmCReYkgNt8X9MlKUaOUpbvm+w=";
        private const string llaveEjemplo = "I¨àæ[\u009bk)®ö\u008c][\u0096Ú\u0083e\u0002Y\u0017}¨+Cék\u001aéõlx·";
        //                                  "I¨àæ[\u009bk)®ö\u008c][\u0096Ú\u0083e\u0002Y\u0017}¨+Cék\u001aéõlx·"
        //                                   123456     78901     234     56     78     90     1234567     89012
        public string LlaveEjemplo { get => llaveEjemplo; }

        public Encriptador()
        {

        }

        public string Desencriptar(string contraseniaEncriptada, string llave)
        {
            //byte[] buffer = Convert.FromBase64String(contraseniaEncriptada);
            //byte[] buffer = Encoding.ASCII.GetBytes(contraseniaEncriptada);
            byte[] buffer = ConventirEncriptadoDeStringABYTE(contraseniaEncriptada);
            //byte[] buffer = Encoding.UTF8.GetBytes(contraseniaEncriptada);

            using (Aes aes = Aes.Create())
            {
                //aes.Key = Convert.FromBase64String(llave);
                //aes.Key = Encoding.ASCII.GetBytes(llave);
                aes.Key = ConventirLlaveDeStringABYTE(llave);
                //aes.Key = Encoding.UTF8.GetBytes(llave);
                aes.IV = vectorDeInicializacion;
                aes.Padding = PaddingMode.PKCS7;


                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        public string Encriptar(string contrasenia, string llave)
        {
            byte[] contraseniaEncriptada;

            //contrasenia = contrasenia + "==";
            using (Aes aes = Aes.Create())
            {
                //aes.Key = Convert.FromBase64String(llave);
                //aes.Key = Encoding.ASCII.GetBytes(llave);
                aes.Key = ConventirLlaveDeStringABYTE(llave);
                //aes.Key = Encoding.UTF8.GetBytes(llave);
                aes.IV = vectorDeInicializacion;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform encriptadorBasico = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encriptadorBasico, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(contrasenia);
                        }

                        contraseniaEncriptada = memoryStream.ToArray();
                    }
                }
            }
            //return Convert.ToBase64String(contraseniaEncriptada);
            //return Encoding.ASCII.GetString(contraseniaEncriptada);
            return ConventirEncriptadoDeByteASTRING(contraseniaEncriptada);
            //return Encoding.UTF8.GetString(contraseniaEncriptada);
        }


        public string GenerarLlave()
        {
            string llave;
            using (Aes aes = Aes.Create())
            {
                aes.GenerateKey();
                byte[] llaveEnBytes = aes.Key;
                //llave = Convert.ToBase64String(llaveEnBytes);
                //llave = Encoding.ASCII.GetString(llaveEnBytes);
                llave = ConventirLlaveDeByteASTRING(llaveEnBytes);
                //llave = Encoding.UTF8.GetString(llaveEnBytes);
            }
            return llave;
        }

        private byte[] ConventirLlaveDeStringABYTE(string aCombertir)
        {
            int tamanioLlaveAES_valido = 32;
            byte[] retorno = new byte[tamanioLlaveAES_valido];
            for (int i = 0; i < aCombertir.Length; i++)
            {
                retorno[i] = (byte)aCombertir[i];
            }
            return retorno;
        }
        private byte[] ConventirEncriptadoDeStringABYTE(string aCombertir)
        {
            int tamanioLlaveAES_valido = 16;
            byte[] retorno = new byte[tamanioLlaveAES_valido];
            for (int i = 0; i < aCombertir.Length; i++)
            {
                retorno[i] = (byte)aCombertir[i];
            }
            return retorno;
        }


        private string ConventirLlaveDeByteASTRING(byte[] aCombertir)
        {
            int tamanioLlaveAES_valido = 32;

            char[] retornoAux = new char[tamanioLlaveAES_valido];

            for (int i = 0; i < aCombertir.Length; i++)
            {
                retornoAux[i] = (char)aCombertir[i];
            }
            return new string(retornoAux);
        }
        private string ConventirEncriptadoDeByteASTRING(byte[] aCombertir)
        {
            int tamanioLlaveAES_valido = 32;

            char[] retornoAux = new char[tamanioLlaveAES_valido];

            for (int i = 0; i < aCombertir.Length; i++)
            {
                retornoAux[i] = (char)aCombertir[i];
            }
            return new string(retornoAux);
        }
    }
}
*/