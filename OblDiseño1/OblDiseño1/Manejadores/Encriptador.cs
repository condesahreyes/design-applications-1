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

        private const string llaveEjemplo = "™œMÆ\u0015,(\u001añ»Zf¸\rQÈËˆë\u000fŽ_Æ\f?©ž”tiÙê";

        public Encriptador()
        {

        }


        public string ObtenerLlaveHardcodeada()
        {
            return llaveEjemplo;
        }

        public string Desencriptar(string textoEncriptado, string llave)
        {
            byte[] buffer = Encoding.Default.GetBytes(textoEncriptado);

            using (Aes aes = Aes.Create())
            {
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

            return Encoding.Default.GetString(contraseniaEncriptada);
        }


        public string GenerarLlave()
        {
            string llave;
            using (Aes aes = Aes.Create())
            {
                aes.GenerateKey();
                byte[] llaveEnBytes = aes.Key;

                llave = Encoding.Default.GetString(llaveEnBytes);
            }
            return llave;
        }
    }
}


