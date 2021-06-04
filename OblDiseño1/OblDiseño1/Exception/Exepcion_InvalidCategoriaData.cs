using System;

namespace OblDiseño1
{
    public class Exepcion_InvalidCategoriaData : SystemException
    {

        public Exepcion_InvalidCategoriaData(string message) : base(message)
        {
        }

    }
}