using System;
using System.Runtime.Serialization;

namespace OblDiseño1
{
    [Serializable]
    public class TarjetaIncorrectaException : Exception
    {
        public TarjetaIncorrectaException()
        {
        }

        public TarjetaIncorrectaException(string message) : base(message)
        {
        }

        public TarjetaIncorrectaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TarjetaIncorrectaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}