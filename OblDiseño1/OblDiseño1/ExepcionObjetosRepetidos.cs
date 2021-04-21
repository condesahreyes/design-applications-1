using System;

namespace OblDiseño1
{
    public class ExepcionObjetosRepetidos : Exception
    {
        public ExepcionObjetosRepetidos()
        {
        }

        public ExepcionObjetosRepetidos(string message) : base(message)
        {
        }

    }
}