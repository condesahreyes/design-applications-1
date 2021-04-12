using System;
using System.Runtime.Serialization;

namespace OblDiseño1
{
    [Serializable]
    internal class InvalidCategoriaDataException : Exception
    {
        public InvalidCategoriaDataException()
        {
        }

        public InvalidCategoriaDataException(string message) : base(message)
        {
        }

        public InvalidCategoriaDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCategoriaDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}