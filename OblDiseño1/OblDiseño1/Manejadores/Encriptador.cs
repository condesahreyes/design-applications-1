using System.Security.Cryptography;
using OblDiseño1.Interfaces;
using System.IO;
using System;

namespace OblDiseño1.Manejadores
{
    public class Encriptador : IEncriptado
    {
        private readonly byte[] vectorDeInicializacion = new byte[16];

        private const string llaveEjemplo = "23-137-23-40-105-219-185-252-253-147-46-44-227-39-192-187-224-254-239-138-89-34-137-213-128-22-16-171-186-80-142-252";

        public Encriptador()
        {

        }

        public string ObtenerLlaveHardcodeada()
        {
            return llaveEjemplo;
        }

        public string Desencriptar(string textoEncriptado, string llave)
        {
            byte[] buffer = CadenaStringABytes(textoEncriptado);

            using (Aes aes = Aes.Create())
            {
                aes.Key = CadenaStringABytes(llave);
                aes.IV = vectorDeInicializacion;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, 
                        CryptoStreamMode.Read))
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
                byte[] keyAux = CadenaStringABytes(llave);
                aes.Key = keyAux;
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, 
                        CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(textoAEncriptar);
                        }

                        contraseniaEncriptada = memoryStream.ToArray();
                    }
                }
            }

            return CadenaBytesAString(contraseniaEncriptada);
        }

        public string GenerarLlave()
        {
            string llave;
            using (Aes aes = Aes.Create())
            {
                aes.GenerateKey();
                byte[] llaveEnBytes = aes.Key;
                llave = CadenaBytesAString(llaveEnBytes);
            }
            return llave;
        }

        private string CadenaBytesAString(byte[] cadenaDeBytes)
        {
            string retorno = "";
            bool primero = true;
            foreach (byte b in cadenaDeBytes)
            {
                if (!primero)
                    retorno = String.Concat(retorno, "-", b);
                else
                {
                    retorno = String.Concat(retorno, b);
                    primero = false;
                }

            }
            return retorno;
        }

        private byte[] CadenaStringABytes(string cadenaDeBytesEnString)
        {
            string[] bytesEnFormatoString = cadenaDeBytesEnString.Split('-');
            byte[] retorno = new byte[bytesEnFormatoString.Length];

            for (int i = 0; i < bytesEnFormatoString.Length; i++)
            {
                int unint = Int16.Parse(bytesEnFormatoString[i]);
                retorno[i] = (byte)unint;
            }
            return retorno;
        }
    }
}


