using System;

namespace OblDiseño1
{
    public class Exepcion_IntentoDeObtencionDeObjetoInexistente : SystemException
    {
        public Exepcion_IntentoDeObtencionDeObjetoInexistente(string message) : base(message)
        {
        }

    }
}
