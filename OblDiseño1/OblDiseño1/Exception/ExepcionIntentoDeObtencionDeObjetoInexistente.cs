using System;

namespace OblDiseño1
{
    public class ExepcionIntentoDeObtencionDeObjetoInexistente : SystemException
    {
        public ExepcionIntentoDeObtencionDeObjetoInexistente(string message) : base(message)
        {
        }

    }
}
