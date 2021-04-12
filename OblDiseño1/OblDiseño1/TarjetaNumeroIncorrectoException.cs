using System;
using System.Runtime.Serialization;

namespace OblDiseño1
{
    [Serializable]
    public class TarjetaNumeroIncorrectoException : Exception
    {
        public TarjetaNumeroIncorrectoException()
        {
        }

        public TarjetaNumeroIncorrectoException(string message) : base(message)
        {
        }

        public TarjetaNumeroIncorrectoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TarjetaNumeroIncorrectoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}