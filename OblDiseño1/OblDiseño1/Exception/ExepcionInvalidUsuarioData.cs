using System;
namespace OblDiseño1
{
    public class ExepcionInvalidUsuarioData : SystemException
    {
        public ExepcionInvalidUsuarioData(string message) : base(message)
        {
        }
    }
}