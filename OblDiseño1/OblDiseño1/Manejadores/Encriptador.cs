using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using OblDiseño1.Interfaces;

namespace OblDiseño1.Manejadores
{
    class Encriptador : IEncriptado
    {
        private byte[] Vector;

        public string Desencriptar(string contraseniaEncriptada, string llave)
        {
            return null;
        }

        public string Encriptar(string contrasenia, string llave)
        {
            return null;
        }

        public string GenerarLlave()
        {
            return null;
        }
    }
}
