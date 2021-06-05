using System;

namespace OblDiseño1
{
    public class ExepcionInvalidCategoriaData : SystemException
    {

        public ExepcionInvalidCategoriaData(string message) : base(message)
        {
        }

    }
}