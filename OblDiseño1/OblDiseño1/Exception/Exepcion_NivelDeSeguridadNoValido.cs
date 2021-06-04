using System;
using System.Runtime.Serialization;

namespace OblDiseño1
{

    public class Exepcion_NivelDeSeguridadNoValido : SystemException
    {
        public Exepcion_NivelDeSeguridadNoValido(string message) : base(message)
        {

        }

    }
}