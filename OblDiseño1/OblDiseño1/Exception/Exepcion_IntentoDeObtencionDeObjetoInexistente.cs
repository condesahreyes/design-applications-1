using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblDiseño1
{
    public class Exepcion_IntentoDeObtencionDeObjetoInexistente : Exception
    {
        public Exepcion_IntentoDeObtencionDeObjetoInexistente(string message) : base(message)
        {

        }

    }
}
