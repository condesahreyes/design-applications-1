using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblDiseño1
{
    public class Exepcion_DatosDeContraseniaInvalidos : Exception
    {
        public Exepcion_DatosDeContraseniaInvalidos(string message) : base(message)
        {

        }

    }
}
