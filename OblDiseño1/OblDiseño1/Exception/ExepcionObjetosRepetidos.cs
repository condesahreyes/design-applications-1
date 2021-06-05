using System;

namespace OblDiseño1
{
    public class ExepcionObjetosRepetidos : SystemException
    {

        public ExepcionObjetosRepetidos(string message) : base(message)
        {
        }
    }
}