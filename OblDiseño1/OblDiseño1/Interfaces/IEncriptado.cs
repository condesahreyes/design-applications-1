using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblDiseño1.Interfaces
{
    public interface IEncriptado
    {
        string ObtenerLlaveHardcodeada();
        string GenerarLlave();

        string Encriptar(string contrasenia, string llave);

        string Desencriptar(string contraseniaEncriptada, string llave);
    }
}
