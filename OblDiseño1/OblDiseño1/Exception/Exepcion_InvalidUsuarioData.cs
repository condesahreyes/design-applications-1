using System;
namespace OblDiseño1
{
    public class Exepcion_InvalidUsuarioData : Exception
    {
        public Exepcion_InvalidUsuarioData(string message) : base(message)
        {
        }
    }
}