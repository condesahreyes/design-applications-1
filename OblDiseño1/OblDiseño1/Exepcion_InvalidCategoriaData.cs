using System;

namespace OblDiseño1
{
    public class Exepcion_InvalidCategoriaData : Exception
    {
       
        public Exepcion_InvalidCategoriaData(string message) : base(message)
        {
        }

    }
}