using System;

namespace OblDiseño1
{
    public class Exepcion_ObjetosRepetidos : Exception
    {
        public Exepcion_ObjetosRepetidos()
        {
        }

        public Exepcion_ObjetosRepetidos(string message) : base(message)
        {
        }

    }
}