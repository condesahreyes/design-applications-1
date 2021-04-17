using System;
namespace OblDiseño1
{
    public class InvalidUsuarioDataException : Exception
    {
        public InvalidUsuarioDataException()
        {
        }

        public InvalidUsuarioDataException(string message) : base(message)
        {
        }
    }
}