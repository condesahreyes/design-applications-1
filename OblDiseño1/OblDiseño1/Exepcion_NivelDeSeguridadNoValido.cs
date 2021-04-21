using System;
using System.Runtime.Serialization;

namespace OblDiseño1
{

    public class Exepcion_NivelDeSeguridadNoValido : Exception
    {
        public Exepcion_NivelDeSeguridadNoValido(string message) : base(message)
        {

        }

        public Exepcion_NivelDeSeguridadNoValido(string message, Exception innerExeption)
        {

        }
    }
}