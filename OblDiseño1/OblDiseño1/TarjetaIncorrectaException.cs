using System;

namespace OblDiseño1
{
    
    public class TarjetaIncorrectaException : Exception
    {
        
        public TarjetaIncorrectaException(string message) : base(message)
        {
        }

    }
}