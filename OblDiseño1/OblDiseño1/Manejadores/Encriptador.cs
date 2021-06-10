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

        public Encriptador()
        {

        }

        public string Desencriptar(string contraseniaEncriptada, string llave)
        {
            byte[] buffer = Convert.FromBase64String(contraseniaEncriptada);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(llave);
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

        public string Encriptar(string contrasenia, string llave)
        {
            byte[] contraseniaEncriptada;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(llave);
                aes.IV = vectorDeInicializacion;

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
            return Convert.ToBase64String(contraseniaEncriptada);
        }


        public string GenerarLlave()
        {
            string llave;
            using (Aes aes = Aes.Create())
            {
                aes.GenerateKey();
                byte[] llaveEnBytes = aes.Key;
                llave = Convert.ToBase64String(llaveEnBytes);
            }
            return llave;
        }
    }
}
