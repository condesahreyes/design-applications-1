using System;

namespace OblDiseño1
{
    public class Exepcion_ObjetosRepetidos : SystemException
    {

        public Exepcion_ObjetosRepetidos(string message) : base(message)
        {
        }
    }
}