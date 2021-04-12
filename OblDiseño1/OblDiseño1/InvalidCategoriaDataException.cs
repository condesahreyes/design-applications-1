using System;

namespace OblDiseño1
{
    public class InvalidCategoriaDataException : Exception
    {
        public InvalidCategoriaDataException()
        {
        }

        public InvalidCategoriaDataException(string message) : base(message)
        {
        }

    }
}